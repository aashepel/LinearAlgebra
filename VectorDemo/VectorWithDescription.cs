using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorDemo
{
    class VectorWithDescription
    {
        private IMathVector _vector;
        private string _description;
        private double _result;

        public VectorWithDescription(IMathVector vector, string description)
        {
            _description = description;
            _vector = vector;
        }

        public VectorWithDescription(double result, string description)
        {
            _description = description;
            _result = result;
            _vector = null;
        }
        public override string ToString()
        {
            string line = "";
            if (_vector != null)
            {
                line += $"result_: {_vector}";
            }
            else
            {
                line += $"Результат: {_result}";
            }
            line += "\n\n";
            return line;
        }
        public IMathVector Vector
        {
            get
            {
                return _vector;
            }
            set
            {
                _vector = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public double Result
        {
            get
            {
                return _result;
            }
        }
    }
}
