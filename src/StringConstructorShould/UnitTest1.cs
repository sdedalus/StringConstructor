using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringConstructor;

namespace StringConstructorShould
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var x = new StringConstructor<Car>(new Car() { Color = "Orange", Price = 11, CarEngine = new CarEngine() { Hp = 200 } })
				.AddNamedCondition("HorsePower", c => c.CarEngine != null && c.CarEngine.Hp > 100)
				.Case(c => c.Color != "", (v) => "The Color of this car is ")
				.Case(c => c.Color != "", (v) => v.Color)
				.Case(c => c.Color != "", (v, builder) => builder.Append(". "))
				.Case("HorsePower", (v, builder) => builder.Append("This Car has more than 100 HP."))
				.Build();

			Assert.AreEqual("The Color of this car is Orange. This Car has more than 100 HP.", x);
		}

		internal class Car
		{
			public string Color { get; internal set; }
			public double Price { get; internal set; }

			public CarEngine CarEngine { get; internal set; }
		}

		internal class CarEngine
		{
			public int Hp { get; internal set; }
		}
	}
}