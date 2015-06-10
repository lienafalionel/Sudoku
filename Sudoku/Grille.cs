using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    class Grille
    {
        private string nom;
        private string date;
        private string symboles;
        private int longueur;
        private Case[][] cases; 
        public Grille()
        {
            
        }

        public Grille(string nom, string date, string symboles, int longueur)
        {
            Nom = nom;
            Date = date;
            Symboles = symboles;
            Longueur = longueur;
            cases = new Case[longueur][];
        }

        public bool EstValide()
        {
            Console.WriteLine(VerifSymboles() + " " + VerifLignes() + VerifColonnes());
            return (VerifSymboles() && VerifLignes() && VerifColonnes());
        }

        private bool VerifColonnes()
        {
            List<Case[]> colonnes = new List<Case[]>();

            for (int i = 0; i < 9; i++)
            {
                Case[] array = new Case[9];
                for (int j = 0; j < 9; j++)
                {
                    array[j] = cases[j][i];
                }
                colonnes.Add(array);
            }

            foreach(Case[] colonne in colonnes)
            {
                char[] symbolesArray = Symboles.ToCharArray();
                Array.Sort(symbolesArray);
                char[] ligneValeur = new char[9];
                for (int i = 0; i < colonne.Length; i++)
                {
                    ligneValeur[i] = colonne[i].Valeur;
                }
                Array.Sort(ligneValeur);

                if (!Enumerable.SequenceEqual(symbolesArray, ligneValeur))
                {
                    return false;
                }

                if (colonne.Length != 9)
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerifSymboles()
        {
            foreach (Case[] t in Cases)
            {
                foreach (Case c in t)
                {
                    if ((!Symboles.Contains(c.Valeur)) || (c.Valeur != '.'))
                    {
                        return false;
                    }
                    c.Hypotheses = Symboles.ToCharArray();
                }
            }
            return true;
        }

        private bool VerifLignes()
        {
            char[] symbolesArray = Symboles.ToCharArray();
            Array.Sort(symbolesArray);
            foreach (Case[] ligne in Cases)
            {
                char[] ligneValeur = new char[9];
                for (int i = 0; i < ligne.Length; i++)
                {
                    ligneValeur[i] = ligne[i].Valeur;
                }
                Array.Sort(ligneValeur);

                if (!Enumerable.SequenceEqual(symbolesArray, ligneValeur))
                {
                    return false;
                }
    
                if (ligne.Length != 9)
                {
                    return false;
                }
            }
            return true;
        }

        public void resoudre()
        {
            foreach (Case[] t in Cases)
            {
                foreach (Case c in t)
                {
                    if (c.Valeur == '.')
                    {
                        IEnumerable<char> s = c.Hypotheses.Intersect(Symboles.ToCharArray());

                        if (c.NbreHypothese == 1)
                        {
                            c.Valeur = c.Hypotheses[0];
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            string grille = "";
            foreach (Case[] t in Cases)
            {
                foreach (Case c in t)
                {
                    grille += c.Valeur;
                }
                grille += "\n";
            }
            return grille;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Symboles
        {
            get { return symboles; }
            set { symboles = value; }
        }

        public int Longueur
        {
            get { return longueur; }
            set { longueur = value; }
        }

        public Case[][] Cases
        {
            get { return cases; }
            set { cases = value; }
        }
    }
}