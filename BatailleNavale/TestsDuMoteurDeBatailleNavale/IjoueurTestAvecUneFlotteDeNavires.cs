using MoteurDeBatailleNavale;

namespace TestsDuMoteurDeBatailleNavale
{
    interface IjoueurTestAvecUneFlotteDeNavires
    {
        CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir();
        void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnéesDuTir, Enumeration.RésultatDeTir résultatDuTir);
        Enumeration.RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnéesDuTir);
    }
}