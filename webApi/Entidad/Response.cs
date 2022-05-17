using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidad
{
    public class Response<T>
    {
        public string status = "ok";
        public string errorNumber = "0";
        public string errorDescripcion = "";
        public T value;
    }
}
