using Datos;
using Entidades;

namespace Negocio;

public class NegocioCategorias
{

    private readonly DaoCategorias daoCategorias;

    public NegocioCategorias(DaoCategorias dao) => daoCategorias = dao;

    public async task<bool>AgregarCategorias(String Nombre)
    {
        var categorias = new Categorias();

        categorias.NOMBRE = Nombre;

        if(!await daoCategorias.ExisteCategoria(categorias))
        {
            return await daoCategorias.AgregarCategorias(categorias);
        }
        return false;
    }

}