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
        [TestMethod]
        public void TestMethodConstructorMathVectorDoubleArray()
        {
            //Arrange
            double[] points = new double[] { -5.1, 20.12, 5201.152 };
            IMathVector vector = new MathVector(points);
            //Assert
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(vector[i], points[i]);
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
            Assert.AreEqual(a, vector[0]);
            Assert.AreEqual(b, vector[1]);
            Assert.AreEqual(c, vector[2]);

        }
        [TestMethod]
        [ExpectedException(typeof(WrongSizeVectorException))]
        public void TestMethodConstructWrongSizeMathVector()
        {
            double[] points = new double[] {};
            IMathVector vector = new MathVector(points);
        }

        [TestMethod]
        public void TestMethodSumNumber()
        {
            for (int number = -1000; number <= 1000; number += 5)
            {
                for (int i = -100; i <= 100; i += 5)
                {
                    for (int j = -100; j <= 100; j += 5)
                    {
                        for (int k = -100; k <= 100; k += 5)
                        {
                            //Arrange
                            double[] points = new double[] { i, j, k };
                            double[] pointsResult = new double[] { i + number, j + number, k + number };
                            IMathVector vector = new MathVector(points);
                            IMathVector vectorResult = new MathVector(pointsResult);
                            //Act
                            vector = vector.SumNumber(number);
                            //Assert
                            Assert.AreEqual(vector, vectorResult);
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestMethodOperatorSumNumberPositive()
        {
            int step = 5;
            for (int number = -1000; number <= 1000; number += step)
            {
                for (int i = -100; i <= 100; i += step)
                {
                    for (int j = -100; j <= 100; j += step)
                    {
                        for (int k = -100; k <= 100; k += step)
                        {
                            //Arrange
                            double[] points = new double[] { i, j, k };
                            double[] pointsResult = new double[] { i + number, j + number, k + number };
                            IMathVector vector = new MathVector(points);
                            IMathVector vectorResult = new MathVector(pointsResult);
                            //Act
                            vector = (vector as MathVector) + number;
                            //Assert
                            Assert.AreEqual(vector, vectorResult);
                        }
                    }
                }
            }
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodSumException()
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
        public void TestMethodSum()
        {
            int step = 20;
            for (int vector1_i = -100; vector1_i <= 100; vector1_i += step)
            {
                for (int vector1_j = -100; vector1_j <= 100; vector1_j += step)
                {
                    for (int vector1_k = -100; vector1_k <= 100; vector1_k += step)
                    {
                        for (int vector2_i = -100; vector2_i <= 100; vector2_i += step)
                        {
                            for (int vector2_j = -100; vector2_j <= 100; vector2_j += step)
                            {
                                for (int vector2_k = -100; vector2_k <= 100; vector2_k += step)
                                {
                                    //Arrange
                                    IMathVector vector = new MathVector(new double[] { vector1_i, vector1_j, vector1_k });
                                    IMathVector vector1 = new MathVector(new double[] { vector2_i, vector2_j, vector2_k });
                                    IMathVector vectorResult = new MathVector(new double[] { vector1_i + vector2_i, vector1_j + vector2_j, vector1_k + vector2_k });
                                    //Act
                                    vector = vector.Sum(vector1);
                                    //Assert
                                    Assert.AreEqual(vector, vectorResult);
                                }
                            }
                        }
                    }
                }
            }
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
        public void TestMethodOperatorSum()
        {
            int step = 20;
            for (int vector1_i = -100; vector1_i <= 100; vector1_i += step)
            {
                for (int vector1_j = -100; vector1_j <= 100; vector1_j += step)
                {
                    for (int vector1_k = -100; vector1_k <= 100; vector1_k += step)
                    {
                        for (int vector2_i = -100; vector2_i <= 100; vector2_i += step)
                        {
                            for (int vector2_j = -100; vector2_j <= 100; vector2_j += step)
                            {
                                for (int vector2_k = -100; vector2_k <= 100; vector2_k += step)
                                {
                                    //Arrange
                                    IMathVector vector = new MathVector(new double[] { vector1_i, vector1_j, vector1_k });
                                    IMathVector vector1 = new MathVector(new double[] { vector2_i, vector2_j, vector2_k });
                                    IMathVector vectorResult = new MathVector(new double[] { vector1_i + vector2_i, vector1_j + vector2_j, vector1_k + vector2_k });
                                    //Act
                                    vector = (vector as MathVector) + vector1;
                                    //Assert
                                    Assert.AreEqual(vector, vectorResult);
                                }
                            }
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void TestMethodMultiplyNumber()
        {
            int step = 5;
            for (int number = -1000; number <= 1000; number += step)
            {
                for (int i = -100; i <= 100; i += step)
                {
                    for (int j = -100; j <= 100; j += step)
                    {
                        for (int k = -100; k <= 100; k += step)
                        {
                            //Arrange
                            double[] points = new double[] { i, j, k };
                            double[] pointsResult = new double[] { i * number, j * number, k * number };
                            IMathVector vector = new MathVector(points);
                            IMathVector vectorResult = new MathVector(pointsResult);
                            //Act
                            vector = vector.MultiplyNumber(number);
                            //Assert
                            Assert.AreEqual(vector, vectorResult);
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void TestMethodOperatorMultiplyNumber()
        {
            int step = 5;
            for (int number = -1000; number <= 1000; number += step)
            {
                for (int i = -100; i <= 100; i += step)
                {
                    for (int j = -100; j <= 100; j += step)
                    {
                        for (int k = -100; k <= 100; k += step)
                        {
                            //Arrange
                            double[] points = new double[] { i, j, k };
                            double[] pointsResult = new double[] { i * number, j * number, k * number };
                            IMathVector vector = new MathVector(points);
                            IMathVector vectorResult = new MathVector(pointsResult);
                            //Act
                            vector = (vector as MathVector) * number;
                            //Assert
                            Assert.AreEqual(vector, vectorResult);
                        }
                    }
                }
            }
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodMultiplyException()
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
        public void TestMethodMultiply()
        {
            int step = 20;
            for (int vector1_i = -100; vector1_i <= 100; vector1_i += step)
            {
                for (int vector1_j = -100; vector1_j <= 100; vector1_j += step)
                {
                    for (int vector1_k = -100; vector1_k <= 100; vector1_k += step)
                    {
                        for (int vector2_i = -100; vector2_i <= 100; vector2_i += step)
                        {
                            for (int vector2_j = -100; vector2_j <= 100; vector2_j += step)
                            {
                                for (int vector2_k = -100; vector2_k <= 100; vector2_k += step)
                                {
                                    //Arrange
                                    IMathVector vector = new MathVector(new double[] { vector1_i, vector1_j, vector1_k });
                                    IMathVector vector1 = new MathVector(new double[] { vector2_i, vector2_j, vector2_k });
                                    IMathVector vectorResult = new MathVector(new double[] { vector1_i * vector2_i, vector1_j * vector2_j, vector1_k * vector2_k });
                                    //Act
                                    vector = vector.Multiply(vector1);
                                    //Assert
                                    Assert.AreEqual(vector, vectorResult);
                                }
                            }
                        }
                    }
                }
            }
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodOperatorMultiplyException()
        {
            //Arrange
            double[] points = new double[] { -51, 15, 0 };
            double[] points1 = new double[] { 5, 10 };
            IMathVector vector = new MathVector(points);
            IMathVector vector1 = new MathVector(points1);
            //Act
            (vector as MathVector).Multiply(vector1);
        }
        [TestMethod]
        public void TestMethodOperatorMultiply()
        {
            int step = 20;
            for (int vector1_i = -100; vector1_i <= 100; vector1_i += step)
            {
                for (int vector1_j = -100; vector1_j <= 100; vector1_j += step)
                {
                    for (int vector1_k = -100; vector1_k <= 100; vector1_k += step)
                    {
                        for (int vector2_i = -100; vector2_i <= 100; vector2_i += step)
                        {
                            for (int vector2_j = -100; vector2_j <= 100; vector2_j += step)
                            {
                                for (int vector2_k = -100; vector2_k <= 100; vector2_k += step)
                                {
                                    //Arrange
                                    IMathVector vector = new MathVector(new double[] { vector1_i, vector1_j, vector1_k });
                                    IMathVector vector1 = new MathVector(new double[] { vector2_i, vector2_j, vector2_k });
                                    IMathVector vectorResult = new MathVector(new double[] { vector1_i * vector2_i, vector1_j * vector2_j, vector1_k * vector2_k });
                                    //Act
                                    vector = (vector as MathVector) * vector1;
                                    //Assert
                                    Assert.AreEqual(vector, vectorResult);
                                }
                            }
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void TestMethodOperatorSqareBrackets()
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
            Assert.AreEqual(coor1, result1);
            Assert.AreEqual(coor2, result2);
            Assert.AreEqual(coor3, result3);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeMathVectorException))]
        public void TestMethodOperatorSqareBracketsException_First()
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
            double coor3 = vector[-1];
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeMathVectorException))]
        public void TestMethodOperatorSqareBracketsException_Second()
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
            double coor3 = vector[3];
        }
        [TestMethod]
        public void TestMethodScalarMultiply()
        {
            // Arrange
            double[] points1 = new double[] { 1, 2, 3 };
            double[] points2 = new double[] { -1, 5, 0 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            double expectedResult = 9;
            // Act
            double scalarMultiply = vector1.ScalarMultiply(vector2);
            // Assert
            Assert.AreEqual(expectedResult, scalarMultiply);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodScalarMultiplyException()
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
        public void TestMethodOperatorScalarMultiply()
        {
            // Arrange
            double[] points1 = new double[] { 1, 2, 3 };
            double[] points2 = new double[] { -1, 5, 0 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            double expectedResult = 9;
            // Act
            double scalarMultiply = (vector1 as MathVector) % vector2;
            // Assert
            Assert.AreEqual(expectedResult, scalarMultiply);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodOperatorScalarMultiplyException()
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
        public void TestMethodDistance()
        {
            // Arrange
            double[] points1 = new double[] { -4, 10, 0 };
            double[] points2 = new double[] { 6, -5, -1 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            double expectedResult = Math.Sqrt(326);
            // Act
            double distance = vector1.CalcDistance(vector2);
            // Assert
            Assert.AreEqual(expectedResult, distance);
        }
        [TestMethod]
        [ExpectedException(typeof(DifferentVectorSpacesException))]
        public void TestMethodDistanceException()
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
        public void TestMethodOperatorMinusNumber()
        {
            int step = 5;
            for (int number = -1000; number <= 1000; number += step)
            {
                for (int i = -100; i <= 100; i += step)
                {
                    for (int j = -100; j <= 100; j += step)
                    {
                        for (int k = -100; k <= 100; k += step)
                        {
                            //Arrange
                            double[] points = new double[] { i, j, k };
                            double[] pointsResult = new double[] { i - number, j - number, k - number };
                            IMathVector vector = new MathVector(points);
                            IMathVector vectorResult = new MathVector(pointsResult);
                            //Act
                            vector = (vector as MathVector) - number;
                            //Assert
                            Assert.AreEqual(vector, vectorResult);
                        }
                    }
                }
            }
        }
        public void TestMethodOperatorMinus()
        {
            int step = 20;
            for (int vector1_i = -100; vector1_i <= 100; vector1_i += step)
            {
                for (int vector1_j = -100; vector1_j <= 100; vector1_j += step)
                {
                    for (int vector1_k = -100; vector1_k <= 100; vector1_k += step)
                    {
                        for (int vector2_i = -100; vector2_i <= 100; vector2_i += step)
                        {
                            for (int vector2_j = -100; vector2_j <= 100; vector2_j += step)
                            {
                                for (int vector2_k = -100; vector2_k <= 100; vector2_k += step)
                                {
                                    //Arrange
                                    IMathVector vector = new MathVector(new double[] { vector1_i, vector1_j, vector1_k });
                                    IMathVector vector1 = new MathVector(new double[] { vector2_i, vector2_j, vector2_k });
                                    IMathVector vectorResult = new MathVector(new double[] { vector1_i - vector2_i, vector1_j - vector2_j, vector1_k - vector2_k });
                                    //Act
                                    vector = (vector as MathVector) - vector1;
                                    //Assert
                                    Assert.AreEqual(vector, vectorResult);
                                }
                            }
                        }
                    }
                }
            }
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
        public void TestMethodDivideNumber()
        {
            int step = 5;
            for (int number = -1000; number <= 1000; number += step)
            {
                if (number == 0) number += step;
                for (int i = -100; i <= 100; i += step)
                {
                    for (int j = -100; j <= 100; j += step)
                    {
                        for (int k = -100; k <= 100; k += step)
                        {
                            //Arrange
                            double[] points = new double[] { i, j, k };
                            double[] pointsResult = new double[] { (i / (double)number), j / (double)number, k / (double)number };
                            IMathVector vector = new MathVector(points);
                            IMathVector vectorResult = new MathVector(pointsResult);
                            //Act
                            vector = vector.DivideNumber(number);
                            //Assert
                            Assert.AreEqual(vector, vectorResult);
                        }
                    }
                }
            }
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroMathVectorException))]
        public void TestMethodDivideNumberException()
        {
            // Arrange
            double[] points = new double[] { 15, 5, -1 };
            IMathVector vector1 = new MathVector(points);
            // Act
            IMathVector result = vector1.DivideNumber(0);
        }
        [TestMethod]
        public void TestMethodOperatorDivideNumber()
        {
            int step = 5;
            for (int number = -1000; number <= 1000; number += step)
            {
                if (number == 0) number += 5;
                for (int i = -100; i <= 100; i += step)
                {
                    for (int j = -100; j <= 100; j += step)
                    {
                        for (int k = -100; k <= 100; k += step)
                        {
                            //Arrange
                            double[] points = new double[] { i, j, k };
                            double[] pointsResult = new double[] { i / (double)number, j / (double)number, k / (double)number };
                            IMathVector vector = new MathVector(points);
                            IMathVector vectorResult = new MathVector(pointsResult);
                            //Act
                            vector = (vector as MathVector) / number;
                            //Assert
                            Assert.AreEqual(vector, vectorResult);
                        }
                    }
                }
            }
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroMathVectorException))]
        public void TestMethodOperatorDivideNumberException()
        {
            // Arrange
            double[] points = new double[] { 15, 5, -1 };
            IMathVector vector1 = new MathVector(points);
            // Act
            IMathVector result = (vector1 as MathVector) / 0;
        }





        [TestMethod]
        public void TestMethodDivide()
        {
            int step = 20;
            for (int vector1_i = -100; vector1_i <= 100; vector1_i += step)
            {
                for (int vector1_j = -100; vector1_j <= 100; vector1_j += step)
                {
                    for (int vector1_k = -100; vector1_k <= 100; vector1_k += step)
                    {
                        for (int vector2_i = -100; vector2_i <= 100; vector2_i += step)
                        {
                            for (int vector2_j = -100; vector2_j <= 100; vector2_j += step)
                            {
                                for (int vector2_k = -100; vector2_k <= 100; vector2_k += step)
                                {
                                    if (vector2_i == 0 || vector2_j == 0 || vector2_k == 0) continue;
                                    //Arrange
                                    IMathVector vector1 = new MathVector(new double[] { vector1_i, vector1_j, vector1_k });
                                    IMathVector vector2 = new MathVector(new double[] { vector2_i, vector2_j, vector2_k });
                                    IMathVector vectorResult = new MathVector(new double[] { vector1_i / (double)vector2_i, vector1_j / (double)vector2_j, vector1_k / (double)vector2_k });
                                    //Act
                                    vector1 = vector1.Divide(vector2);
                                    //Assert
                                    Assert.AreEqual(vector1, vectorResult);
                                }
                            }
                        }
                    }
                }
            }
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroMathVectorException))]
        public void TestMethodDivideException_First()
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
        public void TestMethodDivideException_Second()
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
        public void TestMethodOperatorDivide()
        {
            int step = 20;
            for (int vector1_i = -100; vector1_i <= 100; vector1_i += step)
            {
                for (int vector1_j = -100; vector1_j <= 100; vector1_j += step)
                {
                    for (int vector1_k = -100; vector1_k <= 100; vector1_k += step)
                    {
                        for (int vector2_i = -100; vector2_i <= 100; vector2_i += step)
                        {
                            for (int vector2_j = -100; vector2_j <= 100; vector2_j += step)
                            {
                                for (int vector2_k = -100; vector2_k <= 100; vector2_k += step)
                                {
                                    if (vector2_i == 0 || vector2_j == 0 || vector2_k == 0) continue;
                                    //Arrange
                                    IMathVector vector1 = new MathVector(new double[] { vector1_i, vector1_j, vector1_k });
                                    IMathVector vector2 = new MathVector(new double[] { vector2_i, vector2_j, vector2_k });
                                    IMathVector vectorResult = new MathVector(new double[] { vector1_i / (double)vector2_i, vector1_j / (double)vector2_j, vector1_k / (double)vector2_k });
                                    //Act
                                    vector1 = (vector1 as MathVector) / vector2;
                                    //Assert
                                    Assert.AreEqual(vector1, vectorResult);
                                }
                            }
                        }
                    }
                }
            }
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroMathVectorException))]
        public void TestMethodOperatorDivideException_First()
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
        public void TestMethodOperatorDivideException_Second()
        {
            // Arrange
            double[] points1 = new double[] { 15, 5, -1 };
            double[] points2 = new double[] { 1, 0 };
            IMathVector vector1 = new MathVector(points1);
            IMathVector vector2 = new MathVector(points2);
            // Act
            IMathVector result = (vector1 as MathVector) / vector2;
        }

    }
}
