using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken{
    class Player:Brain{

        public Player(string name):base(name) { }



        public override void select(){
            Console.WriteLine(name + "さん、じゃんけんの手を入れてください。");
            Console.WriteLine("グー：１/ チョキ：２/ パー：３");
            while (true) {
                try {
                    hand = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                    hand = 0;
                }
                if(hand == Difinition.Ro || hand == Difinition.Sc || hand == Difinition.Pa) {break;}
                else { Console.WriteLine("グー：１/ チョキ：２/ パー：３\nを入力してください。"); }
            }           
        }

    }
}
