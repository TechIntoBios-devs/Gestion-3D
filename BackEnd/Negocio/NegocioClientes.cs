using Datos;
using Entidades;

namespace Negocio; 

public class NegocioClientes
{
    private readonly DaoClientes daoClientes;

    public NegocioClientes(DaoClientes dao) => daoClientes = dao; 

    public async Task<bool> agregarCliente(String nombre, String apellido, String correo, String zona, String telefono)
    {
        var clientes = new Clientes(); 
        clientes.Nombre = nombre;
        clientes.Apellido = apellido;
        clientes.Correo = correo; 
        clientes.Zona = zona; 
        clientes.Telefono = telefono;

        if (!await daoClientes.existeCliente(clientes))
        {
            return await daoClientes.agregarCliente(clientes);
        }

        return false; 
    }
}