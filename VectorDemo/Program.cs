using LinearAlgebra;
using System;
using System.Threading.Tasks;
using LinearAlgebra.Exceptions;
using LinearAlgebraLogger;

namespace VectorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IMathVector vector1 = new MathVector(new double[] { 10, -2, 3, 0 });
            IMathVector vector2 = new MathVector(new double[] { 1, 2, -5, 6 });
            vector1[0] = 0;
            string vector1ConcatVector2Values = $"vector1: {vector1} \nvector2: {vector2}";
            Logger.LogDebug(vector1ConcatVector2Values);
            VectorWithDescription[] resultMathVectors = new VectorWithDescription[15];
            resultMathVectors[0] = new VectorWithDescription((MathVector)vector1 + (MathVector)(vector2), "Сложение двух векторов при помощи перегрузки оператора");
            resultMathVectors[1] = new VectorWithDescription(vector1.Sum(vector2), "Сложение двух векторов с помощью метода Sum");
            resultMathVectors[2] = new VectorWithDescription((MathVector)vector1 + 5, "Сложение вектора с числом 5 при помощи перегрузки оператора");
            resultMathVectors[3] = new VectorWithDescription(vector1.SumNumber(5), "Сложение вектора с числом 5 с помощью метода SumNumber");
            resultMathVectors[4] = new VectorWithDescription((MathVector)vector1 * (MathVector)(vector2), "Умножение двух векторов при помощи перегрузки оператора");
            resultMathVectors[5] = new VectorWithDescription(vector1.Multiply(vector2), "Умножение двух векторов с помощью метода Multiply");
            resultMathVectors[6] = new VectorWithDescription((MathVector)vector1 * 5, "Умножение вектора на число 5 при помощи перегрузки оператора");
            resultMathVectors[7] = new VectorWithDescription((MathVector)vector1.MultiplyNumber(5), "Умножение вектора на число 5 при помощи метода MultiplyNumber");
            resultMathVectors[8] = new VectorWithDescription((MathVector)vector1 % (MathVector)vector2, "Скалярное умножение вектора при помощи перегрузки оператора");
            resultMathVectors[8] = new VectorWithDescription(vector1.ScalarMultiply(vector2), "Скалярное умножение вектора при помощи метода ScalarMultiply");
            resultMathVectors[9] = new VectorWithDescription(vector1.CalcDistance(vector2), "Расстояние до vector2");
            resultMathVectors[10] = new VectorWithDescription((vector1 as MathVector) / (vector2 as MathVector), "Деление двух векторов при помощи перегрузки оператора");
            resultMathVectors[11] = new VectorWithDescription((vector1 as MathVector).Divide(vector2), "Деление двух векторов при помощи метода Divide");
            resultMathVectors[11] = new VectorWithDescription((vector1 as MathVector) / 5, "Деление вектора на число 5 при помощи перегрузки оператора");
            resultMathVectors[12] = new VectorWithDescription((vector1 as MathVector).DivideNumber(5), "Деление вектора на число 5 при помощи метода Divide");
            resultMathVectors[13] = new VectorWithDescription((MathVector)vector1 - (MathVector)(vector2), "Вычитание двух векторов при помощи перегрузки оператора");
            resultMathVectors[14] = new VectorWithDescription((MathVector)vector1 - 5, "Вычитание вектора с числом 5 при помощи перегрузки оператора");


            foreach (var vector in resultMathVectors)
            {
                if (vector.Description.Contains("число"))
                {
                    Logger.LogDebug($"{vector.Description}\n\nvector1: {vector1}\n{vector}");
                }
                else
                {
                    Logger.LogDebug($"{vector.Description}\n\n{vector1ConcatVector2Values}\n{vector}");
                }
            }
        }
    }
}
