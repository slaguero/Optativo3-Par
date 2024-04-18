using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Repository.Data.ConfiguracionesDB;

namespace Repository.Data.Clientes
{
    public class ClienteRepository
    {
        NpgsqlConnection connection;
        public ClienteRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(ClienteModel clienteModel)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO cliente(id, id_banco, nombre, apellido, documento, direccion, mail, celular,  estado) " +
                    $"Values(" +
                    $"'{clienteModel.Id}', " +
                    $"'{clienteModel.Id}', " +
                    $"'{clienteModel.nombre}', " +
                    $"'{clienteModel.apellido}'," +
                    $"'{clienteModel.cedula}'," +
                    $"'{clienteModel.direccion}'," +
                    $"'{clienteModel.correo}'," +
                    $"'{clienteModel.celular}'," +
                    $"'{clienteModel.estado}')";
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClienteModel> list()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM cliente";
            var list = cmd.ExecuteReader();


            while (list.Read())
            {
                clientes.Add(new ClienteModel
                {
                    nombre = list.GetString(3),
                    apellido = list.GetString(4),
                    cedula = list.GetDecimal(5),
               // cedula = list.GetString(5).ToString(),
                    correo = list.GetString(7),
                    direccion = list.GetString(6),
                    estado = list.GetString(9)
                });
            }

            return clientes;
        }

        public bool Remove(int id)
        {

            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Cliente SET Estado = 'inactivo' WHERE Id = @Id";
                cmd.ExecuteReader();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(ClienteModel cliente)
        {

            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Cliente SET Id_banco = @IdBanco, Nombre = @nombre, Apellido = @apellido, Documento = @cedula, Direccion = @direccion, Email = @correo, Celular = @Celular, Estado = @Estado WHERE Id = @Id";
                cmd.ExecuteReader();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}