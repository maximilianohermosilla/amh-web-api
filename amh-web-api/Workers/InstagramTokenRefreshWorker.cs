using Application.DTO.General;
using Application.Interfaces.General.IServices;
using System.Text.Json;
using Domain.Models;
using amh_web_api.DTO;

namespace amh_web_api.Workers
{
    public class InstagramTokenRefreshWorker : BackgroundService
    {
        private readonly ILogger<InstagramTokenRefreshWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IHttpClientFactory _httpClientFactory;

        // Cada 30 días
        private readonly TimeSpan _period = TimeSpan.FromDays(30);

        public InstagramTokenRefreshWorker(
            ILogger<InstagramTokenRefreshWorker> logger,
            IServiceScopeFactory scopeFactory,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _httpClientFactory = httpClientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(_period);
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    _logger.LogInformation("Iniciando tarea de refresh de tokens de Instagram.");
                    await ProcessTokensAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ocurrió un error al procesar el refresco de tokens de Instagram.");
                }
            }
        }

        private async Task ProcessTokensAsync(CancellationToken stoppingToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var sistemaService = scope.ServiceProvider.GetRequiredService<ISistemaService>();
            var paramConfigService = scope.ServiceProvider.GetRequiredService<IParametroConfiguracionService>();

            // Obtener todos los sistemas
            var responseSistemas = await sistemaService.GetAll();
            if (responseSistemas.statusCode != 200 || responseSistemas.response == null)
            {
                _logger.LogWarning("No se pudo obtener la lista de sistemas.");
                return;
            }

            var sistemas = responseSistemas.response as List<SistemaResponse>;
            if (sistemas == null) return;

            var client = _httpClientFactory.CreateClient();

            foreach (var sistema in sistemas)
            {
                // Buscar el token para el sistema actual
                var responseParam = await paramConfigService.GetByNombre("IG_TOKEN", sistema.Id);
                
                if (responseParam.statusCode == 200 && responseParam.response != null)
                {
                    var param = responseParam.response as ParametroConfiguracionResponse;
                    if (param != null && !string.IsNullOrEmpty(param.Valor))
                    {
                        var tokenActual = param.Valor;
                        
                        try
                        {
                            var url = $"https://graph.instagram.com/refresh_access_token?grant_type=ig_refresh_token&access_token={tokenActual}";
                            var httpResponse = await client.GetAsync(url, stoppingToken);

                            if (httpResponse.IsSuccessStatusCode)
                            {
                                var jsonString = await httpResponse.Content.ReadAsStringAsync(stoppingToken);
                                var igResponse = JsonSerializer.Deserialize<InstagramRefreshResponse>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                                if (igResponse != null && !string.IsNullOrEmpty(igResponse.access_token))
                                {
                                    // Actualizar token
                                    var updateRequest = new ParametroConfiguracionRequest
                                    {
                                        Id = param.Id,
                                        IdSistema = param.IdSistema,
                                        Nombre = param.Nombre,
                                        Valor = igResponse.access_token
                                    };
                                    
                                    await paramConfigService.Update(updateRequest);
                                    _logger.LogInformation("Se refrescó exitosamente el IG_TOKEN para el sistema {SistemaId}", sistema.Id);
                                }
                            }
                            else
                            {
                                var errorContent = await httpResponse.Content.ReadAsStringAsync(stoppingToken);
                                _logger.LogWarning("Error al refrescar token para sistema {SistemaId}. StatusCode: {StatusCode}. Response: {Response}", sistema.Id, httpResponse.StatusCode, errorContent);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Excepción al intentar refrescar el token de Instagram para el sistema {SistemaId}", sistema.Id);
                        }
                    }
                }
            }
        }
    }

    public class InstagramRefreshResponse
    {
        public string access_token { get; set; } = null!;
        public string token_type { get; set; } = null!;
        public int expires_in { get; set; }
        public string permissions { get; set; } = null!;
    }
}
