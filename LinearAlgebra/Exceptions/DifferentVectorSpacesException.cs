using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    public class DifferentVectorSpacesException : LinearAlgebraBaseException
    {
        private const string _description = "Разные пространства векторов";
        public override string Description
        { 
            get
            {
                return _description;
            }
        }
    }
}
