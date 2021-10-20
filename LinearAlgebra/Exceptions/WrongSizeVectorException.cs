using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    /// <summary>
    /// Исключение. Неправильно заданный размер вектора
    /// </summary>
    public class WrongSizeVectorException : LinearAlgebraBaseException
    {
        private const string _desription = "Неправильно заданный размер вектора";
        /// <summary>
        /// Описание
        /// </summary>
        public override string Description
        { 
            get
            {
                return _desription;
            }
        }
    }
}
