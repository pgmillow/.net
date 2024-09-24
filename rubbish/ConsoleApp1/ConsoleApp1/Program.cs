using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("请输入一个整数：");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            List<int> primeFactors = GetPrimeFactors(number);
            Console.WriteLine("素数因子有：");
            foreach (int factor in primeFactors)
            {
                Console.WriteLine(factor);
            }
        }
        else
        {
            Console.WriteLine("输入的不是一个有效的整数。");
        }
    }

    static List<int> GetPrimeFactors(int number)
    {
        List<int> factors = new List<int>();
        for (int i = 2; i <= number; i++)
        {
            while (number % i == 0)
            {
                factors.Add(i);
                number /= i;
            }
        }
        return factors;
    }
}