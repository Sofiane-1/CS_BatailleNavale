using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using MoteurDeBatailleNavale;
using static MoteurDeBatailleNavale.Enumeration;

namespace TestsDuMoteurDeBatailleNavale
{
    [TestClass]
    public class Tests_PhasjoueurTeste_1_Partie
    {
        [TestMethod]
        public void Phase1_1_Coordonn�esDeBatailleNavale()
        {
            // v�rification du constructeur par d�faut non public
            Type t = typeof(Coordonn�esDeBatailleNavale);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans param�tre
                if (constructeur.GetParameters().Length == 0)
                {
                    // v�rification de visibilit�
                    Assert.IsFalse(constructeur.IsPublic, "Le constructeur par d�faut ne doit pas �tre public.");
                }
            }
            // v�rification que les param�tres hors plage valide produisent une exception IndexOutOfRangeException
            bool ThrowException = false;
            try
            {
                ThrowException = false;
                for (char c = char.MinValue; c < 'A'; c++)
                {
                    Coordonn�esDeBatailleNavale coordonn�eInvalide = new Coordonn�esDeBatailleNavale(c, 1);
                }
                for (char c = (char)('J' + 1); c < char.MaxValue; c++)
                {
                    Coordonn�esDeBatailleNavale coordonn�eInvalide = new
                   Coordonn�esDeBatailleNavale(c, 1);
                }
                Coordonn�esDeBatailleNavale coordonn�eInvalide2 = new
               Coordonn�esDeBatailleNavale('A', 0);
                for (byte l = 11; l < byte.MaxValue; l++)
                {
                    Coordonn�esDeBatailleNavale coordonn�eInvalide = new
                   Coordonn�esDeBatailleNavale('A', l);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                ThrowException = true;
            }
            Assert.IsTrue(ThrowException, "La construction de Coordonn�esDeBatailleNavale ne doit accepter que des colonnes de 'A' � 'J' et des lignes de 1 � 10");
            // v�rification que les param�tres dans la plage valide ne produisent pas d'exception
            try
            {
                ThrowException = false;
                for (char c = 'A'; c <= 'J'; c++)
                {
                    for (byte l = 1; l <= 10; l++)
                    {
                        Coordonn�esDeBatailleNavale coordonn�eInvalide = new
                       Coordonn�esDeBatailleNavale(c, l);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                ThrowException = true;
            }
            Assert.IsFalse(ThrowException, "La construction de Coordonn�esDeBatailleNavale doit accepter des colonnes entre 'A' et 'J' et des lignes entre 1 et 10");
            // v�rification de la m�thode Equals
            try
            {
                Coordonn�esDeBatailleNavale uneInstance = new
               Coordonn�esDeBatailleNavale('C', 5);
                uneInstance.Equals(null);
                uneInstance.Equals(new object());
                uneInstance.Equals(uneInstance);
            }
            catch
            {
                Assert.Fail("Le test d'�galit� ne doit pas provoquer d'exception");
            }
            Assert.IsTrue(new Coordonn�esDeBatailleNavale('C', 5).Equals(new
           Coordonn�esDeBatailleNavale('C', 5)), "L'�galit� C5 avec C5 doit �tre vraie");
            Assert.IsFalse(new Coordonn�esDeBatailleNavale('A', 1).Equals(null),
           "L'�galit� avec null doit �tre fausse");
            Assert.IsFalse(new Coordonn�esDeBatailleNavale('A', 1).Equals(new
           Coordonn�esDeBatailleNavale('A', 2)), "L'�galit� A1 avec A2 doit �tre fausse");
            Assert.IsFalse(new Coordonn�esDeBatailleNavale('A', 1).Equals("A1"),
           "L'�galit� entre deux types diff�rents doit �tre fausse");
        }

        [TestMethod]

        public void Phase_2_1_UneSectionDeNavire()
        {
            Type t = typeof(UneSectionDeNavire);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            bool constructeurParDefautPublic = false;
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans param�tre
                if (constructeur.GetParameters().Length == 0)
                {
                    constructeurParDefautPublic = true;
                }
            }
            Assert.IsTrue(constructeurParDefautPublic, "Le constructeur de UneSectionDeNavire par d�faut doit �tre public.");
            UneSectionDeNavire section = new UneSectionDeNavire();
            Assert.AreEqual(section.Etat, EtatDeSectionDeNavire.Intact, "L'�tat doit �tre initialis� � Intact");
            Assert.IsNotNull(section.Position, "La position ne peut pas �tre null");
            Assert.AreEqual(section.Position, new Coordonn�esDeBatailleNavale('A', 1),
           "La position doit �tre initialis�e avec A1 ");
        }


        public void Phase_2_2_UnNavire()
        {
            Type t = typeof(UnNavire);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            bool constructeurParDefautPublic = false;
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans param�tre
                if (constructeur.GetParameters().Length == 0)
                {
                    constructeurParDefautPublic = true;
                }
            }
            Assert.IsFalse(constructeurParDefautPublic, "Le constructeur de UnNavire par d�faut ne doit pas �tre public.");
            bool testConstructeurNomNull = false;
            try
            {
                UnNavire testConstructeur = new UnNavire(null, 5);
            }
            catch (ArgumentNullException)
            {
                testConstructeurNomNull = true;
            }
            Assert.IsTrue(testConstructeurNomNull, "Le nom du navire ne peut pas �tre null");

            bool testConstructeurNomVide = false;
            try
            {
                UnNavire testConstructeur = new UnNavire("", 5);
            }
            catch (ArgumentNullException)
            {
                testConstructeurNomVide = true;
            }
            Assert.IsTrue(testConstructeurNomVide, "Le nom du navire ne peut pas �tre vide");

            bool testNbSectionValide = false;
            try
            {
                for (byte s = 0; s < 2; s++)
                {
                    UnNavire testConstructeur = new UnNavire("NomValide", s);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                testNbSectionValide = true;
            }
            Assert.IsTrue(testNbSectionValide, "Le nombre de section ne peut �tre inf�rieur � 2");
            try
            {
                for (byte s = 6; s < byte.MaxValue; s++)
                {
                    UnNavire testConstructeur = new UnNavire("NomValide", s);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                testNbSectionValide = true;
            }
            Assert.IsTrue(testNbSectionValide, "Le nombre de section ne peut �tre sup�rieur � 5");
            for (byte taille = 2; taille < 6; taille++)
            {
                try
                {
                    UnNavire navireDeTailleCorrecte = new UnNavire("MonNavire",
                   taille);
                    Assert.AreEqual(navireDeTailleCorrecte.Sections.Length, taille,
                    "Le nombre de sections doit �tre initialis� par le constructeur");
                }
                catch
                {
                    Assert.Fail("La construction du navire doit accepter une taille entre 2 minimum et 5 maximum");
                }
            }
            UnNavire navire = new UnNavire("Nom_TEST", 5);
            Assert.AreEqual(navire.Nom, "Nom_TEST", "Le nom du navire doit �tre initialis� par le constructeur");
        }


        private string[] NomsDesNaviresDeLaFlotte
        {
            get
            {
                return new string[] { "porte avion", "croiseur", "contre torpilleur", "sous-marin", "torpilleur" };
            }
        }
        private byte[] TaillesDesNaviresDeLaFlotte
        {
            get
            { return new byte[] { 5, 4, 3, 3, 2 }; }
        }
        [TestMethod]
        public void Phase_2_3_UneFlotteDeNavires()
        {
            Type t = typeof(UneFlotteDeNavires);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            bool constructeurParDefautPublic = false;
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans param�tre
                if (constructeur.GetParameters().Length == 0)
                {
                    constructeurParDefautPublic = true;
                }
            }
            Assert.IsTrue(constructeurParDefautPublic, "Le constructeur de UneFlotteDeNavires par d�faut doit �tre public.");
            UneFlotteDeNavires flotte = new UneFlotteDeNavires();
            Assert.IsTrue(flotte.Navires.Length == 5, "La flotte de navire doit �tre compos�e de 5 navires exactement");
            int navireIndex = 0;
            foreach (UnNavire navire in flotte.Navires)
            {
                Assert.AreEqual(NomsDesNaviresDeLaFlotte[navireIndex], navire.Nom, "Ce navire ne porte pas le bon nom");
                Assert.AreEqual(TaillesDesNaviresDeLaFlotte[navireIndex],
               navire.Sections.Length, String.Format("Le navire {0} n'a pas le bon nombre de section", navire.Nom));
                navireIndex++;
            }
        }        private class joueurTestAvecUneFlotteDeNavires : UnJoueurAvecUneFlotteDeNavires
        {
            public joueurTestAvecUneFlotteDeNavires(string pseudo) : base(pseudo)
            {
            }
            public override Coordonn�esDeBatailleNavale
           Attaquant_ChoisirLesCoordonn�esDeTir()
            {
                throw new NotImplementedException();
            }
            public void Attaquant_G�rerLeR�sultatDuTir(Coordonn�esDeBatailleNavale coordonn�esDuTir, R�sultatDeTir r�sultatDuTir)
            {
                throw new NotImplementedException();
            }

            public override void Attaquant_G�rerLeR�sultatDuTir(Coordonn�esDeBatailleNavale cbn, Coordonn�esDeBatailleNavale.R�sultatDeTir rt)
            {
                throw new NotImplementedException();
            }

            

            public override Coordonn�esDeBatailleNavale.R�sultatDeTir D�fenseur_FournirLeR�sultatDuTir(Coordonn�esDeBatailleNavale cbn)
            {
                throw new NotImplementedException();
            }
        }
        [TestMethod]
        public void Phase_2_4_UnJoueurAvecUneFlotteDeNavires()
        {
            Type t = typeof(UnJoueurAvecUneFlotteDeNavires);
            ConstructorInfo constructeurPubliqueAvecUnParametreString =
           t.GetConstructor(new Type[] { typeof(string) });

            Assert.IsNotNull(constructeurPubliqueAvecUnParametreString,
           "UnJoueurAvecUneFlotteDeNavires doit poss�der un constructeur publique avec un param�tre de type string.");
           
            bool pseudoNullOrEmpty = false;
            try
            {
                pseudoNullOrEmpty = false;
                joueurTestAvecUneFlotteDeNavires joueur = new
               joueurTestAvecUneFlotteDeNavires(null);
            }
            catch (ArgumentNullException)
            {
                pseudoNullOrEmpty = true;
            }
            Assert.IsTrue(pseudoNullOrEmpty, "Le constructeur de UnJoueurAvecUneFlotteDeNavires ne doit pas accepter un param�tre null");
        try
            {
                pseudoNullOrEmpty = false;
                joueurTestAvecUneFlotteDeNavires joueur = new
               joueurTestAvecUneFlotteDeNavires("");
            }
            catch (ArgumentNullException)
            {
                pseudoNullOrEmpty = true;
            }
            Assert.IsTrue(pseudoNullOrEmpty, "Le constructeur de UnJoueurAvecUneFlotteDeNavires ne doit pas accepter un param�tre de cha�ne vide");
        try
            {
                pseudoNullOrEmpty = false;
                joueurTestAvecUneFlotteDeNavires joueur = new
               joueurTestAvecUneFlotteDeNavires("Pseudo TEST");
            }
            catch (Exception)
            {
                pseudoNullOrEmpty = true;
            }
            Assert.IsFalse(pseudoNullOrEmpty, "Le constructeur de UnJoueurAvecUneFlotteDeNavires doit accepter une cha�ne non vide");
        }


        [TestMethod]
        public void Phase_2_6_R�parerLaFlotteDeNavires()
        {
            UneFlotteDeNavires flotte = new UneFlotteDeNavires();
            foreach (UnNavire navire in flotte.Navires)
            {
                foreach (var section in navire.Sections)
                {
                    section.Etat = EtatDeSectionDeNavire.Touch�;
                    
                }
            }
            flotte.R�parerTousLesNavires();
            bool aucuneSectionTouch�e = true;
            foreach (UnNavire navire in flotte.Navires)
            {
                foreach (var section in navire.Sections)
                {
                    if (section.Etat == EtatDeSectionDeNavire.Touch�)
                        aucuneSectionTouch�e = false;
                }
            }
            Assert.IsTrue(aucuneSectionTouch�e, "Apr�s r�paration, toutes les sections de tous les navires doivent �tre intactes!");
 }


        private void MettreTousLesNaviresAuPort(UneFlotteDeNavires flotte)
        {
            byte ligne = 1;
            foreach (UnNavire navire in flotte.Navires)
            {
                navire.Positionner(new Coordonn�esDeBatailleNavale('A', ligne++),
               OrientationNavire.Horizontal);
            }
        }
        [TestMethod]
        public void Phase_2_7_MettreTousLesNaviresAuPort()
        {
            UneFlotteDeNavires flotte = new UneFlotteDeNavires();
            MettreTousLesNaviresAuPort(flotte);
            Assert.IsTrue(flotte.Navires.Length == 5);
            byte ligne = 1;
            foreach (UnNavire navire in flotte.Navires)
            {
                Assert.IsNotNull(navire, "navire ne peut pas �tre null");
                Assert.IsTrue(navire.Orientation == OrientationNavire.Horizontal, "le navire n'est pas horizontal");
            for (int sectionNum = 0; sectionNum < navire.Sections.Length; sectionNum++)
                {
                    Assert.IsTrue(navire.Sections[sectionNum].Position.Colonne == 'A'
                   + sectionNum, "La colonne de cette section n'est pas correcte");
                    Assert.IsTrue(navire.Sections[sectionNum].Position.Ligne == ligne,
                   "La ligne de cette section n'est pas correcte");
                }
                ligne++;
            }
        }




        [TestMethod]
        public void Phase_2_8_V�rifierLeR�sultatDuTir()
        {
            UneFlotteDeNavires flotte = new UneFlotteDeNavires();
            MettreTousLesNaviresAuPort(flotte);
            byte ligne = 1;
            foreach (UnNavire navire in flotte.Navires)
            {
                int sectionNum = 0;
                for (; sectionNum < navire.Sections.Length - 1; sectionNum++)
                {
                    R�sultatDeTir resultatTirTouch� = navire.V�rifierLeR�sultatDuTir(new Coordonn�esDeBatailleNavale((char)('A' + sectionNum), ligne));
                    Assert.AreEqual(resultatTirTouch�, R�sultatDeTir.Touch�, "Le navire situ� ici devrait �tre touch�");
                }
                R�sultatDeTir resultatTirTouch�Coul� =
               navire.V�rifierLeR�sultatDuTir(new Coordonn�esDeBatailleNavale((char)('A' +
               sectionNum), ligne));
                Assert.AreEqual(resultatTirTouch�Coul�, R�sultatDeTir.Touch�Coul�, "Le navire situ� ici devrait �tre touch� et coul�!");
               
                ligne++;
            }
            flotte.R�parerTousLesNavires();
            ligne = 1;
            foreach (UnNavire navire in flotte.Navires)
            {
                int sectionNum = 0;
                for (; sectionNum < navire.Sections.Length - 1; sectionNum++)
                {
                    R�sultatDeTir resultatTirTouch� = flotte.V�rifierLeR�sultatDuTir(new Coordonn�esDeBatailleNavale((char)('A' + sectionNum), ligne));
                    Assert.AreEqual(resultatTirTouch�, R�sultatDeTir.Touch�, "Le navire situ� ici devrait �tre touch�");
                }
                if (ligne < 5) // derni�re section , mais pas dernier navire
                {
                    R�sultatDeTir resultatTirTouch�Coul� =
                   flotte.V�rifierLeR�sultatDuTir(new Coordonn�esDeBatailleNavale((char)('A' + sectionNum), ligne));
                    Assert.AreEqual(resultatTirTouch�Coul�, R�sultatDeTir.Touch�Coul�, "Le navire situ� ici devrait �tre touch� et coul� !");
                }
                else // derni�re section , du dernier navire
                {
                    R�sultatDeTir resultatTirTouch�Coul�Final =
                   flotte.V�rifierLeR�sultatDuTir(new Coordonn�esDeBatailleNavale((char)('A' +
                   sectionNum), ligne));
                    Assert.AreEqual(resultatTirTouch�Coul�Final,
                   R�sultatDeTir.Touch�Coul�Final, "Le navire situ� ici devrait �tre le dernier navire touch� et coul�!");
                }
                ligne++;
            }
        }




    }
}
