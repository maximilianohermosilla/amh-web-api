﻿namespace Application.DTO.GestorGastos
{
    public class CuentaRequest
    {
        public string? Nombre { get; set; }
        public int IdTipoCuenta { get; set; }
        public int? IdTarjeta { get; set; }
        public int IdUsuario { get; set; }
        public bool? Habilitado { get; set; }
    }
}
