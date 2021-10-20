using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Exceptions
{
    /// <summary>
    /// Базовый класс исключения для проекта LinearAlgebra
    /// </summary>
    public class LinearAlgebraBaseException : Exception
    {
        private const string _description = "Что-то пошло не так...";
        /// <summary>
        /// Описание ошибки
        /// </summary>
        public virtual string Description
        {
            get
            {
                return _description;
            }
        }
    }
}
