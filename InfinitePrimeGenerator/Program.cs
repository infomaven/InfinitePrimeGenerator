	using System;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.Remoting.Channels;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace InfinitePrimeGenerator
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			TimeSpan ts;

			foreach (double p in AllPrimes()) {
				ts = stopwatch.Elapsed;
				string elapsedTime = String.Format ("{0:0000}:{1:0000}.{2:00000000000000}",
					                     ts.Minutes, ts.Seconds, ts.Milliseconds);
				if ( ts.Minutes == 1 ) {
				    Console.WriteLine ("Max Prime = " + p);

					break;
				} else {
					Console.Write (p + ": " + elapsedTime + "\n");
				}

			}

			stopwatch.Stop();
		}

		private bool isPrime (int testVal, int comparisonVal )
		{
		    bool result = false;
		    if ( (testVal % testVal == 0) && (testVal % 1 == 0) && ( testVal % comparisonVal != 1) ) {
		         result = true; 
		         }
		    return result;

		}

		/// <summary>
		/// Method that generates a list of Primes using odd number testPrimes. First two primes are front loaded. 
		/// </summary>
		/// <returns>The primes.</returns>
		private static IEnumerable<double> AllPrimes ()
		{
			List<double> primesThusFar = new List<double> ();
			List<double> primesExcluded = new List<double> ();
			primesThusFar.Add (2);
			yield return 2;
			primesThusFar.Add (3);
			yield return 3;

			double testPrime = 5;
			double testSqRoot;
			while (true) {
			    
				bool isPrime = true;			
				foreach (double n in primesThusFar) {
					/// secondCut: eliminate testPrime if it can be factored by anything from our list
//					if (testPrime % n == 0) {
//						isPrime = false;
//						break;		            				
//					}

					/// thirdCut: eliminate testPrime if it's square root can be factored by anything from our list
					testSqRoot = Math.Sqrt (testPrime);
					if ( testSqRoot < n )
						break;
					if ( testSqRoot % n == 0 ) {
						isPrime = false;
						break;
					}
                   
				}
				//// if none of previous tests eliminated testPrime, it can be added
				if (isPrime) {
					primesThusFar.Add (testPrime);
					yield return testPrime;
				}
				/// make sure testPrime is always an odd number
				testPrime += 2;
			}
		}
	}
}
