using Entidades;
using Npgsql;
using NpgsqlTypes;

namespace Datos;

public class DaoProductos
{
    private readonly AccesoDatos accesoDatos;
    private const string Productos = "sp_AgregarProducto";
    private const string existe_producto = "SELECT EXISTS (SELECT 1 FROM Productos WHERE Id_Categoria_Prod = @ID_CATEGORIA, LOWER(Nombre_Prod) = LOWER(@NOMBRE)"; 

    public DaoProductos (AccesoDatos datos) => accesoDatos = datos;
    
    public async Task<bool> agreagrProducto (Productos productos)
    {
        var command = new NpgsqlCommand();
        armarParametrosAgregarProducto(command,productos);
        return await accesoDatos.ejecutarProcedimientoAlmacenado(command,Productos) != 0;
    }

    public async Task<bool> existeProducto(Productos productos)
    {
        var command = new NpgsqlCommand(); 
        command.Parameters.Add("@ID_CATEGORIA", NpgsqlDbType.Integer).Value = productos.Id_categoria; 
        command.Parameters.Add("@NOMBRE", NpgsqlDbType.Varchar, 100).Value = productos.Nombre; 
        return await accesoDatos.existe("", command); 
    }

    public void armarParametrosAgregarProducto(NpgsqlCommand command, Productos productos)
    {
        command.Parameters.Add("@ID_CATEGORIA", NpgsqlDbType.Integer).Value = productos.Id_categoria;
        command.Parameters.Add("@NOMBRE",NpgsqlDbType.Varchar,100).Value = productos.Nombre;
        command.Parameters.Add("@PRECIO",NpgsqlDbType.Numeric).Value = productos.Precio;
    }

    //     public async Task<List<Productos>> obtenerProductos(String consulta)
    // {
    //     var lista = new List<Productos>();

    //     using var connection = await obtenerConexion();
    //     using var command = new SqlCommand(consulta, connection);
    //     using var reader = await command.ExecuteReaderAsync();

    //     while(await reader.ReadAsync())
    //     {
    //         var prod = new Productos{
    //             IdProductos = reader.GetInt32(0),
    //             NombreProducto = reader.IsDBNull(1) ? "No contiene" : reader.GetString(1)
    //         };

    //         lista.Add(prod);
    //     }

    //     return lista; 

    // }
}