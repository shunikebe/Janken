namespace Janken{

    internal abstract class Player{

        public string Name { get; set; }
        public int Hand { get; set; } // じゃんけんの手１：グー、２：チョキ、３：パー
        public bool Result { get; set; } //勝ったかどうか
        public int Win { get; set; } // 勝った数
        public int Fight { get; set; } // 試合数

        public Player(string name){
            Name = name;
            Win = 0;
            Fight = 0;
        }

        public abstract void Select();
        public string Handname(){
            string s = string.Empty;
            if (Hand == Difinition.Ro){s = "グー";}
            else if (Hand == Difinition.Sc){s = "チョキ";}
            else if (Hand == Difinition.Pa){s = "パー";}

            return s;
        }

        public string Resultname(){
            string s = string.Empty;
            if (Result) {
                s = "勝ち";
                Fight++;
                Win++;
            }
            else {
                s = "負け";
                Fight++;
            }

            return s;
        }


    }
}
