
using System;
using System.Collections;
using System.Collections.Generic;

namespace InfinitePrimeGenerator {
	public static class SieveOfEratosthenes {

		private static int ApproximateNthPrime(int nn) {
			double n = (double)nn;
			double p;
			if (nn >= 7022)
			{
			    p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
			}
			else if (nn >= 6)
			{
			    p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
			}
			else if (nn > 0)
			{
			    p = new int[] { 2, 3, 5, 7, 11 }[nn - 1];
			}
			else
			{
			    p = 0;
			}
			return (int)p;
		}

// Find all primes up to and including the limit
private static BitArray BuildSieve(int limit)
{
    BitArray bits = new BitArray(limit + 1, true);
    bits[0] = false;
    bits[1] = false;
    for (int i = 0; i * i <= limit; i++)
    {
        if (bits[i])
        {
            for (int j = i * i; j <= limit; j += i)
            {
                bits[j] = false;
            }
        }
    }
    return bits;
}

public static List<int> GeneratedPrimes()
{
	int MAX_INT32 = 2147483647;
	int n = MAX_INT32;
    //int limit = ApproximateNthPrime(n);	// method is doing calculations that produce a positive number
    int limit = 300000000;
    Console.WriteLine ("DEBUG: limit as an int = " + limit);
    BitArray bits = BuildSieve(limit); // limit variable has lost its assigned value when called here
    List<int> primes = new List<int>();
    	for (int i = 0, found = 0; i < limit && found < n; i++)
    		{
        		if (bits[i])
        		{
            		primes.Add(i);
            		found++;
        		}
    		}
    		return primes;
		}
	}
}

