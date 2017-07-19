namespace Janken{

    internal abstract class Player{

        public string name { get; }
        public int hand { get; set; } // じゃんけんの手１：グー、２：チョキ、３：パー
        public int result { get; set; } //playerの結果を表示する
        public int win { get; set; } // 勝った数
        public int fight { get; set; } // 試合数

        public Player(string name){
            this.name = name;
            win = 0;
            fight = 0;
        }


        public abstract void Select();

    }
}
