using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Pcg;
using System.Threading;

namespace PrimeGen
{
	public class BigIntegerGenerator
	{
		Random random;
		ThreadLocal<byte[]> threadLocalByteArray;

		public BigIntegerGenerator(int byteSize)
		{
			random = new ThreadSafeRandom(() => new PcgRandom());
			threadLocalByteArray = new ThreadLocal<byte[]>(() => new byte[byteSize]);
		}

		public BigInteger Next()
		{
			var ret = BigInteger.Zero;
			while (ret.IsZero)
			{
				var bytes = threadLocalByteArray.Value;
				random.NextBytes(bytes);
				ret = BigInteger.Abs(new BigInteger(bytes));
			}
			return ret;
		}
	}
}
