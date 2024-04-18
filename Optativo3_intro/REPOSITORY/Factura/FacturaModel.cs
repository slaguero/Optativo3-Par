using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Facturas
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public int idCliente { get; set; }
        public string nroFactura { get; set; }
        public decimal total { get; set; }
        public decimal totalIva5 { get; set; }
        public decimal totalIva10 { get; set; }
        public decimal totalIva { get; set; }
        public string totalLetras { get; set; }
        public DateTime fechaHora { get; set; }
        public string sucursal { get; set; }
    }
}