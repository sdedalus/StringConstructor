using System;
using System.Text;

namespace StringConstructor
{
	public interface ICase<T1> : IBuild
	{
		/// <summary>
		/// Cases the specified condition.
		/// </summary>
		/// <param name="condition">The condition.</param>
		/// <param name="func">The function.</param>
		/// <returns></returns>
		ICase<T1> Case(Func<T1, bool> condition, Action<T1, StringBuilder> act);

		/// <summary>
		/// Cases the specified condition.
		/// </summary>
		/// <param name="condition">The condition.</param>
		/// <param name="act">The act.</param>
		/// <returns></returns>
		ICase<T1> Case(string condition, Action<T1, StringBuilder> act);
	}
}