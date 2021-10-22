using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LinearAlgebra;
using LinearAlgebra.Exceptions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MathVectorTests
{
    [TestClass]
    public class MathVectorTests
    {
        private double _doubleMaxValue = double.MaxValue;
        private void AssertVectors(IMathVector vector1, IMathVector vector2)
        {
            if (vector1.Dimensions != vector2.Dimensions)
            {
                throw new DifferentVectorSpacesException();
            }
            for (int i = 0; i < vector1.Dimensions; i++)
            {
                AssertDoubles(vector1[i], vector2[i]);
            }
        }
        private void AssertDoubles(double first, double second)
        {
            Assert.AreEqual(first, second, 0.0000000000001);
        }
        [TestMethod]
        public void TestMethodConstructorMathVectorDoubleArray()
        {
            //Arrange
            double[] points = new double[] { -5.1, 20.12, 5201.152 };
            IMathVector vector = new MathVector(points);
            //Assert
            for (int i = 0; i < 3; i++)
            {
                AssertDoubles(vector[i], points[i]);
            }
        }
        [TestMethod]
        public void TestMethodConstructorMathVector()
        {
            // Arrange
            double[] points = new double[] { 2, 10.4, -1420 };
            IMathVector vector = new MathVector(points);
            double a = 2, b = 10.4, c = -1420;
            // Asset
            AssertDoubles(a, vector[0]);
            AssertDoubles(b, vector[1]);
            AssertDoubles(c, vector[2]);

        }
        [TestMethod]
        [ExpectedException(typeof(WrongSizeVectorException))]
        public void TestMethodConstructWrongSizeMathVector()
        {
            double[] points = new double[] {};
            IMathVector vector = new MathVector(points);
        }

        [TestMethod]
        public void TestMethodSumRealNumbers()
        {
            //Arrange
            double[] points = new double[] { -1.25, 0, 19.8 };
            double number = 2;
            double[] pointsResult = new double[] { 0.75, 2, 21.8 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = vector.SumNumber(number);
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodSumIntegerNumbers()
        {
            //Arrange
            double[] points = new double[] { 1, -3, 4 };
            double number = 2;
            double[] pointsResult = new double[] { 3, -1, 6 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = vector.SumNumber(number);
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodSumNumbers_InfinityDoubleVectorsException()
        {
            //Arrange
            double[] points = new double[] { Double.MaxValue, 0 };
            double number = double.MaxValue / 4;
            IMathVector vector = new MathVector(points);
            //Act
            vector = vector.SumNumber(number);
            Console.WriteLine(vector);
        }
        [TestMethod]
        public void TestMethodOperatorSumRealNumber()
        {
            //Arrange
            double[] points = new double[] { -5.2, 10.3, 0 };
            double number = 9.4;
            double[] pointsResult = new double[] { 4.2, 19.7, 9.4 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = (vector as MathVector) + number;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodOperatorSumIntegerNumber()
        {
            //Arrange
            double[] points = new double[] { 2, -12, 4 };
            double number = 9.4;
            double[] pointsResult = new double[] { 11.4, -2.6, 13.4 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = (vector as MathVector) + number;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodOperatorSumNumbers_InfinityDoubleVectorsException()
        {
            //Arrange
            double[] points = new double[] { Double.MaxValue, 0 };
            double number = double.MaxValue / 4;
            IMathVector vector = new MathVector(points);
            //Act
            vector = (vector as MathVector) + number;
            Console.WriteLine(vector);
        }
        [TestMethod]
        public void TestMethodSum()
        {
            //Arrange
            IMathVector vector = new MathVector(new double[] { -4.2, 2, 0 });
            IMathVector vector1 = new MathVector(new double[] { 0, -3.1, 5.4 });
            IMathVector vectorResult = new MathVector(new double[] { -4.2, -1.1, 5.4 });
            //Act
            vector = vector.Sum(vector1);
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodSum_InfinityDoubleVectorsException()
        {
            //Arrange
            IMathVector vector = new MathVector(new double[] { -4.2, 2, double.MaxValue });
            IMathVector vector1 = new MathVector(new double[] { 0, -3.1, double.MaxValue / 8 });
            IMathVector vectorResult = new MathVector(new double[] { -4.2, -1.1, double.PositiveInfinity });
            //Act
            vector = vector.Sum(vector1);
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodSum_DifferentVectorSpacesException()
        {
            //Arrange
            double[] points = new double[] { 1, 2 };
            double[] points_1 = new double[] { 1, 2, 1 };
            IMathVector vector = new MathVector(points);
            IMathVector vector_1 = new MathVector(points_1);
            //Act
            IMathVector vectorResult = vector.Sum(vector_1);
        }
        [TestMethod]
        public void TestMethodOperatorSum()
        {
            //Arrange
            IMathVector vector = new MathVector(new double[] { -2.2, 0, -2.3 });
            IMathVector vector1 = new MathVector(new double[] { 1.9, -4.7, 3.1 });
            IMathVector vectorResult = new MathVector(new double[] { -0.3, -4.7, 0.8 });
            //Act
            vector = (vector as MathVector) + vector1;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodOperatorSumException()
        {
            //Arrange
            double[] points = new double[] { 1, 2 };
            double[] points_1 = new double[] { 1, 2, 1 };
            IMathVector vector = new MathVector(points);
            IMathVector vector_1 = new MathVector(points_1);
            //Act
            IMathVector vectorResult = (vector as MathVector) + vector_1;
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodOperatorSum_InfinityDoubleVectorsException()
        {
            //Arrange
            IMathVector vector = new MathVector(new double[] { -2.2, 0, double.MaxValue });
            IMathVector vector1 = new MathVector(new double[] { 1.9, -4.7, double.MaxValue / 8 });
            IMathVector vectorResult = new MathVector(new double[] { -0.3, -4.7, double.PositiveInfinity });
            //Act
            vector = (vector as MathVector) + vector1;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodMultiplyIntegerNumbers()
        {
            //Arrange
            double[] points = new double[] { -3, 0, 9 };
            double number = 0.5;
            double[] pointsResult = new double[] { -1.5, 0, 4.5};
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = vector.MultiplyNumber(number);
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodMultiplyRealNumbers()
        {
            //Arrange
            double[] points = new double[] { 4.2, 0, -9.1 };
            double number = 0.5;
            double[] pointsResult = new double[] { 2.1, 0, -4.55 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = vector.MultiplyNumber(number);
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodMultiplyNumbers_InfinityDoubleVectorsException()
        {
            //Arrange
            double[] points = new double[] { 4.2, double.MaxValue, -9.1 };
            double number = double.MaxValue / 6;
            double[] pointsResult = new double[] { 2.1, double.PositiveInfinity, -4.55 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = vector.MultiplyNumber(number);
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodOperatorMultiplyIntegerNumbers()
        {
            //Arrange
            double[] points = new double[] { -3, 0, 9 };
            double number = 0.5;
            double[] pointsResult = new double[] { -1.5, 0, 4.5 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = (vector as MathVector) * number;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodOperatorMultiplyRealNumbers()
        {
            //Arrange
            double[] points = new double[] { 4.2, 0, -9.1 };
            double number = 0.5;
            double[] pointsResult = new double[] { 2.1, 0, -4.55 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = (vector as MathVector) * number;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodOperatorMultiplyNumbers_InfinityDoubleVectorsException()
        {
            //Arrange
            double[] points = new double[] { 4.2, double.MaxValue, -9.1 };
            double number = double.MaxValue / 6;
            double[] pointsResult = new double[] { 2.1, double.PositiveInfinity, -4.55 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = (vector as MathVector) * number;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodMultiply()
        {
            //Arrange
            IMathVector vector1 = new MathVector(new double[] { 0, 1.5, -5 });
            IMathVector vector2 = new MathVector(new double[] { -2.5, 3.5, 0 });
            IMathVector vectorResult = new MathVector(new double[] { 0, 5.25, 0 });
            //Act
            vector1 = vector1.Multiply(vector2);
            //Assert
            AssertVectors(vector1, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodMultiply_InfinityDoubleVectorsException()
        {
            //Arrange
            IMathVector vector1 = new MathVector(new double[] { 0, double.MaxValue, -5 });
            IMathVector vector2 = new MathVector(new double[] { -2.5, double.MaxValue / 7, 0 });
            IMathVector vectorResult = new MathVector(new double[] { 0, double.PositiveInfinity, 0 });
            //Act
            vector1 = vector1.Multiply(vector2);
            //Assert
            AssertVectors(vector1, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodMultiply_DifferentVectorSpacesException()
        {
            //Arrange
            double[] points = new double[] { -51, 15, 0 };
            double[] points1 = new double[] { 5, 10 };
            IMathVector vector = new MathVector(points);
            IMathVector vector1 = new MathVector(points1);
            //Act
            vector.Multiply(vector1);
        }
        [TestMethod]
        public void TestMethodOperatorMultiply()
        {
            //Arrange
            IMathVector vector = new MathVector(new double[] { -2, 4.2, 0 });
            IMathVector vector1 = new MathVector(new double[] { 2.5, -2.1, 2 });
            IMathVector vectorResult = new MathVector(new double[] { -5, -8.82, 0 });
            //Act
            vector = (vector as MathVector) * vector1;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodOperatorMultiplyDifferentVectorSpacesException()
        {
            //Arrange
            double[] points1 = new double[] { -51, 15, 0 };
            double[] points2 = new double[] { 5, 10 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            //Act
            vector1 = (vector1 as MathVector) * vector2;
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodOperatorMultiply_InfinityDoubleVectorsException()
        {
            //Arrange
            IMathVector vector1 = new MathVector(new double[] { 0, double.MaxValue, -5 });
            IMathVector vector2 = new MathVector(new double[] { -2.5, double.MaxValue / 7, 0 });
            IMathVector vectorResult = new MathVector(new double[] { 0, double.PositiveInfinity, 0 });
            //Act
            vector1 = (vector1 as MathVector).Multiply(vector2);
            //Assert
            AssertVectors(vector1, vectorResult);
        }
        [TestMethod]
        public void TestMethodGetter()
        {
            // Arrange
            double[] points = new double[] { -4, 2, 15 };
            IMathVector vector = new MathVector(points);
            double result1 = -4;
            double result2 = 2;
            double result3 = 15;
            // Act
            double coor1 = vector[0];
            double coor2 = vector[1];
            double coor3 = vector[2];
            // Assert
            AssertDoubles(coor1, result1);
            AssertDoubles(coor2, result2);
            AssertDoubles(coor3, result3);
        }
        [TestMethod]
        public void TestMethodGetter_IndexOutOfRangeMathVectorException()
        {
            // Arrange
            double[] points = new double[] { -4, 2, 15 };
            IMathVector vector = new MathVector(points);
            double result1 = -4;
            double result2 = 2;
            double result3 = 15;
            // Act
            Assert.ThrowsException<IndexOutOfRangeMathVectorException>(() =>
            {
                double coor1 = vector[0];
                double coor2 = vector[1];
                double coor3 = vector[3];
            });
        }
        [TestMethod]
        public void TestMethodSetter()
        {
            // Arrange
            double[] points = new double[] { -4, 2, 15 };
            IMathVector vector = new MathVector(points);
            double number1 = 1;
            double number2 = 2;
            double number3 = 3;
            // Act
            vector[0] = number1;
            vector[1] = number2;
            vector[2] = number3;
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeMathVectorException))]
        public void TestMethodSetter_IndexOutOfRangeMathVectorException()
        {
            // Arrange
            double[] points = new double[] { -4, 2, 15 };
            IMathVector vector = new MathVector(points);
            double number1 = 1;
            double number2 = 2;
            double number3 = 3;
            // Act
            vector[0] = number1;
            vector[1] = number2;
            vector[3] = number3;
        }
        [TestMethod]
        public void TestMethodScalarMultiply()
        {
            // Arrange
            double[] points1 = new double[] { 1.5, -3.5, 0 };
            double[] points2 = new double[] { 5.8, 4.2, -1 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            double expectedResult = -6;
            // Act
            double scalarMultiply = vector1.ScalarMultiply(vector2);
            // Assert
            AssertDoubles(expectedResult, scalarMultiply);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodScalarMultiply_DifferentVectorSpacesException()
        {
            // Arrange
            double[] points1 = new double[] { 1, 2, 3 };
            double[] points2 = new double[] { -1, 5 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            // Act
            double scalarMultiply = vector1.ScalarMultiply(vector2);
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodScalarMultiply_InfinityDoubleVectorsException()
        {
            // Arrange
            double[] points1 = new double[] { 1.5, double.MaxValue, 0 };
            double[] points2 = new double[] { 5.8, double.MaxValue / 32, -1 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            double expectedResult = double.PositiveInfinity;
            // Act
            double scalarMultiply = vector1.ScalarMultiply(vector2);
            // Assert
            AssertDoubles(expectedResult, scalarMultiply);
        }
        [TestMethod]
        public void TestMethodOperatorScalarMultiply()
        {
            // Arrange
            double[] points1 = new double[] { 1.5, -3.5, 0 };
            double[] points2 = new double[] { 5.8, 4.2, -1 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            double expectedResult = Math.Round(-6.0, 5);
            // Act
            double scalarMultiply = Math.Round((vector1 as MathVector) % vector2, 5);
            // Assert
            AssertDoubles(scalarMultiply, expectedResult);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodOperatorScalarMultiply_DifferentVectorSpacesException()
        {
            // Arrange
            double[] points1 = new double[] { 1, 2, 3 };
            double[] points2 = new double[] { -1, 5 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            // Act
            double scalarMultiply = (vector1 as MathVector) % vector2;
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodOperatorScalarMultiply_InfinityDoubleVectorsException()
        {
            // Arrange
            double[] points1 = new double[] { 1.5, double.MaxValue, 0 };
            double[] points2 = new double[] { 5.8, double.MaxValue / 32, -1 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            double expectedResult = double.PositiveInfinity;
            // Act
            double scalarMultiply = (vector1 as MathVector) % vector2;
            // Assert
            AssertDoubles(expectedResult, scalarMultiply);
        }
        [TestMethod]
        public void TestMethodDistance()
        {
            // Arrange
            double[] points1 = new double[] { -4.3, 1.8, 0 };
            double[] points2 = new double[] { 3.9, -5.91, 3.5 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            double expectedResult = 11.78703;
            // Act
            double distance = Math.Round(vector1.CalcDistance(vector2), 5);
            // Assert
            AssertDoubles(distance, expectedResult);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodDistance_DifferentVectorSpacesException()
        {
            // Arrange
            double[] points1 = new double[] { -4, 10, 0 };
            double[] points2 = new double[] { 6, -5 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            double expectedResult = Math.Sqrt(326);
            // Act
            double distance = vector1.CalcDistance(vector2);
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodDistance_InfinityDoubleVectorsException()
        {
            // Arrange
            double[] points1 = new double[] { -4.3, double.MaxValue, 0 };
            double[] points2 = new double[] { 3.9, -5.91, 3.5 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            double expectedResult = double.PositiveInfinity;
            // Act
            double distance = vector1.CalcDistance(vector2);
            // Assert
            AssertDoubles(distance, expectedResult);
        }
        [TestMethod]
        public void TestMethodOperatorMinusNegativeNumber()
        {
            //Arrange
            double[] points = new double[] { -9.5, -4.5, 0 };
            double number = 2.2;
            double[] pointsResult = new double[] { -11.7, -6.7, -2.2 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = (vector as MathVector) - number;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodOperatorMinusPositiveNumber()
        {
            //Arrange
            double[] points = new double[] { 9.5, 4.5, 0 };
            double number = 2.2;
            double[] pointsResult = new double[] { 7.3, 2.3, -2.2 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = (vector as MathVector) - number;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodOperatorMinusNumber_InfinityDoubleVectorsException()
        {
            //Arrange
            double[] points = new double[] { 9.5, double.MinValue, 0 };
            double number = double.MaxValue / 32;
            double[] pointsResult = new double[] { 7.3, double.NegativeInfinity, -2.2 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = (vector as MathVector) - number;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodOperatorMinus()
        {
            //Arrange
            IMathVector vector = new MathVector(new double[] { -4.3, 2.3, 0 });
            IMathVector vector1 = new MathVector(new double[] { 2.2, 0, -2.3 });
            IMathVector vectorResult = new MathVector(new double[] { -6.5, 2.3, 2.3 });
            //Act
            vector = (vector as MathVector) - vector1;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodOperatorMinusException()
        {
            // Arrange
            double[] points1 = new double[] { -4, 10, 0 };
            double[] points2 = new double[] { 6, -5 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            // Act
            IMathVector result = (vector1 as MathVector) - vector2;
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodOperatorMinus_InfinityDoubleVectorsException()
        {
            //Arrange
            IMathVector vector = new MathVector(new double[] { -4.3, double.MinValue, 0 });
            IMathVector vector1 = new MathVector(new double[] { 2.2, double.MaxValue / 16, -2.3 });
            IMathVector vectorResult = new MathVector(new double[] { -6.5, double.NegativeInfinity, 2.3 });
            //Act
            vector = (vector as MathVector) - vector1;
            //Assert
            AssertVectors(vector, vectorResult);
        }

        [TestMethod]
        public void TestMethodDividePositiveNumber()
        {
            //Arrange
            double[] points = new double[] { 2.3, 1.3, 0 };
            double number = 0.5;
            double[] pointsResult = new double[] { 4.6, 2.6, 0};
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = vector.DivideNumber(number);
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodDivideNegativeNumber()
        {
            //Arrange
            double[] points = new double[] { -2.3, -1.3, 0 };
            double number = 0.5;
            double[] pointsResult = new double[] { -4.6, -2.6, 0 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = vector.DivideNumber(number);
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroMathVectorException))]
        public void TestMethodDivideByZeroNumber()
        {
            // Arrange
            double[] points = new double[] { 15, 5, -1 };
            IMathVector vector1 = new MathVector(points);
            // Act
            IMathVector result = vector1.DivideNumber(0);
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodDivideNumber_InfinityDoubleVectorsException()
        {
            //Arrange
            double[] points = new double[] { -2.3, double.MaxValue, 0 };
            double number = 0.00000000001;
            double[] pointsResult = new double[] { -4.6, double.PositiveInfinity, 0 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = vector.DivideNumber(number);
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodOperatorDividePositiveNumber()
        {
            //Arrange
            double[] points = new double[] { 2.3, 1.3, 0 };
            double number = 0.5;
            double[] pointsResult = new double[] { 4.6, 2.6, 0 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = (vector as MathVector) / number;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodOperatorDivideNegativeNumber()
        {
            //Arrange
            double[] points = new double[] { -2.3, -1.3, 0 };
            double number = 0.5;
            double[] pointsResult = new double[] { -4.6, -2.6, 0 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = (vector as MathVector) / number;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroMathVectorException))]
        public void TestMethodOperatorDivideByZeroNumber()
        {
            // Arrange
            double[] points = new double[] { 15, 5, -1 };
            IMathVector vector1 = new MathVector(points);
            // Act
            IMathVector result = (vector1 as MathVector) / 0;
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodOperatorDivideNumber_InfinityDoubleVectorsException()
        {
            //Arrange
            double[] points = new double[] { -2.3, double.MaxValue, 0 };
            double number = 0.000001;
            double[] pointsResult = new double[] { -4.6, double.PositiveInfinity, 0 };
            IMathVector vector = new MathVector(points);
            IMathVector vectorResult = new MathVector(pointsResult);
            //Act
            vector = (vector as MathVector) / number;
            //Assert
            AssertVectors(vector, vectorResult);
        }
        [TestMethod]
        public void TestMethodDivide()
        {
            //Arrange
            IMathVector vector1 = new MathVector(new double[] { -1.5, 5.2, 0 });
            IMathVector vector2 = new MathVector(new double[] { 0.5, -0.5, 2 });
            IMathVector vectorResult = new MathVector(new double[] { -3, -10.4, 0 });
            //Act
            vector1 = vector1.Divide(vector2);
            //Assert
            AssertVectors(vector1, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroMathVectorException))]
        public void TestMethodDivideByZeroElementVector()
        {
            // Arrange
            double[] points1 = new double[] { 15, 5, -1 };
            double[] points2 = new double[] { 1, 0, 5 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            // Act
            IMathVector result = vector1.Divide(vector2);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodDivide_DifferentVectorSpacesException()
        {
            // Arrange
            double[] points1 = new double[] { 15, 5, -1 };
            double[] points2 = new double[] { 1, 0 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            // Act
            IMathVector result = vector1.Divide(vector2);
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodDivide_InfinityDoubleVectorsException()
        {
            //Arrange
            IMathVector vector1 = new MathVector(new double[] { -1.5, double.MaxValue, 0 });
            IMathVector vector2 = new MathVector(new double[] { 0.5, 0.0001, 2 });
            IMathVector vectorResult = new MathVector(new double[] { -3, double.PositiveInfinity, 0 });
            //Act
            vector1 = vector1.Divide(vector2);
            //Assert
            AssertVectors(vector1, vectorResult);
        }
        [TestMethod]
        public void TestMethodOperatorDivide()
        {
            //Arrange
            IMathVector vector1 = new MathVector(new double[] { -1.5, 5.2, 0 });
            IMathVector vector2 = new MathVector(new double[] { 0.5, -0.5, 2 });
            IMathVector vectorResult = new MathVector(new double[] { -3, -10.4, 0 });
            //Act
            vector1 = (vector1 as MathVector) / vector2;
            //Assert
            AssertVectors(vector1, vectorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroMathVectorException))]
        public void TestMethodOperatorDivideByZero()
        {
            // Arrange
            double[] points1 = new double[] { 15, 5, -1 };
            double[] points2 = new double[] { 1, 0, 14 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            // Act
            IMathVector result = (vector1 as MathVector) / vector2;
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodOperatorDivideException_DifferentVectorSpacesException()
        {
            // Arrange
            double[] points1 = new double[] { 15, 5, -1 };
            double[] points2 = new double[] { 1, 0 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            // Act
            IMathVector result = (vector1 as MathVector) / vector2;
        }
        [TestMethod]
        [ExpectedException(typeof(InfinityDoubleVectorsException))]
        public void TestMethodOperatorDivide_InfinityDoubleVectorsException()
        {
            //Arrange
            IMathVector vector1 = new MathVector(new double[] { -1.5, double.MaxValue, 0 });
            IMathVector vector2 = new MathVector(new double[] { 0.5, 0.00001, 2 });
            IMathVector vectorResult = new MathVector(new double[] { -3, double.PositiveInfinity, 0 });
            //Act
            vector1 = (vector1 as MathVector) / vector2;
            //Assert
            AssertVectors(vector1, vectorResult);
        }

    }
}
