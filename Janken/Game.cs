using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken{

    internal abstract class Game{


        public int un { get; set; }
        public int cn { get; set; }
        public Player[] player { get; private set; }


        public Game() {
            un = cn = 0;
        }

        //ゲームに参加する人数を決める
        public void Member(){

            //string className = GetType().Name;
            //string className = GetType().FullName;
            //Console.WriteLine(className);

            while (true){
                Setun();
                Setcn();
                if (un + cn >= 2) { break; }
                else{
                    Console.WriteLine("合計で2人以上にしてください。");
                }

            }

        }

        //ユーザーの人数を決める
        public void Setun(){
            while (true){
                Console.WriteLine("ユーザーの人数を教えてください");
                try{
                    un = int.Parse(Console.ReadLine());
                    if (un >= 0) { break; }
                    else { Console.WriteLine("0以上の数を入力してください"); }
                }catch (Exception ex){
                    Console.WriteLine(ex.Message);
                }
            }

        }
        //コンピューターの人数を決める
        public void Setcn(){
            while (true){
                Console.WriteLine("コンピューターの人数を教えてください");
                try{
                    cn = int.Parse(Console.ReadLine());
                    if (cn >= 0) { break; }
                    else { Console.WriteLine("0以上の数を入力してください"); }
                }catch (Exception ex){
                    Console.WriteLine(ex.Message);
                }
            }

        }

        //playerインスタンスを生成
        public void Make(){
            player = new Player[un + cn];
            Random r = new Random();
            for (int i = 0; i < un; i++) { player[i] = new User("P" + i); }
            for (int i = 0; i < cn; i++) { player[i + un] = new CPU("C" + i, r.Next()); }
        }

        //再試行の判定
        public bool Again(){
            string s;
            Console.WriteLine("もう一度しますか？\nする場合は\"Y\"を押してください");
            s = Console.ReadLine();
            if (s == "Y" || s == "y" || s == string.Empty) { return true; }
            else{return false;}
        }

        //各Playerの勝率を表示する
        public void ShowWinRate(){

            string s1 = ":", s2 = "%";
            Console.WriteLine("今回の勝率");

            for (int i = 0; i < player.Length; i++){
                double rate = Math.Round(100.0 * player[i].win / player[i].fight, 1);

                //小数点を合わせるためにspaceを入れる
                if (rate < 10) { s1 = ":  "; }
                else if (rate < 100) { s1 = ": "; }
                else { s1 = ":"; }

                //小数点以下が0の時、0を付け足す
                if (rate == (int)rate) { s2 = ".0%"; }
                else { s2 = "%"; }

                Console.WriteLine(player[i].name + s1 + rate + s2);
            }

        }

        //ゲーム開始時
        public abstract void Setup();
        //ゲーム中
        public abstract void Run();
        //ゲーム終了時
        public abstract void Closed();


        //ゲームデータの保存
        public abstract void Save();
        //ゲームデータの読込
        public abstract void Load();

    }
}
