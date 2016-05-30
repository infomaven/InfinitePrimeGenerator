using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows.Markup;
using InfinitePrimeGenerator;



namespace InfinitePrimeGenerator
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			TimeSpan ts;

		

			/// base case (brute force) -- 
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


			// using Sieve of Eratosthenes 
//			foreach (double p in SieveOfEratosthenes.GeneratedPrimes())
//			{
//				ts = stopwatch.Elapsed;
//				string elapsedTime = String.Format("{0:0000}:{1:0000}.{2:00000000000000}",
//					                     ts.Minutes, ts.Seconds, ts.Milliseconds);
//				if (ts.Minutes == 1)
//				{
//					Console.WriteLine("Max Prime = " + p);
//					break;
//				}
//				else
//				{
//					Console.Write(p + ": " + elapsedTime + "\n");
//				}
//			}
//-----------------
		
				stopwatch.Stop();
		}
		

		/// <summary>
		/// Method that generates a list of Primes using odd number testPrimes. First two primes are front loaded. 
		/// </summary>
		/// <returns>The primes.</returns>
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
			    // start out with everything as Prime and try to disqualify testPrime
				bool isPrime = true;			
				foreach (double n in primesThusFar) {
					/// firstCust: eliminate testPrime if it can be factored by anything from our list
//					if (testPrime % n == 0) {
//						isPrime = false;
//						break;		            				
//					}
                    /// square root added as an optimization
					testSqRoot = Math.Sqrt (testPrime);

					/// secondCut: eliminate testPrime if it's square root can be factored by anything from our list
					if ( testSqRoot < n )
						break;
					if ( testSqRoot % n == 0 ) {
						isPrime = false;
						break;
					}

					/// thirdCut: Sieve of Eratosthenes & list of exclusions

                   
				}
				// if no disqualification is found, add testPrime to list
				if (isPrime) {
					primesThusFar.Add (testPrime);
					yield return testPrime;
				}
				// make sure testPrime is always an odd number
				testPrime += 2;
			}
		}
		    
	}
	
}
