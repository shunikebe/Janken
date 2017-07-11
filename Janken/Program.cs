namespace Janken
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class Program
    {
            private static void Main(string[] args)
            {
            Brain[] brain;
            bool flag = true;
            int pn, cn;
            string start = string.Empty;

            // じゃんけんの設定
            do
            {
                Console.WriteLine("初めから：１");
                Console.WriteLine("続きから：２");
                start = Console.ReadLine();
                if (start == "1")
                {
                    while (Menber(out pn, out cn))
                    {
                    }

                    brain = new Brain[pn + cn];
                    for (int i = 0; i < pn; i++)
                    {
                        brain[i] = new Player("P" + i);
                    }

                    for (int i = 0; i < cn; i++)
                    {
                        brain[i + pn] = new CPM("C" + i);
                    }
                }
                else if (start == "2")
                {
                    Load(out brain, out pn, out cn);
                }
                else
                {
                    start = string.Empty;
                    brain = new Brain[1];
                    pn = cn = 0;
                }
            }
            while (start == string.Empty);

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
                    System.Threading.Thread.Sleep(4);
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
                        brain[i].Fight++;
                        if (brain[i].Result)
                        {
                            Console.WriteLine(brain[i].Name + ": " + brain[i].Handname() + ":勝ち");
                            brain[i].Win++;
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
                    else
                    {
                        Save(brain, pn, cn);

                        Console.WriteLine("今回の勝率");
                        for (int i = 0; i < brain.Length; i++)
                        {
                            Console.WriteLine(brain[i].Name + ":" + Math.Round(100.0 * brain[i].Win / brain[i].Fight, 1) + "%");
                        }

                        Console.WriteLine("続行するには何かキーを押してください。");
                        Console.Read();
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

        private static bool Menber(out int pn, out int cn)
        {
            pn = cn = -1;
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

                if (pn >= 0)
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

                if (cn >= 0)
                {
                    break;
                }
            }

            if (pn + cn >= 2)
            {
                return false;
            }
            else
            {
                Console.WriteLine("合計で2人以上にしてください。");
                return true;
            }
        }

        private static void Save(Brain[] brain, int pn, int cn)
        {
            if (Directory.Exists("Data") == false)
            {
                Directory.CreateDirectory("Data");
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(
                    @"Data\Data.csv", false, Encoding.Default))
                {
                    writer.WriteLine(pn + "," + cn);
                    for (int i = 0; i < brain.Length; i++)
                    {
                        writer.WriteLine(brain[i].Name + "," + brain[i].Win + "," + brain[i].Fight + "," + Math.Round(100.0 * brain[i].Win / brain[i].Fight, 1));
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("エラーが起きました");
            }
        }

        private static void Load(out Brain[] brain, out int pn, out int cn)
        {
            if (File.Exists(@"Data\Data.csv") == false)
            {
                pn = cn = 0;
                brain = new Brain[pn + cn];
            }
            else
            {
                try
                {
                    using (StreamReader reader = new StreamReader(
                        @"Data\Data.csv", Encoding.Default))
                    {
                        string line;
                        line = reader.ReadLine();
                        string[] ward = line.Split(',');
                        pn = int.Parse(ward[0]);
                        cn = int.Parse(ward[1]);
                        brain = new Brain[pn + cn];
                        for (int a = 0; a < pn; a++)
                        {
                            brain[a] = new Player("P" + a);
                        }

                        for (int a = 0; a < cn; a++)
                        {
                            brain[a + pn] = new CPM("C" + a);
                        }

                        int i = 0;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] ward1 = line.Split(',');
                            brain[i].Win = int.Parse(ward1[1]);
                            brain[i].Fight = int.Parse(ward1[2]);
                            i++;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("エラーが起きました");
                    pn = cn = 0;
                    brain = new Brain[pn + cn];
                }
            }
        }
    }
}
