using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeeAPp
{
    class Program
    {
        static void Main(string[] args)
        {
            var buf = new Buffer<double>();

            foreach (var item in buf)
            {
                
            }

            ProcessInput(buf);

            foreach (var item in buf)
            {
                Console.WriteLine(item);
            }

            ProcessBuffer(buf);

            Console.ReadLine();
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine("Sum is " + sum);

        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var parsed = false;
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;

            }
        }

    }




}
