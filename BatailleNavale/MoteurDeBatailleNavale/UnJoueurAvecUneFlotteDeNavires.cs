using System;
using static MoteurDeBatailleNavale.Enumeration;

namespace MoteurDeBatailleNavale
{


    public abstract class UnJoueurAvecUneFlotteDeNavires : IContratDuJoueurDeBatailleNavale
    {

        public UneFlotteDeNavires Flotte
        {
            get;
        }

        public string Pseudo
        {
            get;

        }
        public UnJoueurAvecUneFlotteDeNavires(string psd)
        {
            if (String.IsNullOrEmpty(psd))
            {
                throw new ArgumentNullException("Le pseudo ne doit pas être vide.");
            }
            Pseudo = psd;
            Flotte = new UneFlotteDeNavires();
        }
        public abstract CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir();

        public abstract void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale cbn, CoordonnéesDeBatailleNavale.RésultatDeTir rt);


        public abstract CoordonnéesDeBatailleNavale.RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale cbn);

        public virtual void PréparerLaBataille()
        {
            throw new NotImplementedException();
        }

        public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordonnéesDuTir, RésultatDeTir résultatDuTir)
        {
            throw new NotImplementedException();
        }
    }
}
