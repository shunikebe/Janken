using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Janken{

    internal class Janken:Game{

        public Janken(){ }

        public override void Save(){

            if (Directory.Exists("Data") == false){
                Directory.CreateDirectory("Data");
            }

            try{
                using (StreamWriter writer = new StreamWriter(@"Data\Data.csv", false, Encoding.Default)){
                    writer.WriteLine(un + "," + cn);
                    for (int i = 0; i < player.Length; i++){
                        writer.WriteLine(player[i].name + "," + player[i].win + "," + player[i].fight + "," + Math.Round(100.0 * player[i].win / player[i].fight, 1));
                    }
                }
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }
        public override void Load(){

            try{
                using (StreamReader reader = new StreamReader(@"Data\Data.csv", Encoding.Default)){
                    string line;
                    line = reader.ReadLine();
                    string[] ward = line.Split(',');
                    un = int.Parse(ward[0]);
                    cn = int.Parse(ward[1]);
                    Make();
                    int i = 0;
                    while ((line = reader.ReadLine()) != null){
                        string[] ward1 = line.Split(',');
                        player[i].win = int.Parse(ward1[1]);
                        player[i].fight = int.Parse(ward1[2]);
                        i++;
                    }
                }
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine("読み取りに失敗したのでp0とc0を生成しました");
                un = cn = 1;
                Make();
            }

        }

        public override void Setup(){

            string start = string.Empty;
            do {
                Console.WriteLine("初めから：１");
                Console.WriteLine("続きから：２");
                start = Console.ReadLine();
                if (start == "1" || start == "１"){
                    Member();
                    Make();
                }
                else if (start == "2" || start == "２") {Load();}
                else{start = string.Empty;}
            } while (start == string.Empty);
        }
        public override void Run(){
            //ゲーム開始
            while (true){
                //じゃんけんの手を決める
                for (int i = 0; i < un + cn; i++) { player[i].Select(); }

                if (Judge()){ // あいこの時
                    Console.WriteLine("あいこです。");
                }
                else{ // 決着が着いたとき
                   if (!Again()) { break; }
                }
            }

        }
        public override void Closed(){
            Save();
            ShowWinRate();
        }

        //試合結果があいこかどうか判断
        //試合結果を反映・出力
        private bool Judge(){

            int a, b, n = 0;
            //試合結果があいこかどうか判断
            if (TypeCount(out a, out b) == 2){ // 2種類なら勝敗が決まる
                // 元Judge(a,b)
                if (a < b){
                    if (a == Definition.Ro && b == Definition.Pa) { n = b; } // b WIN
                    else { n = a; } // a WIN
                }else if (a > b){
                    if (a == Definition.Pa && b == Definition.Ro) { n = a; } // a WIN
                    else { n = b; } // b WIN
                }
                //else { n = 0; } // あいこ
                // 元Judge(a,b)ここまで
            }
            //else { n = 0; }// それ以外ならあいこ

            //試合結果を反映・出力
            WriteResult(n);
            ProcessResult();
            ShowResult();

            if (n == 0) {return true; } // あいこ
            else{ return false; }

        }
        //全プレイヤーが出した手の種類を数える
        private int TypeCount(out int a, out int b){

            a = b = 0;
            List<int> hands = new List<int>();

            for (int i = 0; i < player.Length; i++){
                if (hands.Contains(player[i].hand) == false){
                    hands.Add(player[i].hand);
                }
            }

            if (hands.Count() == 2){
                a = hands[0];
                b = hands[1];
            }

            return hands.Count();
        }
        //各Playerの結果を書き込む
        private void WriteResult(int n){
            for (int i = 0; i < player.Length; i++){
                if (n == 0) { player[i].result = Definition.DRAW; }
                else if (player[i].hand == n){ player[i].result = Definition.WIN; }
                else { player[i].result = Definition.LOSE; }
            }
        }
        //各Playerの結果を表示する
        private void ShowResult(){
            for (int i = 0; i < player.Length; i++){
                Console.WriteLine(player[i].name + ": " + Handname(i) + Resultname(i));
            }
        }
        //出した手の名前
        private string Handname(int i){
            string s = string.Empty;
            if (player[i].hand == Definition.Ro) { s = "グー"; }
            else if (player[i].hand == Definition.Sc) { s = "チョキ"; }
            else if (player[i].hand == Definition.Pa) { s = "パー"; }

            return s;
        }
        //試合結果の名前
        private string Resultname(int i){
            string s = string.Empty;

            if (player[i].result == Definition.WIN){
                s = ":勝ち";
            }
            else if (player[i].result == Definition.LOSE){
                s = ":負け";
            }
            else if (player[i].result == Definition.DRAW){
                s = string.Empty;
            }
            return s;
        }

    }
}
