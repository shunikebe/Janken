using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Janken{

    internal class Program{

        private static void Main(string[] args){

            Game janken = new Janken();
            janken.Content();
            Console.WriteLine("続行するには何かキーを押してください。");
            Console.Read();
        }
    }
}
