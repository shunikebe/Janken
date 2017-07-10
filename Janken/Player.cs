namespace Janken
{
    using System;

    internal class Player : Brain
    {
        public Player(string name)
            : base(name)
        {
        }

        public override void Select()
        {
            Console.WriteLine(this.Name + "さん、じゃんけんの手を入れてください。");
            Console.WriteLine("グー：１/ チョキ：２/ パー：３");
            while (true)
            {
                try
                {
                    this.Hand = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    this.Hand = 0;
                }

                if (this.Hand == Difinition.Ro || this.Hand == Difinition.Sc || this.Hand == Difinition.Pa)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("グー：１/ チョキ：２/ パー：３\nを入力してください。");
                }
            }
        }
    }
}
