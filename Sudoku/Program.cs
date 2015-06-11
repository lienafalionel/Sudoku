using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            //Application application = new Application(@"Fichier de sudoku résolution (version du 15 04 2015).sud");
            Application application = new Application(@"Sudokus à Résoudre.sud");

            Console.ReadKey();
        }
    }
}
