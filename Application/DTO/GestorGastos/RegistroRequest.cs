﻿namespace Application.DTO.GestorGastos
{
    public class RegistroRequest
    {
        public string? Descripcion { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdSuscripcion { get; set; }
        public int IdCuenta { get; set; }
        public int? IdRegistroVinculado { get; set; }
        public int? NumeroCuota { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public int? IdUsuario { get; set; }
        public string? Observaciones { get; set; }
        public bool? Pagado { get; set; }
        public DateTime? FechaPago { get; set; }
    }
}
