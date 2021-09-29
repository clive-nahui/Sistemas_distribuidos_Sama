using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IUserRepository
    {
        ResponseBase getUsuarios();
        ResponseBase getUsuario(string codigo);
        ResponseBase Login(EntityLogin login);
        ResponseBase Insert(EntityUser user);
        ResponseBase Update(EntityUser usuario);
        ResponseBase Delete(EntityUser usuario);
    }
}
