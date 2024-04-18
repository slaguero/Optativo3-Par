using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Repository.Data.ConfiguracionesDB;
using System.Text.RegularExpressions;
using Humanizer;


namespace Repository.Data.Facturas
{
    public class FacturaRepository
    {
        NpgsqlConnection connection;
        public FacturaRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(FacturaModel FacturaModel)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO factura(id_cliente, nro_factura, fecha_hora, total, total_iva5, total_iva10, total_iva, total_letras, sucursal) " +
                    $"Values(" +
                    $"'{FacturaModel.idCliente}', " +
                    $"'{FacturaModel.nroFactura}'," +
                    $"'{FacturaModel.fechaHora}'," +
                    $"'{FacturaModel.total}'," +
                    $"'{FacturaModel.totalIva5}'," +
                    $"'{FacturaModel.totalIva10}'," +
                    $"'{FacturaModel.totalIva}'," +
                    $"'{FacturaModel.totalLetras}'," +
                    $"'{FacturaModel.sucursal}')";
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool delete(FacturaModel FacturaModel)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM factura WHERE nro_factura = " +
                    $"'{FacturaModel.nroFactura}'";
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool updateFactura(FacturaModel FacturaModel)
        {
            try
            {
                FacturaModel.totalIva5 = CalculateIva5(FacturaModel.total);
                FacturaModel.totalIva10 = CalculateIva10(FacturaModel.total);
                FacturaModel.totalIva = CalculateTotalIva(FacturaModel.total);
                FacturaModel.totalLetras = ConvertNumberToWords((int)FacturaModel.total);
                if (Update(FacturaModel))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<FacturaModel> list()
        {
            List<FacturaModel> Facturas = new List<FacturaModel>();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM factura";
            var list = cmd.ExecuteReader();


            while (list.Read())
            {
                Facturas.Add(new FacturaModel
                {
                    idCliente = list.GetInt16(1),
                    nroFactura = list.GetString(2),
                    total = list.GetDecimal(4),
                    totalIva5 = list.GetDecimal(5),
                    totalIva10 = list.GetDecimal(6),
                    totalIva = list.GetDecimal(7),
                    fechaHora = list.GetDateTime(3),
                    totalLetras = list.GetString(8),
                    sucursal = list.GetString(9)

                });
            }

            return Facturas;
        }
        public bool Update(FacturaModel factura)
        {

            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Factura SET Id_cliente = @idCliente, Nro_Factura = @nroFactura, Fecha_Hora = @fechaHora, Total = @total, Total_iva5 = @totalIva5, Total_iva10 = @totalIva10, Total_iva = @totalIva, Total_Letras = @totalLetras, Sucursal = @sucursal WHERE Id = @Id " +
                   $"'{factura.nroFactura}'";
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static string FormatnroFactura(string nroFactura)
         => $"{nroFactura[..3]}-{nroFactura.Substring(3, 3)}-{nroFactura.Substring(6, 6)}";

        public static decimal CalculateIva5(decimal amount)
            => amount * 0.05m; // 5% de IVA

        public static decimal CalculateIva10(decimal amount)
            => amount * 0.10m; // 10% de IVA


        public static decimal CalculateTotalIva(decimal amount)
        {
            decimal iva5 = CalculateIva5(amount);
            decimal iva10 = CalculateIva10(amount);
            return iva5 + iva10;
        }

        public static string ConvertNumberToWords(int number)
            => number.ToWords(new CultureInfo("es"));

    }
}
