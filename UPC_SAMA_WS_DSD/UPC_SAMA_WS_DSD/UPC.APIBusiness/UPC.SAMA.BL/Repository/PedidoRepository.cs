using Dapper;
using DBContext;
using DBEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        public ResponseBase obtenerPedidoActivo(int IDUSUARIO)
        {
            var returnEntity = new ResponseBase();
            var entitiesPedido = new List<EntityPedido>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerPedidoActivo";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", value: IDUSUARIO, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    entitiesPedido = db.Query<EntityPedido>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesPedido.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesPedido[0];
                        returnEntity.json = JsonConvert.SerializeObject(entitiesPedido[0]);

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

        public ResponseBase registrarPedido(EntityPedido pedido)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_RegistrarPedido";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPEDIDO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@IDUSUARIO", value: pedido.IDUSUARIO, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@TOTAL_PAGAR", value: pedido.TOTAL_PAGAR, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@ESTADO", value: pedido.ESTADO, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityPedido>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    int idPedido = p.Get<int>("@IDPEDIDO");

                    if (idPedido > 0)
                    {
                        pedido.IDPEDIDO = idPedido;

                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            idPedido = idPedido,
                            idUsuario = pedido.IDUSUARIO,
                            total_pagar = pedido.TOTAL_PAGAR,
                            estado = pedido.ESTADO
                        };
                        returnEntity.json = JsonConvert.SerializeObject(pedido);
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

        public ResponseBase adicionarProductos(EntityPedidoDetalle pedidoDetalle)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_AdicionarPedidoDetalle";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPEDIDO", value: pedidoDetalle.IDPEDIDO, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@IDPRODUCTO", value: pedidoDetalle.IDPRODUCTO, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@CANTIDAD", value: pedidoDetalle.CANTIDAD, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIOUNITARIO", value: pedidoDetalle.PRECIOUNITARIO, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@EXITO", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                    db.Query<EntityPedidoDetalle>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    bool exito = p.Get<bool>("@EXITO");

                    if (exito)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            idPedido = pedidoDetalle.IDPEDIDO,
                            idProducto = pedidoDetalle.IDPRODUCTO,
                            cantidad = pedidoDetalle.CANTIDAD,
                            precioUnitario = pedidoDetalle.PRECIOUNITARIO
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

        public ResponseBase disminuirProductos(EntityPedidoDetalle pedidoDetalle)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_DisminuirPedidoDetalle";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPEDIDO", value: pedidoDetalle.IDPEDIDO, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@IDPRODUCTO", value: pedidoDetalle.IDPRODUCTO, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@EXITO", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                    db.Query<EntityPedidoDetalle>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    bool exito = p.Get<bool>("@EXITO");

                    if (exito)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            idPedido = pedidoDetalle.IDPEDIDO,
                            idProducto = pedidoDetalle.IDPRODUCTO,
                            cantidad = pedidoDetalle.CANTIDAD,
                            precioUnitario = pedidoDetalle.PRECIOUNITARIO
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

        public ResponseBase listarPedidoDetalle(int IDPEDIDO)
        {
            var returnEntity = new ResponseBase();
            var entitiesPedidoDetalle = new List<EntityPedidoDetalle>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarPedidoDetalle";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDPEDIDO", value: IDPEDIDO, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    entitiesPedidoDetalle = db.Query<EntityPedidoDetalle>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesPedidoDetalle.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesPedidoDetalle;
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

        public ResponseBase pagarPedido(EntityPedido pedido)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_PagarPedido";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPEDIDO", value: pedido.IDPEDIDO, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@EXITO", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                    db.Query<EntityPedidoDetalle>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    bool exito = p.Get<bool>("@EXITO");

                    if (exito)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            idPedido = pedido.IDPEDIDO
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
