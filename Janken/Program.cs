using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Janken{

    internal class Program{

        private static void Main(string[] args){

            Game game = new Janken();

            game.Setup();
            game.Run();
            game.Closed();

            Console.WriteLine("続行するには何かキーを押してください。");
            Console.Read();
        }
    }
}
