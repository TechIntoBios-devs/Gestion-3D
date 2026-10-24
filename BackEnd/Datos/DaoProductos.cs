using Entidades;
using Npgsql;
using NpgsqlTypes;

namespace Datos;

public class DaoProductos
{
    private readonly AccesoDatos accesoDatos;
    private const string  Productos = "sp_AgregarProducto";

    public DaoProductos (AccesoDatos datos) => accesoDatos = datos;
    
    public async Task<bool> agreagrProducto (Productos productos)
    {
        var command = new NpgsqlCommand();
        armarParametrosAgregarProducto(command,productos);
        return await accesoDatos.ejecutarProcedimientoAlmacenado(command,Productos) != 0;
    }
    
    public void armarParametrosAgregarProducto(NpgsqlCommand command, Productos productos)
    {
    command.Parameters.Add("@ID_CATEGORIA", NpgsqlDbType.Integer).Value = productos.Id_categoria;
    command.Parameters.Add("@NOMBRE",NpgsqlDbType.Varchar,100).Value = productos.Nombre;
    command.Parameters.Add("@PRECIO",NpgsqlDbType.Numeric).Value = productos.Precio;
    }
}