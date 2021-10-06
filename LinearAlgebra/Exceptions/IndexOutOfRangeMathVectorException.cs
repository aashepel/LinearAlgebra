using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    public class IndexOutOfRangeMathVectorException : LinearAlgebraBaseException
    {
        private const string _description = "Index was out of range";
        public override string Description
        {
            get
            {
                return _description;
            }
        }
    }
}
