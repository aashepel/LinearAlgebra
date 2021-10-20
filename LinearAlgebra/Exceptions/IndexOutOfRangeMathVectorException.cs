using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    /// <summary>
    /// Исключение. Обращение к несуществующему элементу вектора
    /// </summary>
    public class IndexOutOfRangeMathVectorException : LinearAlgebraBaseException
    {
        private const string _description = "Index was out of range";
        /// <summary>
        /// Описание
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
