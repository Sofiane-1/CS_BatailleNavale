using System;
using static MoteurDeBatailleNavale.CoordonnéesDeBatailleNavale;

namespace MoteurDeBatailleNavale
{

    public interface IContratDuJoueurDeBatailleNavale
    {
        string Pseudo
        {
            get;
            
        }

        void PréparerLaBataille();
        CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir();
        RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale cbn);
        void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale cbn, RésultatDeTir rt);
        void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnéesDuTir, Enumeration.RésultatDeTir résultatDuTir);
    }

}
