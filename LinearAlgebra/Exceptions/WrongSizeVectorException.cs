using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    public class WrongSizeVectorException : LinearAlgebraBaseException
    {
        private const string _desription = "Неправильно заданный размер вектора";
        public override string Description
        { 
            get
            {
                return _desription;
            }
        }
    }
}
