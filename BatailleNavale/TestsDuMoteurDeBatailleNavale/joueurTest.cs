using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using MoteurDeBatailleNavale;
using static MoteurDeBatailleNavale.Coordonn�esDeBatailleNavale;

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
        public Coordonn�esDeBatailleNavale Attaquant_ChoisirLesCoordonn�esDeTir()
        {
            return new Coordonn�esDeBatailleNavale('A', 1);
        }
        public void Attaquant_G�rerLeR�sultatDuTir(Coordonn�esDeBatailleNavale
       coordonn�esDuTir, R�sultatDeTir r�sultatDuTir)
        {
        }

        public void Attaquant_G�rerLeR�sultatDuTir(Coordonn�esDeBatailleNavale coordonn�esDuTir, Enumeration.R�sultatDeTir r�sultatDuTir)
        {
            throw new NotImplementedException();
        }

        public R�sultatDeTir
       D�fenseur_FournirLeR�sultatDuTir(Coordonn�esDeBatailleNavale coordonn�esDuTir)
        {
            return R�sultatDeTir.Touch�Coul�Final;
        }
        public void Pr�parerLaBataille()
        {
        }
    }
    [TestClass]
public class Tests_Phase1_2 { 
    [TestMethod]
        public void Phase1_2_PartieDeBatailleNavale_Constructeur()
        {
            // v�rification du constructeur public
            Type t = typeof(PartieDeBatailleNavale);
            ConstructorInfo constructeurPublique = t.GetConstructor(new Type[] {typeof(IContratDuJoueurDeBatailleNavale), typeof(IContratDuJoueurDeBatailleNavale) });
            Assert.IsNotNull(constructeurPublique, "PartieDeBatailleNavale doit avoir un constructeur public attendant en param�tre 2 instance de IContratDuJoueurDeBatailleNavale");
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
            Assert.IsTrue(ThrowException, "La construction de PartieDeBatailleNavale ne doit pas accepter les param�tes null");
        }
        [TestMethod]
        public void
       Phase1_3_PartieDeBatailleNavale_ChoisirLesR�lesDeD�partDesJoueurs()
        {
            IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");
            IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");
            PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1,
           joueur2);
            // partie.ChoisirLesR�lesDeD�partDesJoueurs();
            // IContratDuJoueurDeBatailleNavale attaquantDeD�part = partie.Attaquant;
            int joueur1Attaquant = 0;
            int joueur2Attaquant = 0;
            for (int x = 0; x < 1000; x++)
            {
                partie.ChoisirLesR�lesDeD�partDesJoueurs();
                Assert.IsNotNull(partie.Attaquant, "L'attaquant ne peut pas �tre null");

                Assert.IsNotNull(partie.D�fenseur, "Le d�fenseur ne peut pas �tre null");
                if (partie.Attaquant == joueur1)
                {
                    joueur1Attaquant++;
                    Assert.AreEqual(partie.D�fenseur, joueur2, "Incoh�rence entre joueur ataquant et d�fenseur");
                }
                else if (partie.Attaquant == joueur2)
                {
                    joueur2Attaquant++;
                    Assert.AreEqual(partie.D�fenseur, joueur1, "Incoh�rence entre joueur ataquant et d�fenseur");
                }
                else
                {
                    Assert.Fail("Incoh�rence entre joueur ataquant et d�fenseur");
                }
            }
            if (Math.Abs(joueur1Attaquant - joueur2Attaquant) > 100)
            {
                Assert.Fail("Un joueur semble favoris� au tirage au sort de d�part");
            }
        }
        [TestMethod]
        public void Phase1_4_PartieDeBatailleNavale_IntervertirLesR�lesDesJoueurs()
        {
            IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");
            IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");
            PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1,
           joueur2);
            partie.ChoisirLesR�lesDeD�partDesJoueurs();
            IContratDuJoueurDeBatailleNavale attaquantActuel = partie.Attaquant;
            IContratDuJoueurDeBatailleNavale d�fenseurActuel = partie.D�fenseur;
            for (int x = 0; x < 100; x++)
            {
                partie.IntervertirLesR�lesDesJoueurs();
                if (attaquantActuel == partie.Attaquant)
                {
                    Assert.Fail("L'attaquant n'a pas chang� apr�s l'appel � IntervertirLesR�lesDesJoueurs()");
                }
                Assert.AreEqual(d�fenseurActuel, partie.Attaquant, "Incoh�rence apr�s l'interversion des r�les des joueurs");

                attaquantActuel = partie.Attaquant;
                d�fenseurActuel = partie.D�fenseur;
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
                    partie.ChoisirLesR�lesDeD�partDesJoueurs();
                    partie.Pr�parerLaBataille();
                    partie.JouerLaPartie();
                }
                catch (Exception)
                {
                    Assert.Fail("Il semble encore y avoir des anomalies dans le d�roulement de la partie...");
                }
            }
        }
    }
}
