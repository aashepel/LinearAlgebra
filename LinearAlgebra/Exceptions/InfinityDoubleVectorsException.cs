using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    public class InfinityDoubleVectorsException : LinearAlgebraBaseException
    {
        private const string _description = "При выполнении операции с точками вектора произошло переполнение";
        public override string Description
        {
            get {  return _description; }
        }
    }
}
