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
		/// <summary>
		/// Количество (размерность) точек вектора
		/// </summary>
		int Dimensions { get; }

		/// <summary>
		/// Индексатор. Нумерация с нуля
		/// </summary>
		/// <param name="i">Индекс (номер) элемента вектора</param>
		/// <returns>Элемент вектора по индексу</returns>
		double this[int i] { get; set; }

		/// <summary>
		/// Длина (модуль) вектора
		/// </summary>
		double Length { get; }

		/// <summary>
		/// Покомпонентное сложение с числом
		/// </summary>
		/// <param name="number">Число</param>
		/// <returns>Новый вектор</returns>
		IMathVector SumNumber(double number);

		/// <summary>
		/// Покомпонентное умножение на число
		/// </summary>
		/// <param name="number">Число</param>
		/// <returns>Новый вектор</returns>
		IMathVector MultiplyNumber(double number);

		/// <summary>
		/// Покомпонентное сложение с другим вектором
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый вектор</returns>
		IMathVector Sum(IMathVector vector);

		/// <summary>
		/// Покомпонентное умножение с другим вектором
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый вектор</returns>
		IMathVector Multiply(IMathVector vector);

		/// <summary>
		/// Скалярное умножение
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Число</returns>
		double ScalarMultiply(IMathVector vector);

		/// <summary>
		/// Евклидово расстояние до другого вектора
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Число - Еквклидово расстояние</returns>
		double CalcDistance(IMathVector vector);

		/// <summary>
		/// Покомпонентное деление вектора на число
		/// </summary>
		/// <param name="number">Число</param>
		/// <returns>Новый вектор</returns>
		IMathVector DivideNumber(double number);

		/// <summary>
		/// Покомпонентное деление вектора на вектор
		/// </summary>
		/// <param name="number">Число</param>
		/// <returns>Новый вектор</returns>
		IMathVector Divide(IMathVector vector);
	}
}
