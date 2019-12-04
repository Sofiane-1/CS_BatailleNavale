using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using MoteurDeBatailleNavale;
using static MoteurDeBatailleNavale.CoordonnéesDeBatailleNavale;

namespace TestsDuMoteurDeBatailleNavale
{
    public class joueurTest : IContratDuJoueurDeBatailleNavale
    {
        //public joueurTest()
        //{

        //}
        public joueurTest(string pseudo)
        {
            Pseudo = pseudo;
        }
        public string Pseudo { get; private set; }
        public CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir()
        {
            return new CoordonnéesDeBatailleNavale('A', 1);
        }
        public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale
       coordonnéesDuTir, RésultatDeTir résultatDuTir)
        {
        }

        public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnéesDuTir, Enumeration.RésultatDeTir résultatDuTir)
        {
            throw new NotImplementedException();
        }

        public RésultatDeTir
       Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnéesDuTir)
        {
            return RésultatDeTir.TouchéCouléFinal;
        }
        public void PréparerLaBataille()
        {
        }
    }
    [TestClass]
public class Tests_Phase1_2 { 
    [TestMethod]
        public void Phase1_2_PartieDeBatailleNavale_Constructeur()
        {
            // vérification du constructeur public
            Type t = typeof(PartieDeBatailleNavale);
            ConstructorInfo constructeurPublique = t.GetConstructor(new Type[] {typeof(IContratDuJoueurDeBatailleNavale), typeof(IContratDuJoueurDeBatailleNavale) });
            Assert.IsNotNull(constructeurPublique, "PartieDeBatailleNavale doit avoir un constructeur public attendant en paramètre 2 instance de IContratDuJoueurDeBatailleNavale");
            bool ThrowException = false;
            try
            {
                PartieDeBatailleNavale p = new PartieDeBatailleNavale(null, null);
                p = new PartieDeBatailleNavale(null, new joueurTest("joueur test"));
                p = new PartieDeBatailleNavale(new joueurTest("joueur test"), null);
            }
            catch (ArgumentNullException)
            {
                ThrowException = true;
            }
            Assert.IsTrue(ThrowException, "La construction de PartieDeBatailleNavale ne doit pas accepter les paramètes null");
        }
        [TestMethod]
        public void
       Phase1_3_PartieDeBatailleNavale_ChoisirLesRôlesDeDépartDesJoueurs()
        {
            IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");
            IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");
            PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1,
           joueur2);
            // partie.ChoisirLesRôlesDeDépartDesJoueurs();
            // IContratDuJoueurDeBatailleNavale attaquantDeDépart = partie.Attaquant;
            int joueur1Attaquant = 0;
            int joueur2Attaquant = 0;
            for (int x = 0; x < 1000; x++)
            {
                partie.ChoisirLesRôlesDeDépartDesJoueurs();
                Assert.IsNotNull(partie.Attaquant, "L'attaquant ne peut pas être null");

                Assert.IsNotNull(partie.Défenseur, "Le défenseur ne peut pas être null");
                if (partie.Attaquant == joueur1)
                {
                    joueur1Attaquant++;
                    Assert.AreEqual(partie.Défenseur, joueur2, "Incohérence entre joueur ataquant et défenseur");
                }
                else if (partie.Attaquant == joueur2)
                {
                    joueur2Attaquant++;
                    Assert.AreEqual(partie.Défenseur, joueur1, "Incohérence entre joueur ataquant et défenseur");
                }
                else
                {
                    Assert.Fail("Incohérence entre joueur ataquant et défenseur");
                }
            }
            if (Math.Abs(joueur1Attaquant - joueur2Attaquant) > 100)
            {
                Assert.Fail("Un joueur semble favorisé au tirage au sort de départ");
            }
        }
        [TestMethod]
        public void Phase1_4_PartieDeBatailleNavale_IntervertirLesRôlesDesJoueurs()
        {
            IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");
            IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");
            PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1,
           joueur2);
            partie.ChoisirLesRôlesDeDépartDesJoueurs();
            IContratDuJoueurDeBatailleNavale attaquantActuel = partie.Attaquant;
            IContratDuJoueurDeBatailleNavale défenseurActuel = partie.Défenseur;
            for (int x = 0; x < 100; x++)
            {
                partie.IntervertirLesRôlesDesJoueurs();
                if (attaquantActuel == partie.Attaquant)
                {
                    Assert.Fail("L'attaquant n'a pas changé après l'appel à IntervertirLesRôlesDesJoueurs()");
                }
                Assert.AreEqual(défenseurActuel, partie.Attaquant, "Incohérence après l'interversion des rôles des joueurs");

                attaquantActuel = partie.Attaquant;
                défenseurActuel = partie.Défenseur;
            }
        }
        [TestMethod]
        public void Phase1_5_PartieDeBatailleNavale_JouerLaPartie()
        {
            for (int x = 0; x < 100; x++)
            {
                try
                {
                    IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");

                    IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");

                    PartieDeBatailleNavale partie = new
                   PartieDeBatailleNavale(joueur1, joueur2);
                    partie.ChoisirLesRôlesDeDépartDesJoueurs();
                    partie.PréparerLaBataille();
                    partie.JouerLaPartie();
                }
                catch (Exception)
                {
                    Assert.Fail("Il semble encore y avoir des anomalies dans le déroulement de la partie...");
                }
            }
        }
    }
}
