using Repository.Data.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class ClienteService
    {
        private ClienteRepository clienteRepository;
        public ClienteService(string connectionString)
        {
            clienteRepository = new ClienteRepository(connectionString);
        }

        public bool insertar(ClienteModel cliente)
        {
            if (validarDatos(cliente))
                return clienteRepository.add(cliente);
            else
                throw new Exception("Error en la validación de datos, favor corroborar");
        }

        public List<ClienteModel> listado()
        {
            return clienteRepository.list();
        }

        private bool validarDatos(ClienteModel cliente)
        {
            if (cliente == null)
                return false;
            if (string.IsNullOrEmpty(cliente.nombre) && cliente.nombre.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.apellido) && cliente.apellido.Length < 3)
                return false;
            if (cliente.cedula.ToString().Length < 10 && cliente.cedula !=null)
                return false;
            if (cliente.celular.ToString().Length < 10)
                return false;

            return true;
        }
    }
}