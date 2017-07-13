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

            while (true){

                while (true){
                    Console.WriteLine("ユーザーの人数を教えてください");
                    try{
                        un = int.Parse(Console.ReadLine());
                        if (un >= 0) { break; }
                        else { Console.WriteLine("0以上の数を入力してください"); }
                    }
                    catch (Exception ex){
                        Console.WriteLine(ex.Message);
                    }
                }

                while (true){
                    Console.WriteLine("コンピューターの人数を教えてください");
                    try{
                        cn = int.Parse(Console.ReadLine());
                        if (cn >= 0) { break; }
                        else { Console.WriteLine("0以上の数を入力してください"); }
                    }
                    catch (Exception ex){
                        Console.WriteLine(ex.Message);
                    }
                }

                if (un + cn >= 2) { break; }
                else{
                    Console.WriteLine("合計で2人以上にしてください。");
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

        //ゲームの内容
        public abstract void Content();
        //ゲームデータの保存
        public abstract void Save();
        //ゲームデータの読込
        public abstract void Load();

    }
}
