using System;

namespace Janken{

    internal class User : Player{

        public User(string name):base(name){ }

        public override void Select(){

            Console.WriteLine(name + "さん、じゃんけんの手を入れてください。");
            Console.WriteLine("グー：１/ チョキ：２/ パー：３");

            while (true){
                try{hand = int.Parse(Console.ReadLine());}
                catch (FormatException ex){
                    Console.WriteLine(ex.Message);
                    hand = 0;
                }
                if (hand == Definition.Ro || hand == Definition.Sc || hand == Definition.Pa){break;}
                else{
                    Console.WriteLine("グー：１/ チョキ：２/ パー：３\nを入力してください。");
                }
            }
        }

    }
}
