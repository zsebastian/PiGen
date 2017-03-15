using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PrimeGen
{
	public static class BigIntegerExtensions
	{
		public static bool IsCoPrimeWith(this BigInteger a, BigInteger b)
		{
			return BigInteger.GreatestCommonDivisor(a, b).IsOne;
		}
	}
}
