using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pcg;
using System.Numerics;
using Numerics;

namespace PrimeGen
{
	class Program
	{
		static readonly BigInteger Six = new BigInteger(6);

		static void Main(string[] args)
		{
			var generator = new BigIntegerGenerator(32);
			Queue<Task<BigRational>> batches = new Queue<Task<BigRational>>();
			for(int i = 0; i < 1000; ++i)
			{
				batches.Enqueue(Batch(generator, 10000));
			}
			BigRational aggregate = BigRational.Zero; 
			while(batches.Count != 0)
			{
				var result = batches.Dequeue().Result;
				aggregate = new BigRational(aggregate.Numerator + result.Numerator, aggregate.Denominator + result.Denominator);
			}
			var ratio = aggregate; 
			var sixoverx = Six / ratio;
			Console.WriteLine("PI = {0}", Math.Sqrt(((double)sixoverx)));
			Console.ReadKey();
		}
		
		public static Task<BigRational> Batch(BigIntegerGenerator generator, int iterations)
		{
			return Task.Run(() => 
			{	
				BigInteger cofactor = BigInteger.Zero;
				BigInteger coprime = BigInteger.Zero;
				for (int i = 0; i < iterations; ++i)
				{
					if (generator.Next().IsCoPrimeWith(generator.Next()))
					{
						coprime++;
					}
					else
					{
						cofactor++;
					}
				}
				return new BigRational(coprime, cofactor + coprime);
			});
		}
	}
}
