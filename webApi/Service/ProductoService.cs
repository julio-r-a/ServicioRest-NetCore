using System;
using webApi.Model;

namespace Service
{
    public class ProductoService
    {
        public Response<Object> ObtenerProductosporNombre(UnidadOrganica Request)
        {
            GeneralDAO _ConfiguracionDAO = new GeneralDAO();
            Response<Object> response = new Response<Object>();

            var result = new
            {
                LstUo = _ConfiguracionDAO.ObtenerProductosxNombre(Request).value
            };

            response.value = result;
            return response;
        }
    }
}
