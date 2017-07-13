using System;

namespace Janken{

    internal class User : Player{

        public User(string name):base(name){ }

        public override void Select(){

            Console.WriteLine(Name + "さん、じゃんけんの手を入れてください。");
            Console.WriteLine("グー：１/ チョキ：２/ パー：３");

            while (true){
                try{Hand = int.Parse(Console.ReadLine());}
                catch (FormatException ex){
                    Console.WriteLine(ex.Message);
                    Hand = 0;
                }
                if (Hand == Difinition.Ro || Hand == Difinition.Sc || Hand == Difinition.Pa){break;}
                else{
                    Console.WriteLine("グー：１/ チョキ：２/ パー：３\nを入力してください。");
                }
            }
        }

    }
}
