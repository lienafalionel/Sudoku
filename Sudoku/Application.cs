using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Application
    {
        private List<Grille> grilles = new List<Grille>();
        private string pathFile;

        public Application(string path)
        {
            pathFile = path;
            parseGrilles();
            if(estValide())
            {
                resoudreGrilles();
            }
        }

        private bool estValide()
        {
            foreach (Grille grille in grilles)
            {
                if (!grille.EstValide())
                {
                    return false;
                }
            }
            return true;
        }

        private void parseGrilles()
        {
            string line;
            StreamReader file = new StreamReader(pathFile);
            while ((line = file.ReadLine()) != null)
            {
                string nom = file.ReadLine();
                string date = file.ReadLine();
                string symboles = file.ReadLine();
                int longueur = symboles.Length;
                Grille grille = new Grille(nom, date, symboles, longueur);
                for (int i = 0; i < longueur; i++)
                {
                    grille.Cases[i] = new Case[longueur];
                    for (int j = 0; j < longueur; j++)
                    {
                        grille.Cases[i][j] = new Case();
                        grille.Cases[i][j].Valeur = (char)file.Read();
                    }
                    char tabulation = (char)file.Read();
                    char sautDeLigne = (char)file.Read();
                }
                grilles.Add(grille);
            }
            file.Close();
        }

        private void resoudreGrilles()
        {
            grilles[0].resoudre();
            Console.WriteLine(grilles[0].ToString());
        }

        public List<Grille> Grilles
        {
            get { return grilles; }
            set { grilles = value; }
        }
    }
}
