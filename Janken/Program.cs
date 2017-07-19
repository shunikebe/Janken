using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Janken{

    internal class Program{

        private static void Main(string[] args){

            Game game = SelectGame("Janken");

            game.Setup();
            game.Run();
            game.Closed();

            Console.WriteLine("続行するには何かキーを押してください。");
            Console.Read();
        }

        private static Game SelectGame(string gamename){
            Game game = null;

            if (gamename == "Janken") { game = new Janken(); }

            return game;

        }

    }
}
