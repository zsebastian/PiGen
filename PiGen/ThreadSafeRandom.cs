using System;
using System.Threading;

namespace PrimeGen
{
	public class ThreadSafeRandom: Random
	{
		ThreadLocal<Random> random;

		public ThreadSafeRandom(Func<Random> factory)
		{
			random = new ThreadLocal<Random>(factory);
		}

		public override int Next()
		{
			return random.Value.Next();
		}

		public override int Next(int maxValue)
		{
			return random.Value.Next(maxValue);
		}

		public override int Next(int minValue, int maxValue)
		{
			return random.Value.Next(minValue, maxValue);
		}

		public override void NextBytes(byte[] buffer)
		{
			random.Value.NextBytes(buffer);
		}

		public override double NextDouble()
		{
			return random.Value.NextDouble();
		}
	}
}
