using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    public class LinearAlgebraBaseException : Exception
    {
        private const string _description = "Что-то пошло не так...";
        public virtual string Description
        {
            get
            {
                return _description;
            }
        }
    }
}
