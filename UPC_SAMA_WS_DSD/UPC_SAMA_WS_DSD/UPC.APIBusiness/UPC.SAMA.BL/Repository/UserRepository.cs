using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public ResponseBase Login(EntityLogin login)
        {
            var returnEntity = new ResponseBase();
            var entityUser = new EntityLoginResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Login_Usuario";

                    var p = new DynamicParameters();
                    p.Add(name: "@EMAIL", value: login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORDUSUARIO", value: login.PasswordUsuario, dbType: DbType.String, direction: ParameterDirection.Input);

                    entityUser = db.Query<EntityLoginResponse>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (entityUser != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entityUser;
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }

        public ResponseBase Insert(EntityUser usuario)
        {
            var returnEntity = new ResponseBase();
            var usuarioExistente = new ResponseBase();

            try
            {
                usuarioExistente = getUsuarioxDocumento(usuario.DocumentoIdentidad);

                if(usuarioExistente.data != null)
                {
                    throw new Exception("Ya existe un usuario con ese DNI.");
                }

                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Insertar_Usuario";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@EMAIL", value: usuario.Email, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORDUSUARIO", value: usuario.PasswordUsuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@IDPERFIL", value: usuario.IdPerfil, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRES", value: usuario.Nombres, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@APELLIDOPATERNO", value: usuario.ApellidoPaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@APELLIDOMATERNO", value: usuario.ApellidoMaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@DOCUMENTOIDENTIDAD", value: usuario.DocumentoIdentidad, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: usuario.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityUser>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    int idUsuario = p.Get<int>("@IDUSUARIO");

                    if (idUsuario > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            id = idUsuario,
                            nombre = usuario.Nombres
                        };
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }

        public ResponseBase Update(EntityUser usuario)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Actualizar_Usuario";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", value: usuario.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@EMAIL", value: usuario.Email, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORDUSUARIO", value: usuario.PasswordUsuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@IDPERFIL", value: usuario.IdPerfil, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRES", value: usuario.Nombres, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@APELLIDOPATERNO", value: usuario.ApellidoPaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@APELLIDOMATERNO", value: usuario.ApellidoMaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@DOCUMENTOIDENTIDAD", value: usuario.DocumentoIdentidad, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: usuario.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@EXITO", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                    db.Query<EntityProject>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    bool exito = p.Get<bool>("@EXITO");

                    if (exito)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            id = usuario.IdUsuario,
                            nombre = usuario.Nombres
                        };
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }
            return returnEntity;
        }

        public ResponseBase Delete(EntityUser usuario)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Eliminar_Usuario";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", value: usuario.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@EXITO", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                    db.Query<EntityProject>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    bool exito = p.Get<bool>("@EXITO");

                    if (exito)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            id = usuario.IdUsuario
                        };
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }
            return returnEntity;
        }

        public ResponseBase getUsuarios()
        {
            var returnEntity = new ResponseBase();
            var entitiesUsuarios = new List<EntityUser>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Usuarios";

                    entitiesUsuarios = db.Query<EntityUser>(sql: sql, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesUsuarios.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesUsuarios;
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }

        public ResponseBase getUsuario(string codigo)
        {
            var returnEntity = new ResponseBase();
            var entitiesUsuarios = new List<EntityUser>();
            int IDUSUARIO;

            try
            {
                if (!int.TryParse(codigo, out IDUSUARIO))
                    throw new Exception("El código debe ser numérico.");

                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Obtener_Usuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", value: IDUSUARIO, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    entitiesUsuarios = db.Query<EntityUser>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesUsuarios.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesUsuarios;
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }

        public ResponseBase getUsuarioxDocumento(string DOCUMENTOIDENTIDAD)
        {
            var returnEntity = new ResponseBase();
            var entitiesUsuarios = new List<EntityUser>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Obtener_UsuarioxDocumento";
                    var p = new DynamicParameters();
                    p.Add(name: "@DOCUMENTOIDENTIDAD", value: DOCUMENTOIDENTIDAD, dbType: DbType.String, direction: ParameterDirection.Input);
                    entitiesUsuarios = db.Query<EntityUser>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesUsuarios.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesUsuarios;
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }
    }
}