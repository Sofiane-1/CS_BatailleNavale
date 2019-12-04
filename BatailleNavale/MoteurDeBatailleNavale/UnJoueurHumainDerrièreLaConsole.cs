using System;
using System.Collections.Generic;
using System.Text;

namespace MoteurDeBatailleNavale
{
    public class UnJoueurHumainDerrièreLaConsole : IContratDuJoueurDeBatailleNavale
    {
        public string Pseudo
        {
            get;   
        }

        public UnJoueurHumainDerrièreLaConsole()
        {
            string saisie = Console.ReadLine();
            this.Pseudo = saisie;
        }
        public CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir()
        {
            Console.WriteLine(Pseudo + "Veuillez choisir une coordonnée valide. Entre 'A' et 'J'.");          
            string saisieLettre = Console.ReadLine();
            char letter = Char.Parse(saisieLettre);
            Console.WriteLine(Pseudo + "Veuillez choisir une coordonnée valide. Entre  '1' à '10'");
            string saisieChiffre= Console.ReadLine();
            byte number = Byte.Parse(saisieChiffre);

            CoordonnéesDeBatailleNavale data = new CoordonnéesDeBatailleNavale(letter, number);

            return data;


        }

        public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale cbn, CoordonnéesDeBatailleNavale.RésultatDeTir rt)
        {

            Console.WriteLine(rt);

        }

        public CoordonnéesDeBatailleNavale.RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale cbn)
        {
            Console.WriteLine(Pseudo + "Veuillez saisir le résultat de tir de (Inconnu, Raté, Touché, TouchéCoulé, TouchéCouléFinal)" +
                " : " + cbn.Colonne + " " + cbn.Ligne);

            string saisieChoix = Console.ReadLine();
           
            if(saisieChoix == "Raté") {
                return CoordonnéesDeBatailleNavale.RésultatDeTir.Raté;
            }
            else if (saisieChoix == "Touché")
            {
                return CoordonnéesDeBatailleNavale.RésultatDeTir.Touché;
            }
            else if (saisieChoix == "TouchéCoulé")
            {
                return CoordonnéesDeBatailleNavale.RésultatDeTir.TouchéCoulé;
            }
            else if (saisieChoix == "TouchéCouléFinal")
            {
                return CoordonnéesDeBatailleNavale.RésultatDeTir.TouchéCouléFinal;

            }
            else
            {
                return CoordonnéesDeBatailleNavale.RésultatDeTir.Inconnu;

            }




        }

        public void PréparerLaBataille()
        {
            
        }

        public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnéesDuTir, Enumeration.RésultatDeTir résultatDuTir)
        {
            throw new NotImplementedException();
        }
    }
}
