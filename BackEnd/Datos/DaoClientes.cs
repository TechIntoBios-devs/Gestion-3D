using Entidades;
using Npgsql;
using NpgsqlTypes;

namespace Datos;

public class DaoClientes
{
    private readonly AccesoDatos accesoDatos;
    private const string cliente = "sp_AgregarCliente";


    public DaoClientes(AccesoDatos datos) => accesoDatos = datos;

    public async Task<bool> agregarCliente(Clientes clientes)
    {
        var command = new NpgsqlCommand();
        armarParametrosAgregarCliente(command, clientes);
        return await accesoDatos.ejecutarProcedimientoAlmacenado(command, cliente) > 0;
    }

    public void armarParametrosAgregarCliente(NpgsqlCommand command, Clientes clientes)
    {
        command.Parameters.Add("@NOMBRE", NpgsqlDbType.Varchar, 100).Value = clientes.Nombre;
        command.Parameters.Add("@APELLIDO", NpgsqlDbType.Varchar, 100).Value = clientes.Apellido;
        command.Parameters.Add("@CORREO", NpgsqlDbType.Varchar, 300).Value = clientes.Correo; 
        command.Parameters.Add("@ZONA", NpgsqlDbType.Varchar, 100).Value = clientes.Zona; 
        command.Parameters.Add("@TELEFONO", NpgsqlDbType.Varchar, 20).Value = clientes.Telefono;
    }
}