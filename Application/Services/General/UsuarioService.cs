using amh_web_api.DTO;
using Application.DTO.General;
using Application.Helpers;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Interfaces.General.IServices;
using AutoMapper;
using Azure.Core;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.General
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IUsuarioCommand _usuarioCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(IUsuarioQuery usuarioQuery, IUsuarioCommand usuarioCommand, IMapper mapper, ILogger<UsuarioService> logger)
        {
            _usuarioQuery = usuarioQuery;
            _usuarioCommand = usuarioCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Usuario> lista = await _usuarioQuery.GetAll();
                List<UsuarioResponse> listaDTO = _mapper.Map<List<UsuarioResponse>>(lista);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = listaDTO;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{ex.Message}");
            }

            return response;
        }

        public async Task<ResponseModel> GetByCredentials(UsuarioLoginDTO request, string secretKey)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                var passEncoded = CryptographyHelper.Encrypt(request.Password);
                request.Password = passEncoded;
                Usuario usuario = await _usuarioQuery.GetByCredentials(request);

                if (usuario != null)
                {
                    UsuarioResponse usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);

                    if (usuarioResponse.Habilitado == true && usuarioResponse.UsuariosSistema.Select(u => u.IdSistema).Contains(request.IdSistema))
                    {
                        var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                        var claims = new ClaimsIdentity();
                        claims.AddClaim(new Claim(ClaimTypes.Name, request.Login));
                        claims.AddClaim(new Claim(ClaimTypes.Role, usuarioResponse.PerfilDescripcion));
                        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuarioResponse.Id.ToString()));

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = claims,
                            Expires = DateTime.UtcNow.AddDays(365),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var tokenConfiguration = tokenHandler.CreateToken(tokenDescriptor);

                        string tokenCreated = tokenHandler.WriteToken(tokenConfiguration);

                        response.message = "Consulta realizada correctamente";
                        response.statusCode = 200;
                        response.response = tokenCreated;
                    }
                    else
                    {
                        response.message = "El usuario no se encuentra habilitado para este sistema";
                        response.statusCode = 403;
                        response.response = null;
                        _logger.LogError(response.message);
                    }                    
                }
                else
                {
                    response.message = "Usuario o contraseña incorrectos";
                    response.statusCode = 404;
                    response.response = null;
                    _logger.LogError(response.message);
                }
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{ex.Message}");
            }

            return response;
        }

        public async Task<ResponseModel> GetById(int? id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Usuario usuario = await _usuarioQuery.GetById(id);

                if (usuario == null)
                {
                    response.statusCode = 404;
                    response.message = "El usuario seleccionado no existe";
                    response.response = null;
                    return response;
                }

                UsuarioResponse usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);

                var passDecoded = CryptographyHelper.Decrypt(usuario.Password);
                usuarioResponse.Password = passDecoded;

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = usuarioResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{ex.Message}");
            }

            return response;
        }

        public async Task<ResponseModel> Insert(UsuarioRequest entity)
        {
            ResponseModel response = new ResponseModel();
            UsuarioResponse usuarioResponse = new UsuarioResponse();
            try
            {
                Usuario usuario = _mapper.Map<Usuario>(entity);
                usuario = await _usuarioCommand.Insert(usuario);
                usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);

                _logger.LogInformation("Se insertó un nuevo usuario: " + usuario.Id + ". Nombre: " + usuario.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{ex.Message}");
                return response;
            }

            response.statusCode = 201;
            response.message = "Usuario insertado exitosamente";
            response.response = usuarioResponse;
            return response;
        }

        public async Task<ResponseModel> Update(UsuarioRequest entity)
        {
            ResponseModel response = new ResponseModel();
            UsuarioResponse usuarioResponse = new UsuarioResponse();
            try
            {
                var usuarioCorreoRepetido = await _usuarioQuery.GetByIdAndEmail(entity.Id, entity.Correo);

                if (usuarioResponse != null)
                {
                    response.statusCode = 403;
                    response.message = "Ya existe un usuario habilitado con la misma dirección de correo";
                    response.response = null;
                    return response;
                }

                var usuario = await _usuarioQuery.GetById(entity.Id);

                if (usuario == null)
                {
                    response.statusCode = 404;
                    response.message = "El usuario seleccionado no existe";
                    response.response = null;
                    return response;
                }

                usuario.Nombre = entity.Nombre;
                usuario.Imagen = entity.Imagen;

                await _usuarioCommand.Update(usuario);
                usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);

                _logger.LogInformation("Se actualizó el usuario: " + usuario.Id + ". Nombre anterior: " + usuario.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{ex.Message}");
                return response;
            }

            response.statusCode = 200;
            response.message = "Usuario actualizado exitosamente";
            response.response = usuarioResponse;
            return response;
        }


        public async Task<ResponseModel> UpdatePassword(UsuarioLoginDTO entity)
        {
            ResponseModel response = new ResponseModel();
            UsuarioResponse usuarioResponse = new UsuarioResponse();
            try
            {
                var passEncoded = CryptographyHelper.Encrypt(entity.Password);
                entity.Password = passEncoded;
                Usuario usuario = await _usuarioQuery.GetByCredentials(entity);

                if (usuario == null)
                {
                    response.statusCode = 404;
                    response.message = "Usuario o contraseña incorrectos";
                    response.response = null;
                    return response;
                }

                var passEncodedNew = CryptographyHelper.Encrypt(entity.PasswordNew);
                usuario.Password = passEncodedNew;

                await _usuarioCommand.Update(usuario);
                usuarioResponse = _mapper.Map<UsuarioResponse>(usuario);

                _logger.LogInformation("Se actualizó la contraseña del usuario exitosamente");
            }
            catch (Exception ex)
            {
                response.statusCode = 500;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{ex.Message}");
                return response;
            }

            response.statusCode = 200;
            response.message = "Se actualizó la contraseña del usuario exitosamente";
            response.response = usuarioResponse;
            return response;
        }
    }
}
