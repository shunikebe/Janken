using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class CPM:Brain{
        public CPM(string name) : base(name) { }

        public override void select(){
            Random r = new Random();
            hand = r.Next(1,4);
            }

    }
}
