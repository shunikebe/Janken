using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Janken{

    internal class Janken:Game{

        public Janken(){ }

        public override void Content(){
            // じゃんけんの設定
            SetUp();
            //じゃんけん開始
            Frow();
        }

        public override void Save(){

            if (Directory.Exists("Data") == false){
                Directory.CreateDirectory("Data");
            }

            try{
                using (StreamWriter writer = new StreamWriter(@"Data\Data.csv", false, Encoding.Default)){
                    writer.WriteLine(un + "," + cn);
                    for (int i = 0; i < player.Length; i++){
                        writer.WriteLine(player[i].Name + "," + player[i].Win + "," + player[i].Fight + "," + Math.Round(100.0 * player[i].Win / player[i].Fight, 1));
                    }
                }
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        public override void Load(){
            Random r = new Random();
            if (File.Exists(@"Data\Data.csv") == false){
                Console.WriteLine("存在していなかったのでp0とc0を生成しました");
                un = cn = 1;
                player = new Player[un + cn];
                for (int a = 0; a < un; a++) { player[a] = new User("P" + a); }
                for (int a = 0; a < cn; a++) { player[a + un] = new CPU("C" + a, r.Next()); }
            }else{
                try{
                    using (StreamReader reader = new StreamReader(@"Data\Data.csv", Encoding.Default)){
                        string line;
                        line = reader.ReadLine();
                        string[] ward = line.Split(',');
                        un = int.Parse(ward[0]);
                        cn = int.Parse(ward[1]);
                        player = new Player[un + cn];
                        for (int a = 0; a < un; a++) { player[a] = new User("P" + a); }
                        for (int a = 0; a < cn; a++) { player[a + un] = new CPU("C" + a, r.Next()); }

                        int i = 0;
                        while ((line = reader.ReadLine()) != null){
                            string[] ward1 = line.Split(',');
                            player[i].Win = int.Parse(ward1[1]);
                            player[i].Fight = int.Parse(ward1[2]);
                            i++;
                        }
                    }
                }
                catch (Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine("存在していなかったのでp0とc0を生成しました");
                    un = cn = 1;
                    player = new Player[un + cn];
                    for (int a = 0; a < un; a++) { player[a] = new User("P" + a); }
                    for (int a = 0; a < cn; a++) { player[a + un] = new CPU("C" + a, r.Next()); }
                }
            }
        }


        //じゃんけんの設定
        private void SetUp(){

            string start = string.Empty;
            do {
                Console.WriteLine("初めから：１");
                Console.WriteLine("続きから：２");
                start = Console.ReadLine();
                if (start == "1"){ Member();}
                else if (start == "2") { Load(); }
                else{
                    start = string.Empty;
                    player = new Player[1];
                }
            } while (start == string.Empty);
        }

        //じゃんけんの本体
        private void Frow(){

            bool flag = true;
            //ゲーム開始
            while (flag){
                //じゃんけんの手を決める
                for (int i = 0; i < un + cn; i++) { player[i].Select(); }

                flag = Judge();

                if (flag){ // あいこの時
                  // 結果を表示
                    for (int i = 0; i < player.Length; i++){
                        Console.WriteLine(player[i].Name + ": " + player[i].Handname());
                    }
                    Console.WriteLine("あいこです。");
                }
                else{ // 決着が着いたとき
                    // 結果を表示&勝利数などの処理
                    for (int i = 0; i < player.Length; i++){
                        Console.WriteLine(player[i].Name + ": " + player[i].Handname() + ": " + player[i].Resultname());
                    }
                    flag = Tryagain();
                }
            }

        }

        //じゃんけんの勝敗判定
        private bool Judge(){

            int n, a, b;
            List<int> hands = new List<int>();

            // 出された手の種類を数えている
            for (int i = 0; i < player.Length; i++){
                if (hands.Contains(player[i].Hand) == false){
                    hands.Add(player[i].Hand);
                }
            }

            if (hands.Count() == 2){ // 2種類なら勝敗が決まる
                a = hands[0];
                b = hands[1];

                // 元Judge(a,b)
                if (a < b){
                    if (a == Difinition.Ro && b == Difinition.Pa) { n = b; } // b WIN
                    else { n = a; } // a WIN
                }else if (a > b){
                    if (a == Difinition.Pa && b == Difinition.Ro) { n = a; } // a WIN
                    else { n = b; } // b WIN
                }else { n = 0; } // あいこ
                // 元Judge(a,b)ここまで

            }
            else { n = 0; } // それ以外ならあいこ

            if (n == 0) { return true; } // あいこ
            else{ // 決着が決まった時：nの値が勝った手
                for (int i = 0; i < player.Length; i++){
                    if (player[i].Hand == n){
                        player[i].Result = true;
                    }else{
                        player[i].Result = false;
                    }
                }
                return false;
            }

        }

        //再試行の判定
        private bool Tryagain(){

            string s;
            Console.WriteLine("もう一度しますか？\nする場合は\"Y\"を押してください");
            s = Console.ReadLine();
            if (s == "Y" || s == "y") { return true; }
            else{
                Save();
                Console.WriteLine("今回の勝率");
                for (int i = 0; i < player.Length; i++){
                    Console.WriteLine(player[i].Name + ":" + Math.Round(100.0 * player[i].Win / player[i].Fight, 1) + "%");
                }
                return false;
            }

        }


    }
}
