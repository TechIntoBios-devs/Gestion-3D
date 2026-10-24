using System.Data;
using Entidades;
using Npgsql;
using NpgsqlTypes; 

namespace Datos; 

public class DaoPedidos
{
    private readonly AccesoDatos accesoDatos; 
    private const string Pedido = "sp_AgregarPedido"; 

    public DaoPedidos(AccesoDatos datos) => accesoDatos = datos;

    public async Task<bool> agregarPedido(Pedidos pedidos)
    {
        var command = new NpgsqlCommand(); 
        armarParametrosAgregarPedido(command, pedidos); 
        return await accesoDatos.ejecutarProcedimientoAlmacenado(command, Pedido) != 0; 
    }

    public void armarParametrosAgregarPedido(NpgsqlCommand command, Pedidos pedidos)
    {
        command.Parameters.Add("ID_CLIENTE", NpgsqlDbType.Uuid).Value = pedidos.IdCliente; 
        command.Parameters.Add("ID_ESTADO", NpgsqlDbType.Integer).Value = pedidos.IdEstadoPedido; 
        command.Parameters.Add("NUMERO", NpgsqlDbType.Integer).Value = pedidos.Numero;
        command.Parameters.Add("NOTA", NpgsqlDbType.Varchar, 300).Value = pedidos.Nota; 
        command.Parameters.Add("SEGUIMIENTO", NpgsqlDbType.Varchar, 300).Value = pedidos.Seguimiento; 
        command.Parameters.Add("FECHA", NpgsqlDbType.TimestampTz).Value = pedidos.Fecha; 
    }
}