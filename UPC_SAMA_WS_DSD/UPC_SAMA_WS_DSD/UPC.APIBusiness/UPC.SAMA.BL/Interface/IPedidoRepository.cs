using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IPedidoRepository
    {
        ResponseBase obtenerPedidoActivo(int IDUSUARIO);
        ResponseBase registrarPedido(EntityPedido pedido);
        ResponseBase adicionarProductos(EntityPedidoDetalle pedidoDetalle);
        ResponseBase disminuirProductos(EntityPedidoDetalle pedidoDetalle);
        ResponseBase listarPedidoDetalle(int IDPEDIDO);
        ResponseBase pagarPedido(EntityPedido pedido);
    }
}
