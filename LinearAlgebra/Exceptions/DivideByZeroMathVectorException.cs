using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    /// <summary>
    /// Исключение. Деление на ноль
    /// </summary>
    public class DivideByZeroMathVectorException : LinearAlgebraBaseException
    {
        private const string _description = "Деление на ноль невозможно";
        /// <summary>
        /// Описание ошибки
        /// </summary>
        public override string Description
        {
            get
            {
                return _description;
            }
        }
    }
}
