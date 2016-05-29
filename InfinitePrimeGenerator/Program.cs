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
				/// for local testing
//				if (ts.Seconds == 1) {
				    Console.WriteLine ("Max Prime = " + p);

					break;
				} else {
					Console.Write (p + ": " + elapsedTime + "\n");
				}

			}

			stopwatch.Stop();
		}

		private static IEnumerable<double> AllPrimes ()
		{
			List<double> primesThusFar = new List<double> ();
			primesThusFar.Add (2);
			yield return 2;
			primesThusFar.Add (3);
			yield return 3;

			double testPrime = 5;
			double testSqRoot;
			while (true) {
				bool isPrime = true;

				foreach (double n in primesThusFar) {
					/// firstCut: eliminate testPrime if it can be factored by anything from our list
//					if (testPrime % n == 0) {
//						isPrime = false;
//						break;		            				
//					}

					/// secondCut: eliminate testPrime if it's square root can be factored by anything from our list
				    testSqRoot = Math.Sqrt (testPrime);
					if ( testSqRoot % n == 0 ) {
						isPrime = false;
						break;
					}
                   
				}
				if (isPrime) {
					primesThusFar.Add (testPrime);
					yield return testPrime;
				}
				/// make sure we always get an odd number
				testPrime += 2;
			}
		}
	}
}
