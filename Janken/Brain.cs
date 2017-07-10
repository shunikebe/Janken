namespace Janken
{
    internal abstract class Brain
    {
        public Brain(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public int Hand { get; set; } // じゃんけんの手１：グー、２：チョキ、３：パー

        public bool Result { get; set; } // 勝ったかどうか

        public abstract void Select();

        public string Handname()
        {
            string s = string.Empty;
            if (this.Hand == Difinition.Ro)
            {
                s = "グー";
            }
            else if (this.Hand == Difinition.Sc)
            {
                s = "チョキ";
            }
            else if (this.Hand == Difinition.Pa)
            {
                s = "パー";
            }

            return s;
        }
    }
}
