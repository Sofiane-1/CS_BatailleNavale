//using System;
//using static MoteurDeBatailleNavale.Enumeration;

//namespace MoteurDeBatailleNavale
//{


//    public class UnJoueurRobotPasTrèsIntelligent : UnJoueurAvecUneFlotteDeNavires
//    {

//        public UnJoueurRobotPasTrèsIntelligent(string psd) : base(psd)
//        {
//        }
//        public override CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir()
//        {
//            char[] myColonnes = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
//            byte[] myLignes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//            var random = new Random();
//            char randCol = myColonnes[random.Next(9)];
//            byte randLign = myLignes[random.Next(9)];

//            CoordonnéesDeBatailleNavale coord = new CoordonnéesDeBatailleNavale(randCol, randLign);

//            Console.WriteLine(coord);

//            return coord;

//        }

//        public override void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale cbn, RésultatDeTir rt)
//        {
//            throw new NotImplementedException();
//        }

//        public override RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale cbn)
//        {
//            RésultatDeTir rtrn = this.Flotte.VérifierLeRésultatDuTir(cbn);
//            Console.WriteLine(rtrn);

//            return rtrn;

//        }

//        public override void PréparerLaBataille()
//        {
//            base.PréparerLaBataille();
//            byte ligne = 1;
//            foreach (UnNavire navire in Flotte.Navires)
//            {
//                navire.Positionner(new CoordonnéesDeBatailleNavale('A', ligne++), OrientationNavire.Horizontal);
//            }
//        }



//    }
//}
// Toutes les méthodes fonctionne sauf  Défenseur_FournirLeRésultatDuTir, probleme Enumeration