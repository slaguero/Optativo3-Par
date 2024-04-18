using Repository.Data.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class FacturaService
    {
        private FacturaRepository facturaRepository;
        public FacturaService(string connectionString)
        {
            facturaRepository = new FacturaRepository(connectionString);
        }

        public bool insertar(FacturaModel factura)
        {
            if (validarDatos(factura))
                return facturaRepository.add(factura);
            else
                throw new Exception("Error en la validación de datos, favor corroborar");
        }

        public List<FacturaModel> listado()
        {
            return facturaRepository.list();
        }

        private bool validarDatos(FacturaModel factura)
        {
            if (factura == null)
                return false;
            if (string.IsNullOrEmpty(factura.nroFactura))
                return false;
            // Validación del patrón del número de factura
            if (!Regex.IsMatch(factura.nroFactura, @"^\d{3}-\d{3}-\d{6}$"))
                return false;
            // Validación de campos numéricos obligatorios
            if (factura.total == null || factura.totalIva5 == null || factura.totalIva10 == null || factura.totalIva == null)
                return false;

            // Validación del campo Total en letras
            if (string.IsNullOrEmpty(factura.totalLetras) || factura.totalLetras.Length < 6)
                return false;

            return true;
        }
    }
}