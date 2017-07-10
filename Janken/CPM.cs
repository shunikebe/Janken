using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class CPM:Brain{


        public CPM() { }

        public override int select(){
            int n = 0;
            Random r = new Random();

            n = r.Next(1,4);
            Console.WriteLine(n);
            if (n == 1) { Console.WriteLine("ＣＰＭ：グー"); }
            else if (n == 2) { Console.WriteLine("ＣＰＭ：チョキ"); }
            else if (n == 3) { Console.WriteLine("ＣＰＭ：パー"); }

            return n;
        }



    }
}
