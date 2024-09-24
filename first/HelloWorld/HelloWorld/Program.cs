using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld
{
    using System;

    class Program
    {
        // 检查一个数是否为素数
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        // 找到指定数字的素数因子
        static void FindPrimeFactors(int number)
        {
            Console.WriteLine($"数字 {number} 的素数因子：");
            for (int i = 2; i <= number; i++)
            {
                if (number % i == 0 && IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("------请输入一个整数：------");
            int number = Convert.ToInt32(Console.ReadLine());
            FindPrimeFactors(number);
            Console.WriteLine("------请按任意键退出------");
            Console.ReadLine();
        }
    }

}
