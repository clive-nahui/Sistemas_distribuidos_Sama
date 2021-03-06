using DBEntity;

namespace DBContext
{
    public interface ICategoriaRepository
    {
        ResponseBase getCategorias();
        ResponseBase getCategoria(int id);
        ResponseBase Insert(EntityCategoria categoria);
        ResponseBase Update(EntityCategoria categoria);
        ResponseBase Delete(EntityCategoria categoria);
    }
}
