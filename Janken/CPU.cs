namespace Janken{
    using System;

    internal class CPU : Brain{

        public CPU(string name):base(name){ }

        public override void Select(){

            Random r = new Random();
            Hand = r.Next(1, 4);
        }
    }
}
