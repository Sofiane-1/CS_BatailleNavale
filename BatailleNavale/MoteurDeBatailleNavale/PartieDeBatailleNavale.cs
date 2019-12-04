using System;
using static MoteurDeBatailleNavale.CoordonnéesDeBatailleNavale;

namespace MoteurDeBatailleNavale
{

    public class PartieDeBatailleNavale
    {
        
        public IContratDuJoueurDeBatailleNavale Attaquant
        {
            get;
            private set;
        }

        public IContratDuJoueurDeBatailleNavale Défenseur
        {
            get;
            private set;
        }

        public PartieDeBatailleNavale(IContratDuJoueurDeBatailleNavale cjbn1, IContratDuJoueurDeBatailleNavale cjbn2)
        {
            if(cjbn1 == null || cjbn2 == null){
                throw new ArgumentNullException("ne doit pas être null");
            }

            this.Attaquant = cjbn1;
            this.Défenseur = cjbn2;
            this.ChoisirLesRôlesDeDépartDesJoueurs();



        }


        public void ChoisirLesRôlesDeDépartDesJoueurs()
        {
            var random = new Random();
            int randomnumber = random.Next(1001);
            if (randomnumber > 500)
            {
                this.IntervertirLesRôlesDesJoueurs();
            }
            
        }

        public void IntervertirLesRôlesDesJoueurs()
        {
            IContratDuJoueurDeBatailleNavale temp = this.Attaquant;
            this.Attaquant = this.Défenseur;
            this.Défenseur = temp;
        }

        public void PréparerLaBataille()
        {
            this.Attaquant.PréparerLaBataille();
            this.Défenseur.PréparerLaBataille();
        }

        public void JouerLaPartie()
        {

            
            CoordonnéesDeBatailleNavale choixAttaquant = this.Attaquant.Attaquant_ChoisirLesCoordonnéesDeTir();
            RésultatDeTir reponseDef =  this.Défenseur.Défenseur_FournirLeRésultatDuTir(choixAttaquant);
            this.Attaquant.Attaquant_GérerLeRésultatDuTir(choixAttaquant, reponseDef);
            if(reponseDef != RésultatDeTir.TouchéCouléFinal)
            {
                this.IntervertirLesRôlesDesJoueurs();
            }

            while(reponseDef != RésultatDeTir.TouchéCouléFinal)
            {
                CoordonnéesDeBatailleNavale choixAttaquants = this.Attaquant.Attaquant_ChoisirLesCoordonnéesDeTir();
                RésultatDeTir reponseDefs = this.Défenseur.Défenseur_FournirLeRésultatDuTir(choixAttaquants);
                this.Attaquant.Attaquant_GérerLeRésultatDuTir(choixAttaquants, reponseDefs);
                if (reponseDefs != RésultatDeTir.TouchéCouléFinal)
                {
                    this.IntervertirLesRôlesDesJoueurs();
                }
            }
            Console.WriteLine("Le gagnant est " + this.Attaquant + ".");
        }

    }
}
