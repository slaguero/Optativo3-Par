// See https://aka.ms/new-console-template for more information
using Repository.Data.Clientes;
using Services.Logica;

Console.WriteLine("Hello, World!");


string connectionString = "Host=localhost;port=5432;Database=optativo3;Username=postgres;Password=1234;";
ClienteService clienteService = new ClienteService(connectionString);

Console.WriteLine("Ingrese: \n a - para insertar \n b - para listar");
string opcion = Console.ReadLine();

if (opcion == "a")
{
    clienteService.insertar(new ClienteModel
    {
        Id = 1,
        nombre = "Juan",
        apellido = "Perez Sarela",
        cedula = 456783,
        correo = "prueba@gmail.com",
        direccion = "asuncion",
        celular = "0332555",
        estado = "Activo"
    });
}
if (opcion == "b")
{
    clienteService.listado().ForEach(cliente =>
    Console.WriteLine(
        $"Nombre: {cliente.nombre} \n " +
        $"Apellido: {cliente.apellido} \n " +
        $"Cedula: {cliente.cedula} \n " +
        $"Correo {cliente.correo} \n " +
        $"Direccion: {cliente.direccion} \n " +
        $"Direccion: {cliente.celular} \n " +
        $"Estado: {cliente.estado} \n "
        )
    );
}






























