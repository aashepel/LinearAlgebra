using LinearAlgebra;
using System;
using System.Threading.Tasks;

namespace VectorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IMathVector vec2 = new MathVector(new double[] { 0, 0, 1, 0 }, nameof(vec2));
            IMathVector vec1 = new MathVector(vec2, nameof(vec1));
            IMathVector vec3 = new MathVector(vec1, nameof(vec3));
            IMathVector vec4 = (MathVector)vec1 + 100;
            MathVector.PrintLength(vec1);
            MathVector.PrintLength(vec2);
            MathVector.PrintLength(vec3);
            MathVector.Print(vec4);
        }
    }
}
