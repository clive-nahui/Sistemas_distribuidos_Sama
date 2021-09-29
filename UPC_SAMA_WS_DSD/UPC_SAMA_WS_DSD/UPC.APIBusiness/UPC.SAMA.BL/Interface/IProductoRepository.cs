using DBEntity;

namespace DBContext
{
    public interface IProductoRepository
    {
        ResponseBase getProductosxCategoria(int IDCATEGORIA);
        ResponseBase getProductos();
        ResponseBase getProducto(int IDPRODUCTO);
        ResponseBase Insert(EntityProducto producto);
        ResponseBase Update(EntityProducto producto);
        ResponseBase Delete(EntityProducto producto);
    }
}
