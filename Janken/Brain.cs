namespace Janken{

    internal abstract class Brain{

        public string Name { get; set; }
        public int Hand { get; set; } // じゃんけんの手１：グー、２：チョキ、３：パー
        public bool Result { get; set; } //じゃんけんの結果 0:負け、1:勝ち、2:あいこ
        public int Win { get; set; } // 勝った数
        public int Fight { get; set; } // 試合数

        public Brain(string name){
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
