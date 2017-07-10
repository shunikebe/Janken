using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken{
   
    abstract class Brain{

        public string name { get; set; }
        public int hand { get; set; }//じゃんけんの手１：グー、２：チョキ、３：パー
        public bool result { get; set; }//勝ったかどうか

        public Brain(string Name) { name = Name; }



        public abstract void select();
        public string handname(){
            string s = "";
            if (hand == Difinition.Ro) { s = "グー"; }
            else if (hand == Difinition.Sc) { s = "チョキ"; }
            else if (hand == Difinition.Pa) { s = "パー"; }
            
            return s;
        }

    }
}
