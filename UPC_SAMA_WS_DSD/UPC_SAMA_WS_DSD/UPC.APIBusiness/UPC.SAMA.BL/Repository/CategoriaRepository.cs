using Dapper;
using DBContext;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        public ResponseBase getCategorias()
        {
            var returnEntity = new ResponseBase();
            var entitiesCategorias = new List<EntityCategoria>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Categorias";
                    entitiesCategorias = db.Query<EntityCategoria>(sql: sql, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesCategorias.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesCategorias;
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

        public ResponseBase getCategoria(int IDCATEGORIA)
        {
            var returnEntity = new ResponseBase();
            var entitiesCategorias = new List<EntityCategoria>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Obtener_Categoria";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDCATEGORIA", value: IDCATEGORIA, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    entitiesCategorias = db.Query<EntityCategoria>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesCategorias.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesCategorias;
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

        public ResponseBase Insert(EntityCategoria categoria)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Insertar_Categoria";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDCATEGORIA", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@NOMBRE", value: categoria.NOMBRE, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@URLIMAGEN", value: categoria.URLIMAGEN, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: categoria.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityProject>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    int idCategoria = p.Get<int>("@IDCATEGORIA");

                    if (idCategoria > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            id = idCategoria,
                            nombre = categoria.NOMBRE,
                            urlimagen = categoria.URLIMAGEN
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

        public ResponseBase Update(EntityCategoria categoria)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Actualizar_Categoria";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDCATEGORIA", value: categoria.IDCATEGORIA, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRE", value: categoria.NOMBRE, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@URLIMAGEN", value: categoria.URLIMAGEN, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: categoria.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);
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
                            id = categoria.IDCATEGORIA,
                            nombre = categoria.NOMBRE,
                            urlimagen = categoria.URLIMAGEN
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

        public ResponseBase Delete(EntityCategoria categoria)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Eliminar_Categoria";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDCATEGORIA", value: categoria.IDCATEGORIA, dbType: DbType.Int32, direction: ParameterDirection.Input);
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
                            id = categoria.IDCATEGORIA
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
    }
}
