using System;
using System.Collections.Generic;
using Entidad;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Dapper;
using System.Linq;

namespace Repositorio
{

    public class ProductoDAO : UtilitarioBD
    {
        

        public Response<List<Producto>> Listar()
        {
            Response<List<Producto>> response = new Response<List<Producto>>();
            List<Producto> list = new List<Producto>();
            string query = "SELECT Codigo , Nombre, Descripcion, Marca FROM Producto";
            try
            {
                using (var cn = this.Connection)
                {
                    list = cn.Query<Producto>(query, commandType: CommandType.Text).ToList();
                }

                response.value = list;
            }
            catch (Exception ex)
            {
                response.status = "error";
                response.errorNumber = ex.GetType().FullName;
                throw ex;
            }

            return response;
        }





        public Response<List<Producto>> BuscarId(int id)
        {
            Response<List<Producto>> response = new Response<List<Producto>>();

            List<Producto> list = new List<Producto>();
            string query = "SELECT Codigo , Nombre, Descripcion, Marca FROM Producto where Codigo = "+ id;
            try
            {               

                using (var cn = this.Connection)
                {
                    list = cn.Query<Producto>(query, commandType: CommandType.Text).ToList();
                }

                response.value = list;

            }
            catch (Exception ex)
            {
                response.status = "error";
                response.errorNumber = ex.GetType().FullName;
                throw ex;
            }

            return response;
        }






        public Response<int> Insertar(Producto entidad)
        {
            Response<int> response = new Response<int>();
            string query = "St_InsertarDatos";
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Nombre",entidad.Nombre);
                parameters.Add("@Descripcion", entidad.Descripcion);
                parameters.Add("@Marca", entidad.Marca);

                using (var cn = this.Connection)
                {
                    response.value = cn.Execute(query, parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                response.status = "error";
                response.errorNumber = ex.GetType().FullName;
                throw ex;
            }

            return response;
        }

        public Response<int> Actualizar(Producto entidad)
        {
            Response<int> response = new Response<int>();
            string query = "St_ActualizarProducto";
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Codigo", entidad.Codigo);
                parameters.Add("@Nombre", entidad.Nombre);
                parameters.Add("@Descripcion", entidad.Descripcion);
                parameters.Add("@Marca", entidad.Marca);

                using (var cn = this.Connection)
                {
                    response.value = cn.Execute(query, parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                response.status = "error";
                response.errorNumber = ex.GetType().FullName;
                throw ex;
            }

            return response;
        }

        public Response<int> Eliminar(int id)
        {
            Response<int> response = new Response<int>();
            string query = "SpEliminarProducto";
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Codigo", id);               
                using (var cn = this.Connection)
                {
                    response.value = cn.Execute(query, parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                response.status = "error";
                response.errorNumber = ex.GetType().FullName;
                throw ex;
            }

            return response;
        }
    }
}
