using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken{
    class Player:Brain{

        public Player() { }



        public override int select(){
            int n;


            while (true) {
                try {
                    n = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                    n = 0;
                }

                if(n == 1 || n == 2 || n == 3) {

                    if(n == 1) { Console.WriteLine("あなた：グー"); }
                    else if (n == 2) { Console.WriteLine("あなた：チョキ"); }
                    else if (n == 3) { Console.WriteLine("あなた：パー"); }
                    break;

                }
                else { Console.WriteLine("1or2or3を入力してください。"); }
            }
            return n;
        }





    }
}
