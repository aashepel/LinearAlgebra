using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LinearAlgebraLogger;

namespace LinearAlgebra
{
    public class MathVector : IMathVector
    {
		public MathVector(int count, string name)
		{
			_dimensions = count;
			_points = new double[_dimensions];///вектор
			Name = name;
			for (int i = 0; i < _dimensions; i++)
            {
				_points[i] = 0;
			}
			Logger.LogInfo($"The vector ({Name}) was created successfully");
			CalculateLength();
		}
		public MathVector(IMathVector vector, string name)
        {
            _points = new double[vector.Dimensions];
			_dimensions = vector.Dimensions;
            for (int i = 0; i < vector.Dimensions; ++i)
			{
				_points[i] = vector[i];
			}
			Name = name;
			Logger.LogInfo($"The {vector.GetType().Name}({Name}) was created successfully");
			CalculateLength();
		}

		public MathVector(double[] points, string name)
        {
			_points = new double[points.Length];
			_dimensions = points.Length;
			Name = name;
			for (int i = 0; i < _dimensions; i++)
            {
				_points[i] = points[i];
            }
			Logger.LogInfo($"The {this.GetType().Name}({Name}) was created successfully");
			CalculateLength();
		}

		private static int _dimensions; ///кол-во координат
		private double[] _points;
		private double _length = 0;
		public string Name { get; set; }
		public double Length
		{
			get
			{
				double length = 0;
				for (int i = 0; i < _dimensions; i++)
                {
					length += Math.Pow(_points[i], 2);
				}
				_length = Math.Sqrt(length);
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
				return _points[i]; 
			}
			set 
			{
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
			for (int i = 0; i < _dimensions; i++)
            {
				vector[i] = vector[i] / x;
			}
			return vector;
		}
		public static IMathVector operator /(MathVector vector1, MathVector vector2)
		{
			for (int i = 0; i < _dimensions; i++)
            {
				vector1[i] = vector1[i] / vector2[i];
			}
			return vector1;
		}
		public static IMathVector operator -(MathVector vector, double number)
		{
			for (int i = 0; i < _dimensions; i++)
            {
				vector[i] = vector[i] - number;
			}
			return vector;
		}
		public static IMathVector operator -(MathVector vector1, MathVector vector2)
		{
			for (int i = 0; i < _dimensions; i++)
			{
				vector1[i] = vector1[i] - vector2[i];
			}
			return vector1;
		}
		public static double operator %(MathVector vector1, MathVector vector2)
		{
			return vector1.ScalarMultiply(vector2);
		}
		

		public IMathVector SumNumber(double number)
		{
			MathVector z = new MathVector(_dimensions, $"{this.GetType().Name}({Name}) + number({number})");
			for (int i = 0; i < _dimensions; i++)
			{
				z[i] = this[i] + number;
			}
			return z;
		}
		public IMathVector Sum(IMathVector vector)
		{
			MathVector z = new MathVector(_dimensions, $"{this.GetType().Name}({Name}) + {vector}({vector.Name})");
			for (int i = 0; i < _dimensions; i++)
			{
				z[i] = this[i] + vector[i];
			}
			return z;
		}
		public IMathVector MultiplyNumber(double number)
		{
			MathVector z = new MathVector(_dimensions, $"{this.GetType().Name}({Name}) * number({number})");
			for (int i = 0; i < _dimensions; i++)
            {
				z[i] = this[i] * number;
			}
			return z;
		}
		public IMathVector Multiply(IMathVector vector)
		{
			MathVector z = new MathVector(_dimensions, $"{this.GetType().Name}({Name}) * {vector}({vector.Name})");
			for (int i = 0; i < _dimensions; i++)
            {
				z[i] = this[i] * vector[i];
			}
			return z;
		}
		public double ScalarMultiply(IMathVector vector)
		{
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
		public static void Print(IMathVector vector)
		{
			string line = "{ ";
			for (int i = 0; i < _dimensions; i++)
            {
				if (i + 1 == _dimensions)
                {
					line += $"{vector[i]}";
				}
				else
                {
					line += $"{vector[i]}, ";
				}
			}
			line += " }";
			Logger.LogInfo($"Print {vector.GetType().Name}({vector.Name}): {line}");
		}

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

		// Static methods

		public static void PrintLength(IMathVector vector)
        {
			Logger.LogInfo($"Length {vector.GetType().Name}({vector.Name}) = {vector.Length}");
        }
    }
}
