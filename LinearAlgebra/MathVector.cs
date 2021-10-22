using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LinearAlgebra.Exceptions;
using System.Globalization;

namespace LinearAlgebra
{
    public class MathVector : IMathVector
    {
		/// <summary>
		/// Protected конструктор для использования внутри методов класса
		/// Количество точек должно быть положительным
		/// </summary>
		/// <param name="count">Количество точек</param>
		/// <exception cref="WrongSizeVectorException">Бросается исключение, если передаваемый размер меньше или равен нулю</exception>
		protected MathVector(int count)
		{
			if (count <= 0)
            {
				throw new WrongSizeVectorException();
            }
			_dimensions = count;
			_points = new double[_dimensions];///вектор
			for (int i = 0; i < _dimensions; i++)
            {
				_points[i] = 0;
			}
		}

		/// <summary>
		/// Конструктор копирования
		/// Количество точек в векторе должно быть положительным
		/// </summary>
		/// <param name="vector">Передаваемый в конструктор вектор</param>
		/// <exception cref="WrongSizeVectorException">Бросается исключение, если передаваемый размер меньше или равен нулю</exception>
		public MathVector(IMathVector vector)
        {
			if (vector.Dimensions <= 0)
            {
				throw new WrongSizeVectorException();
            }
            _points = new double[vector.Dimensions];
			_dimensions = vector.Dimensions;
            for (int i = 0; i < vector.Dimensions; ++i)
			{
				_points[i] = vector[i];
			}
		}

		/// <summary>
		/// Конструктор, принимаемый в качестве параметров массив точек произвольной длины
		/// Количество точек должно быть положительным
		/// </summary>
		/// <param name="points"></param>
		/// <exception cref="WrongSizeVectorException">Бросается исключение, если передаваемый размер меньше или равен нулю</exception>
		public MathVector(double[] points)
        {
			if (points.Length <= 0)
            {
				throw new WrongSizeVectorException();
            }
			_points = new double[points.Length];
			_dimensions = points.Length;
			for (int i = 0; i < _dimensions; i++)
            {
				_points[i] = points[i];
            }
		}

		/// <summary>
		/// Количство координат вектора
		/// </summary>
		private int _dimensions;

		/// <summary>
		/// Массив точек вектора
		/// </summary>
		private double[] _points;

		/// <summary>
		/// Длина вектора
		/// </summary>
		private double _length = 0;

		/// <summary>
		/// Свойство для получения длины (модуля) вектора
		/// </summary>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
		public double Length
		{
			get
			{
				CalculateLength();
				return _length;
			}
		}

		/// <summary>
		/// Метод для вычисления длины вектора
		/// </summary>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
        private void CalculateLength()
        {
            _length = 0;
            for (int i = 0; i < _dimensions; i++)
            {
                _length += Math.Pow(_points[i], 2);
				if (Double.IsInfinity(_length))
                {
					throw new InfinityDoubleVectorsException();
                }
            }
            _length = Math.Sqrt(_length);
		}

		/// <summary>
		/// Свойство для получения количества точек вектора
		/// </summary>
        public int Dimensions
		{
			get 
			{
				return _dimensions; 
			}
		}

		/// <summary>
		/// Индексатор
		/// Нумерация с нуля. Индекс должен быть неотрицательным и не выходить за границы размерности вектора
		/// </summary>
		/// <param name="i">Индекс элемента, к которому обращаемся</param>
		/// <returns>Возвращается точка, к которой мы обращаемся по индексу</returns>
		/// <exception cref="IndexOutOfRangeMathVectorException">Бросается исключение, если элемента по заданному индексу не существует</exception>
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

		/// <inheritdoc cref="SumNumber(double)"/>
		public static IMathVector operator +(MathVector vector, double number)
		{
			return vector.SumNumber(number);
		}

		/// <inheritdoc cref="Sum(IMathVector)"/>
		public static IMathVector operator +(MathVector vector1, IMathVector vector2)
		{
			return vector1.Sum(vector2);
		}

		/// <inheritdoc cref="MultiplyNumber(double)"/>
		public static IMathVector operator *(MathVector vector1, double number)
		{
			return vector1.MultiplyNumber(number);
		}

		/// <inheritdoc cref="Multiply(IMathVector)"/>
		public static IMathVector operator *(MathVector vector1, IMathVector vector2)
		{
			return vector1.Multiply(vector2);
		}

		/// <inheritdoc cref="DivideNumber(double)"/>
		public static IMathVector operator /(MathVector vector, double number)
		{
			return vector.DivideNumber(number);
		}

		/// <inheritdoc cref="Divide(IMathVector)"/>
		public static IMathVector operator /(MathVector vector1, IMathVector vector2)
		{
			return vector1.Divide(vector2);
		}

		/// <summary>
		/// Перегрузка оператора вычитания для вектора и числа
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <param name="number">Число</param>
		/// <returns>Новый вектор</returns>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
		public static IMathVector operator -(MathVector vector, double number)
		{
			return vector.SumNumber(-number);
		}

		/// <summary>
		/// Перегрузка оператора вычитания для двух векторов
		/// </summary>
		/// <param name="vector1">Вектор 1</param>
		/// <param name="vector2">Вектор 2</param>
		/// <returns>Новый вектор</returns>
		/// <exception cref="DifferentVectorSpacesException">Бросается исключение, если размерности векторов не совпадают</exception>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
		public static IMathVector operator -(MathVector vector1, IMathVector vector2)
		{
			return vector1.Sum(vector2.MultiplyNumber(-1));
		}

		/// <inheritdoc cref="ScalarMultiply(IMathVector)"/>
		public static double operator %(MathVector vector1, IMathVector vector2)
		{
			return vector1.ScalarMultiply(vector2);
		}

		/// <summary>
		/// Покомпонентное сложение вектора с числом
		/// </summary>
		/// <param name="number">Число</param>
		/// <returns>Новый вектор</returns>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
		public IMathVector SumNumber(double number)
		{
			IMathVector resultVector = new MathVector(_dimensions);
			for (int i = 0; i < _dimensions; i++)
			{
				double currentResult = this[i] + number;
				if (Double.IsInfinity(currentResult))
                {
					throw new InfinityDoubleVectorsException();
                }
				resultVector[i] = currentResult;
			}
			return resultVector;
		}

		/// <summary>
		/// Покомпонентное сложение вектора с другим вектором
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый вектор</returns>
		/// <exception cref="DifferentVectorSpacesException">Бросается исключение, если размерности векторов не совпадают</exception>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
		public IMathVector Sum(IMathVector vector)
		{
			if (this.Dimensions != vector.Dimensions)
            {
				throw new DifferentVectorSpacesException();
            }
			IMathVector resultVector = new MathVector(_dimensions);
			for (int i = 0; i < _dimensions; i++)
			{
				double currentResult = this[i] + vector[i];
				if (Double.IsInfinity(currentResult))
                {
					throw new InfinityDoubleVectorsException();
                }
				resultVector[i] = currentResult;
			}
			return resultVector;
		}

		/// <summary>
		/// Покомпонентное умножение вектора на число
		/// </summary>
		/// <param name="number">Число</param>
		/// <returns>Новый вектор</returns>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
		public IMathVector MultiplyNumber(double number)
		{
			IMathVector resultVector = new MathVector(_dimensions);
			for (int i = 0; i < _dimensions; i++)
            {
				double currentResult = this[i] * number;
				if (Double.IsInfinity(currentResult))
                {
					throw new InfinityDoubleVectorsException();
                }
				resultVector[i] = currentResult;
			}
			return resultVector;
		}

		/// <summary>
		/// Покомпонентное умножение вектора на другой вектор
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый вектор</returns>
		/// <exception cref="DifferentVectorSpacesException">Бросается исключение, если размерности векторов не совпадают</exception>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
		public IMathVector Multiply(IMathVector vector)
		{
			if (this.Dimensions != vector.Dimensions)
			{
				throw new DifferentVectorSpacesException();
			}
			IMathVector resultVector = new MathVector(_dimensions);
			for (int i = 0; i < _dimensions; i++)
            {
				double currentResult = this[i] * vector[i];
				if (Double.IsInfinity(currentResult))
                {
					throw new InfinityDoubleVectorsException();
                }
				resultVector[i] = currentResult;
			}
			return resultVector;
		}

		/// <summary>
		/// Скалярное умножение вектора на другой вектор
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Число - результат скалярного умножения</returns>
		/// <exception cref="DifferentVectorSpacesException">Бросается исключение, если размерности векторов не совпадают</exception>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
		public double ScalarMultiply(IMathVector vector)
		{
			if (this.Dimensions != vector.Dimensions)
			{
				throw new DifferentVectorSpacesException();
			}
			double scalarMultiplyResult = 0;
			for (int i = 0; i < _dimensions; i++)
            {
				double currentResult = this[i] * vector[i];
				if (Double.IsInfinity(currentResult))
                {
					throw new InfinityDoubleVectorsException();
                }
				scalarMultiplyResult += currentResult;
			}
			return scalarMultiplyResult;
		}

		/// <summary>
		/// Вычисление Еквклидова расстояния
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Число</returns>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
		/// <exception cref="DifferentVectorSpacesException">Бросается исключение, если размерности векторов не совпадают</exception>
		public double CalcDistance(IMathVector vector)
		{
			double distance = 0;
			if (this.Dimensions != vector.Dimensions)
            {
				throw new DifferentVectorSpacesException();
            }
			for (int i = 0; i < _dimensions; i++)
            {
				distance += Math.Pow(this[i] - vector[i], 2);
				if (Double.IsInfinity(distance))
                {
					throw new InfinityDoubleVectorsException();
                }					
			}
			return Math.Sqrt(distance);
		}

		/// <summary>
		/// Покомпонентное деление вектора на число
		/// Делитель не должен быть равным нулю
		/// </summary>
		/// <param name="number">Число, не равное нулю</param>
		/// <returns>Новый вектор</returns>
		/// <exception cref="DivideByZeroMathVectorException">Бросается исключение, если передаваемое число равно нулю</exception>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
		public IMathVector DivideNumber(double number)
		{
			if (number == 0)
			{
				throw new DivideByZeroMathVectorException();
			}
			IMathVector resultVector = new MathVector(this.Dimensions);
			for (int i = 0; i < this.Dimensions; i++)
			{
				double currentResult = this[i] / number;
				if (Double.IsInfinity(currentResult))
                {
					throw new InfinityDoubleVectorsException();
                }
				resultVector[i] = currentResult;
			}
			return resultVector;
		}

		/// <summary>
		/// Покомпонентное деление вектора на другой вектор
		/// Элементы делителя не должны быть равными нулю
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый вектор</returns>
		/// <exception cref="DifferentVectorSpacesException">Бросается исключение, если размерности векторов не совпадают</exception>
		/// <exception cref="DivideByZeroMathVectorException">Бросается исключение, один из элементов передаваемого вектора равен нулю</exception>
		/// <exception cref="InfinityDoubleVectorsException">Бросается исключение, если в результате вычисления происходит переаолнение</exception>
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
				double currentResult = this[i] / vector[i];
				if (Double.IsInfinity(currentResult))
                {
					throw new InfinityDoubleVectorsException();
                }
				resultVector[i] = currentResult;
			}
			return resultVector;
		}

		/// <summary>
		/// Переопределенный метод для получения информации о векторе в виде одной строки
		/// </summary>
		/// <returns>Строка с элементами вектора</returns>
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
			return _points.GetEnumerator();
        }

		/// <summary>
		/// Переопределенный метод для покомпонентного сравнения двух векторов
		/// </summary>
		/// <param name="obj">Вектор</param>
		/// <returns>Истина или ложь</returns>
        public override bool Equals(object obj)
        {
			IMathVector vector = obj as MathVector;
            if (this.Dimensions != vector.Dimensions)
            {
				return false;
            }
			for (int i = 0; i < this.Dimensions; i++)
            {
				if (!this[i].Equals(vector[i]))
                {
					return false;
                }
            }
			return true;
        }
    }
}
