using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class Program
    {




        static void Main(string[] args)
        {
            Player player = new Player();
            CPM cpm = new CPM();
            bool flag = true;

            while (flag) {
                Console.WriteLine("じゃんけんの手を入れてください。");



                flag = Judge(player.select(), cpm.select());
                if (!flag){//決着が着いたとき
                    string s;
                    Console.WriteLine("もう一度しますか？\nする場合は\"Y\"を押してください");
                    s = Console.ReadLine();
                    if(s == "Y" || s == "y") { flag = true; }
                }
            }



        }


        static private bool Judge(int a,int b){
            int n = 0;

            if (a < b) {
                if (a == 1 && b == 3) { n = 2; }//b WIN
                else { n = 1; }//a WIN
            }
            else if(a > b){
                if (a == 3 && b == 1) { n = 1; }//a WIN
                else { n = 2; }//b WIN
            }
            else { n = 0; }//あいこ


            switch (n)
            {
                case 0:
                    Console.WriteLine("あいこです。");
                    return true;
                    //break;
                case 1:
                    Console.WriteLine("あなたの勝ちです。");
                    return false;
                //break;
                case 2:
                    Console.WriteLine("あなたの負けです。");
                    return false;
                //break;
                default:
                    return true;

            }



            
        }

    }
}
