using DBEntity;

namespace DBContext
{
    public interface IProductoRepository
    {
        ResponseBase getProductosxCategoria(int IDCATEGORIA);
        ResponseBase getProducto(int IDPRODUCTO);
        ResponseBase Insert(EntityProducto producto);
    }
}
