using Datos;
using Entidades;

namespace Negocio;

public class NegocioPedidos
{

    private readonly DaoPedidos daoPedidos;

    public NegocioPedidos(DaoPedidos DaoPedidos) => daoPedidos = DaoPedidos;

    public async Task<bool>agregarProducto(Guid IdCliente, int IdEstadoPedido, int Numero, String Nota, String Seguimiento, DateTime Fecha)
    {
        var pedido = new Pedidos();

        pedido.IdCliente = IdCliente;
        pedido.IdEstadoPedido = IdEstadoPedido;
        pedido.Numero = Numero;
        pedido.Nota = Nota;
        pedido.Seguimiento = Seguimiento;
        pedido.Fecha = Fecha;

        return await daoPedidos.agregarPedido(pedido);
    }

}