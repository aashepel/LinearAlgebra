using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra
{
    public interface IMathVector : IEnumerable
    {
		int Dimensions { get; }/// Получить размерность вектора (количество координат).
		double this[int i] { get; set; }/// Индексатор для доступа к элементам вектора. Нумерация с нуля.
		double Length { get; }/// Рассчитать длину (модуль) вектора.
		IMathVector SumNumber(double number);/// Покомпонентное сложение с числом.
		IMathVector MultiplyNumber(double number);/// Покомпонентное умножение на число.
		IMathVector Sum(IMathVector vector);/// Сложение с другим вектором.
		IMathVector Multiply(IMathVector vector);/// Покомпонентное умножение с другим вектором.
		double ScalarMultiply(IMathVector vector);/// Скалярное умножение на другой вектор.
		double CalcDistance(IMathVector vector);/// Вычислить Евклидово расстояние до другого вектора.
	}
}
