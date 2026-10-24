using Entidades;
using Npgsql;
using NpgsqlTypes;

namespace Datos;

public class DaoCategorias
{
    private readonly AccesoDatos accesoDatos;

    private const string procedimiento_categorias = "sp_AgregarCategoria";
    private const string ExisteCategorias = "SELECT EXISTS (SELECT 1 FROM Categorias WHERE Nombre_Cat = @NOMBRE)";

    public DaoCategorias(AccesoDatos datos) => accesoDatos = datos;

    public async Task<bool>AgregarCategorias(Categorias categorias)
    {
        var command = new NpgsqlCommand();
        armarParametrosAgregarCategorias(command,categorias);
        return await accesoDatos.ejecutarProcedimientoAlmacenado(command,procedimiento_categorias) != 0;
    }

    public async Task<bool>ExisteCategoria(Categorias categorias) 
    {
        var command = new NpgsqlCommand();
        command.Parameters.Add("@NOMBRE",NpgsqlDbType.Varchar,100).Value = categorias.NOMBRE;
        return await accesoDatos.existe("",command);
    }

    public void armarParametrosAgregarCategorias(NpgsqlCommand command, Categorias categorias)
    {
        command.Parameters.Add("@NOMBRE",NpgsqlDbType.Varchar,100).Value = categorias.NOMBRE;
    }


}