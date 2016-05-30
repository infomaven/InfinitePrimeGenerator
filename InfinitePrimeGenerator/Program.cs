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

			// using Sieve of Eratosthenes 
			foreach (double p in SieveOfEratosthenes.GeneratedPrimes())
			{
				ts = stopwatch.Elapsed;
				string elapsedTime = String.Format("{0:0000}:{1:0000}.{2:00000000000000}",
					                     ts.Minutes, ts.Seconds, ts.Milliseconds);
				if (ts.Minutes == 1)
				{
					Console.WriteLine("Max Prime = " + p);
					break;
				}
				else
				{
					Console.Write(p + ": " + elapsedTime + "\n");
				}
			}
		
				stopwatch.Stop();
		}		    
	}	
}
