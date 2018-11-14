using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace projectIntefaces
{
    class Program
    {
        static void Main(string[] args)
        {
            ICubeController cc = new TestCubeController();
            cc.DoMove(Move.L);
            Debug.Assert(cc.GetMoves().Count == 1);

            Console.WriteLine("Hello");
        }
    }
}
