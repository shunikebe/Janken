using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken{
   
    abstract class Brain{

        public int hand { get; set; }//じゃんけんの手１：グー、２：チョキ、３：パー

        public Brain() { }



        public abstract int select();





    }
}
