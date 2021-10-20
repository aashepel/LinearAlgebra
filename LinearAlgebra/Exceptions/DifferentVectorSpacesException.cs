using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    /// <summary>
    /// Исключение. Разные размерности двух векторов
    /// </summary>
    public class DifferentVectorSpacesException : LinearAlgebraBaseException
    {
        private const string _description = "Разные пространства векторов";
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
