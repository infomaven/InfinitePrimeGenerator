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
			foreach (int p in AllPrimes()) {
				ts = stopwatch.Elapsed;
				string elapsedTime = String.Format ("{0:0000}:{1:0000}.{2:00000000000000}",
					                     ts.Minutes, ts.Seconds, ts.Milliseconds);
				if ( ts.Minutes == 1 )
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

		private static IEnumerable<int> AllPrimes ()
		{
			List<int> primesThusFar = new List<int> ();
			primesThusFar.Add(2);
			yield return 2;
			primesThusFar.Add(3);
			yield return 3;

			int testPrime = 5;
			while (true) {
				bool isPrime = true;
				foreach (int n in primesThusFar) {
					if (testPrime % n == 0) {
						isPrime = false;
						break;						
					}
				}
				if (isPrime) {
					primesThusFar.Add (testPrime);
					yield return testPrime;
				}
				testPrime += 2;
			}
		}
	}
}
