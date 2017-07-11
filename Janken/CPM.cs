namespace Janken{
    using System;

    internal class CPM : Brain{

        public CPM(string name):base(name){ }

        public override void Select(){

            Random r = new Random();
            Hand = r.Next(1, 4);
        }
    }
}
