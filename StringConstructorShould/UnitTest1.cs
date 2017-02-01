﻿using System;
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
				.Case(c => c.Color != "", (v, builder) => builder.Append("The Color of this car is "))
				.Case(c => c.Color != "", (v, builder) => builder.Append(v.Color))
				.Case(c => c.Color != "", (v, builder) => builder.Append(". "))
				.Case(c => c.CarEngine != null && c.CarEngine.Hp > 100, (v, builder) => builder.Append("This Car is more than 100 HP."))
				.Build();
			Assert.AreEqual("The Color of this car is Orange. This Car is more than 100 HP.", x);
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