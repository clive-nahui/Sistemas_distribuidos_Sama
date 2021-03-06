using Dapper;
using DBEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DBContext
{
    public class ProductoRepository : BaseRepository, IProductoRepository
    {
        public ResponseBase getProductosxCategoria(int IDCATEGORIA)
        {
            var returnEntity = new ResponseBase();
            var entitiesProductos = new List<EntityProducto>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Productos_X_Categoria";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDCATEGORIA", value: IDCATEGORIA, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    entitiesProductos = db.Query<EntityProducto>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesProductos.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesProductos;
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

        public ResponseBase getProductos()
        {
            var returnEntity = new ResponseBase();
            var entitiesProductos = new List<EntityProducto>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Productos";
                    
                    entitiesProductos = db.Query<EntityProducto>(sql: sql, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesProductos.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesProductos;
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

        public ResponseBase getProducto(int IDPRODUCTO)
        {
            var returnEntity = new ResponseBase();
            var entitiesProductos = new List<EntityProducto>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Obtener_Producto";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDPRODUCTO", value: IDPRODUCTO, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    entitiesProductos = db.Query<EntityProducto>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesProductos.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesProductos;
                        returnEntity.json = JsonConvert.SerializeObject(entitiesProductos[0]);
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

        public ResponseBase Insert(EntityProducto producto)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Insertar_Producto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPRODUCTO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@IDCATEGORIA", value: producto.IDCATEGORIA, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRE", value: producto.NOMBRE, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@URLIMAGEN", value: producto.URLIMAGEN, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIO", value: producto.PRECIO, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@DESCRIPCION", value: producto.DESCRIPCION, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: producto.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityProject>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    int idProducto = p.Get<int>("@IDPRODUCTO");

                    if (idProducto > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            id = idProducto,
                            idCategoria = producto.IDCATEGORIA,
                            nombre = producto.NOMBRE,
                            urlimagen = producto.URLIMAGEN,
                            precio = producto.PRECIO,
                            descripcion = producto.DESCRIPCION
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

        public ResponseBase Update(EntityProducto producto)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Actualizar_Producto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPRODUCTO", value: producto.IDPRODUCTO, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@IDCATEGORIA", value: producto.IDCATEGORIA, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRE", value: producto.NOMBRE, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@URLIMAGEN", value: producto.URLIMAGEN, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIO", value: producto.PRECIO, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@DESCRIPCION", value: producto.DESCRIPCION, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOMODIFICA", value: producto.UsuarioModifica, dbType: DbType.Int32, direction: ParameterDirection.Input);
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
                            id = producto.IDPRODUCTO,
                            idCategoria = producto.IDCATEGORIA,
                            nombre = producto.NOMBRE,
                            urlimagen = producto.URLIMAGEN,
                            precio = producto.PRECIO,
                            descripcion = producto.DESCRIPCION
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

        public ResponseBase Delete(EntityProducto producto)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Eliminar_Producto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPRODUCTO", value: producto.IDPRODUCTO, dbType: DbType.Int32, direction: ParameterDirection.Input);
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
                            id = producto.IDPRODUCTO
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
