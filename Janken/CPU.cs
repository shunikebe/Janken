namespace Janken{
    using System;

    internal class CPU : Player{

        private int seed;
        private Random r;

        public CPU(string name, int seed):base(name){
            this.seed = seed;
            r = new Random(seed);
        }

        public override void Select(){
            Hand = r.Next(1, 4);
        }

    }
}
