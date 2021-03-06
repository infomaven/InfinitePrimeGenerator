﻿# Infinite Prime Generator
PROBLEM: 
Develop a program to generate max prime value in 60 seconds

RULES: 
1. Use classic definition of a prime number: 
A prime number is an integer which is divisible by only 2 factors, itself 
 and 1. For example, 2, 3, 5, 7, 11, 13, 17 are prime numbers, but 1, 4, 6, 
 8, 9 are not prime. 

2. Program runs for exactly 60 seconds

3. Program calculates highest possible prime number in that amount of time

4. Program displays timer progress as well as each intermediate value calculated along the way

5. At conclusion, Program prints highest value reached 

=======================

ABOUT THIS SOLUTION: 
While arriving at a final version of the solution for this problem, 
I learned and tried a number of different algorithms to find an optimal solution. 
Key Observations and learnings for each are annotated below: 

1) Base case ("Naive" implementation): 
- uses modulus to test primality of each testPrime value
- uses C# yield return syntax to reduce overhead
- preloads list with known primes and checks only odd numbers for remainder of execution time
- Max value achieved in 60 seconds:  

2) Optimization: using square root instead of full testPrime
- Reduced number of comparisons for determining primality
- Max value achieved in 60 seconds:  

3) Optimization: Sieve of Eratosphenes:
- Has initial delay as the BitArray is loaded. This makes program flow/execution control more difficult
- Used internal BitArray collection to keep track of eligible primes. 
- Changing size of this internal BitArray had direct impact on the max prime values returned by the function
- There seemed to be a "sweet spot" in terms of the max prime returned. Once a certain point was passed, there were diminishing returns. 
For this particular experiement, the maximum prime values seemed to reach a plateau for array sizes between 300000000 and 300000560. 
Array sizes larger than this saw a steady decline in max prime values, which is an indicator of a need for further optimization.

Max Value achieved in 60 seconds: 27710693
=======
Reference-style: 
![alt text][chart]

[chart]: https://github.com/infomaven/InfinitePrimeGenerator/blob/master/maxPrime.png "Chart - Max Primes"

Max Value achieved in 60 seconds: 27710693. 
- BitArray size set to 300000000

NEXT STEPS: 
While preparing this code, several other algorithms were found, but there was not time to explore or implement them. 
I strongly believe this implementation could be optimized even further with one or more of these approaches. 

- Sieve of Atkins

- More extensive use of skip sets for multiples of existing primes  
https://en.wikibooks.org/wiki/Some_Basic_and_Inefficient_Prime_Number_Generating_Algorithms

- C# Parallel Extensions & LINQ

- Miller-Rabin Primality Test
https://en.wikipedia.org/wiki/Miller%E2%80%93Rabin_primality_test

=======





