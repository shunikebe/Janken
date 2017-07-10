﻿namespace Janken
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
            private static void Main(string[] args)
            {
            Brain[] brain;
            bool flag = true;
            int pn, cn;

            // 人数決め
            Menber(out pn, out cn);
            brain = new Brain[pn + cn];
            for (int i = 0; i < pn; i++)
            {
                brain[i] = new Player("P" + i);
            }

            for (int i = 0; i < cn; i++)
            {
                brain[i + pn] = new CPM("C" + i);
            }

            while (flag)
            {
                // じゃんけん開始player
                for (int i = 0; i < pn; i++)
                {
                    brain[i].Select();
                }

                // じゃんけん開始CPM
                for (int i = 0; i < cn; i++)
                {
                    brain[i + pn].Select();
                    System.Threading.Thread.Sleep(5);
                }

                flag = Judge(ref brain);

                if (flag)
                { // あいこの時
                     // 結果を表示
                    for (int i = 0; i < brain.Length; i++)
                    {
                        Console.WriteLine(brain[i].Name + ": " + brain[i].Handname());
                    }

                    Console.WriteLine("あいこです。");
                }
                else
                { // 決着が着いたとき
                    // 結果を表示
                    for (int i = 0; i < brain.Length; i++)
                    {
                        if (brain[i].Result)
                        {
                            Console.WriteLine(brain[i].Name + ": " + brain[i].Handname() + ":勝ち");
                        }
                        else
                        {
                            Console.WriteLine(brain[i].Name + ": " + brain[i].Handname() + ":負け");
                        }
                    }

                    string s;
                    Console.WriteLine("もう一度しますか？\nする場合は\"Y\"を押してください");
                    s = Console.ReadLine();
                    if (s == "Y" || s == "y")
                    {
                        flag = true;
                    }
                }
            }
        }

        private static bool Judge(ref Brain[] brain)
        {
            int n, a, b;
            List<int> hands = new List<int>();

            // 出された手の種類を数えている
            for (int i = 0; i < brain.Length; i++)
            {
               if (hands.Contains(brain[i].Hand) == false)
                {
                    hands.Add(brain[i].Hand);
                }
            }

            if (hands.Count() == 2)
            { // 2種類なら勝敗が決まる
                a = hands[0];
                b = hands[1];

                // 元Judge(a,b)
                if (a < b)
                {
                    if (a == Difinition.Ro && b == Difinition.Pa)
                    {
                        n = b;
                    } // b WIN
                    else
                    {
                        n = a;
                    } // a WIN
                }
                else if (a > b)
                {
                    if (a == Difinition.Pa && b == Difinition.Ro)
                    {
                        n = a;
                    } // a WIN
                    else
                    {
                        n = b;
                    } // b WIN
                }
                else
                {
                    n = 0;
                } // あいこ

                // 元Judge(a,b)ここまで
            }
            else
            {
                n = 0;
            } // それ以外ならあいこ

            if (n == 0)
            {
                return true;
            } // あいこ
            else
            { // 決着が決まった時：nの値が勝った手
                for (int i = 0; i < brain.Length; i++)
                {
                    if (brain[i].Hand == n)
                    {
                        brain[i].Result = true;
                    }
                    else
                    {
                        brain[i].Result = false;
                    }
                }

                return false;
            }
        }

        private static void Menber(out int pn, out int cn)
        {
            pn = cn = 0;
            while (true)
            {
                Console.WriteLine("ユーザーの人数を教えてください");
                try
                {
                   pn = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (pn != 0)
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("コンピューターの人数を教えてください");
                try
                {
                    cn = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (cn != 0)
                {
                    break;
                }
            }
        }
    }
}