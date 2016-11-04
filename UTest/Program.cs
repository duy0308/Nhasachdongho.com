using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            for (int k = 0; k < 10; k++)
            {
                long[] avg = new long[3];
                for (int j = 0; j < 3; j++)
                {
                    long total = 0;
                    ProductDAO dao = new ProductDAO();
                    for (int i = 0; i < 1000; i++)
                    {
                        st.Restart();
                        var lst = dao.GetAllProduct(1).ToList();
                        st.Stop();
                        total += st.ElapsedMilliseconds;
                        //Console.WriteLine(i.ToString() + ":" + st.ElapsedMilliseconds.ToString() + "ms");
                    }
                    avg[j] = total / 1000;
                    Console.WriteLine("TB" + j.ToString() + ": " + (avg[j]).ToString() + "ms");
                }
                Console.WriteLine("AVG: " + ((avg[0] + avg[1] + avg[2]) / 3).ToString() + "ms");
                Console.WriteLine("============================");
            }
           
            Console.ReadKey();
        }
    }
}
