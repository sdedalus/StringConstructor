using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringConstructor
{
	public class StringConstructor<T1> : ICase<T1>
	{
		private readonly StringBuilder stringBuilder;
		private readonly T1 datasource;
		private readonly Dictionary<string, Func<T1, bool>> namedConditions = new Dictionary<string, Func<T1, bool>>();

		public void AddNamedCondition(string name, Func<T1, bool> condition)
		{
			namedConditions.Add(name, condition);
		}

		public StringConstructor(T1 datasource)
		{
			this.datasource = datasource;
			this.stringBuilder = new StringBuilder();
		}

		public StringConstructor(StringBuilder stringBuilder, T1 datasource)
		{
			this.stringBuilder = stringBuilder;
			this.datasource = datasource;
		}

		public string Build()
		{
			return this.stringBuilder.ToString();
		}

		public ICase<T1> Case(Func<T1, bool> condition, Action<T1, StringBuilder> act)
		{
			if (condition(datasource))
			{
				act(datasource, stringBuilder);
			}
			return this;
		}

		public ICase<T1> Case(string condition, Action<T1, StringBuilder> act)
		{
			if (namedConditions[condition](datasource))
			{
				act(datasource, stringBuilder);
			}
			return this;
		}
	}
}