using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LinearAlgebraLogger;
using LinearAlgebra.Exceptions;
using System.Globalization;

namespace LinearAlgebra
{
    public class MathVector : IMathVector
    {
		protected MathVector(int count)
		{
			if (count < 0)
            {
				throw new WrongSizeVectorException();
            }
			_dimensions = count;
			_points = new double[_dimensions];///вектор
			for (int i = 0; i < _dimensions; i++)
            {
				_points[i] = 0;
			}
			CalculateLength();
		}
		public MathVector(IMathVector vector)
        {
            _points = new double[vector.Dimensions];
			_dimensions = vector.Dimensions;
            for (int i = 0; i < vector.Dimensions; ++i)
			{
				_points[i] = vector[i];
			}
			CalculateLength();
		}

		public MathVector(double[] points)
        {
			_points = new double[points.Length];
			_dimensions = points.Length;
			for (int i = 0; i < _dimensions; i++)
            {
				_points[i] = points[i];
            }
			CalculateLength();
		}

		private int _dimensions;
		private double[] _points;
		private double _length = 0;
		public double Length
		{
			get
			{
				return _length;
			}
		}
        private void CalculateLength()
        {
            _length = 0;
            for (int i = 0; i < _dimensions; i++)
            {
                _length += Math.Pow(_points[i], 2);
            }
            _length = Math.Sqrt(_length);
		}
        public int Dimensions
		{
			get 
			{ 
				return _dimensions; 
			}
		}
		public double this[int i]
		{
			get 
			{
				if (i < 0 || i >= this.Dimensions)
                {
					throw new IndexOutOfRangeMathVectorException();
                }
				return _points[i]; 
			}
			set 
			{
				if (i < 0 || i >= this.Dimensions)
				{
					throw new IndexOutOfRangeMathVectorException();
				}
				_points[i] = value; 
			}
		}

		public static IMathVector operator +(MathVector vector, double number)
		{
			return vector.SumNumber(number);
		}
		public static IMathVector operator +(MathVector vector1, MathVector vector2)
		{
			return vector1.Sum(vector2);
		}
		public static IMathVector operator *(MathVector vector1, double number)
		{
			return vector1.MultiplyNumber(number);
		}
		public static IMathVector operator *(MathVector vector1, MathVector vector2)
		{
			return vector1.Multiply(vector2);
		}
		public static IMathVector operator /(MathVector vector, double x)
		{
			return vector.Divide(x);
		}
		public static IMathVector operator /(MathVector vector1, MathVector vector2)
		{
			return vector1.Divide(vector2);
		}
		public static IMathVector operator -(MathVector vector, double number)
		{
			return vector.SumNumber(-number);
		}
		public static IMathVector operator -(MathVector vector1, MathVector vector2)
		{
			return vector1.Sum(vector2.MultiplyNumber(-1));
		}
		public static double operator %(MathVector vector1, MathVector vector2)
		{
			return vector1.ScalarMultiply(vector2);
		}
		

		public IMathVector SumNumber(double number)
		{
			IMathVector resultVector = new MathVector(_dimensions);
			for (int i = 0; i < _dimensions; i++)
			{
				resultVector[i] = this[i] + number;
			}
			return resultVector;
		}
		public IMathVector Sum(IMathVector vector)
		{
			if (this.Dimensions != vector.Dimensions)
            {
				throw new DifferentVectorSpacesException();
            }
			IMathVector resultVector = new MathVector(_dimensions);
			for (int i = 0; i < _dimensions; i++)
			{
				resultVector[i] = this[i] + vector[i];
			}
			return resultVector;
		}
		public IMathVector MultiplyNumber(double number)
		{
			IMathVector resultVector = new MathVector(_dimensions);
			for (int i = 0; i < _dimensions; i++)
            {
				resultVector[i] = this[i] * number;
			}
			return resultVector;
		}
		public IMathVector Multiply(IMathVector vector)
		{
			if (this.Dimensions != vector.Dimensions)
			{
				throw new DifferentVectorSpacesException();
			}
			IMathVector resultVector = new MathVector(_dimensions);
			for (int i = 0; i < _dimensions; i++)
            {
				resultVector[i] = this[i] * vector[i];
			}
			return resultVector;
		}
		public double ScalarMultiply(IMathVector vector)
		{
			if (this.Dimensions != vector.Dimensions)
			{
				throw new DifferentVectorSpacesException();
			}
			double scalarMultiplyResult = 0;
			for (int i = 0; i < _dimensions; i++)
            {
				scalarMultiplyResult += this[i] * vector[i];
			}
			return scalarMultiplyResult;
		}
		public double CalcDistance(IMathVector vector)
		{
			double distance = 0;
			for (int i = 0; i < _dimensions; i++)
            {
				distance += Math.Pow(this[i] - vector[i], 2);
			}
			return distance;
		}
		public IMathVector Divide(double number)
		{
			if (number == 0)
			{
				throw new DivideByZeroMathVectorException();
			}
			IMathVector resultVector = new MathVector(this.Dimensions);
			for (int i = 0; i < this.Dimensions; i++)
			{
				resultVector[i] = this[i] / number;
			}
			return resultVector;
		}

		public IMathVector Divide(IMathVector vector)
		{
			if (vector.Dimensions != this.Dimensions)
			{
				throw new DifferentVectorSpacesException();
			}
			IMathVector resultVector = new MathVector(this.Dimensions);
			for (int i = 0; i < Dimensions; i++)
			{
				if (vector[i] == 0)
                {
					throw new DivideByZeroMathVectorException();
				}
				resultVector[i] = this[i] / vector[i];
			}
			return resultVector;
		}
        public override string ToString()
        {
			string line = "{ ";
			for (int i = 0; i < _dimensions - 1; i++)
			{
				line += $"{this[i].ToString("G", CultureInfo.InvariantCulture)}, ";
			}
			line += $"{this[Dimensions - 1].ToString("G", CultureInfo.InvariantCulture)} }}";
			return line;
		}
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
