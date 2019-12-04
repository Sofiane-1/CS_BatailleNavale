using System;
using static MoteurDeBatailleNavale.Enumeration;

namespace MoteurDeBatailleNavale
{

    public class UnNavire
    {

        public string Nom
        {
            get;
            private set;
        }

        public EtatDeNavire Etat
        {
            get;
            private set;
        }

        public OrientationNavire Orientation
        {
            get;
            private set;
        }

        public UneSectionDeNavire[] Sections
        {
            get;
            private set;
        }

        private UnNavire() { }
        public UnNavire(string nom, byte nb)
        {
            if (nb < 2 || nb > 5)
            {
                throw new IndexOutOfRangeException("Le nombre de section n'est pas geré");
            }
            if (string.IsNullOrEmpty(nom))
            {
                throw new ArgumentOutOfRangeException("Nom invalide");
            }

            else
            {
                Nom = nom;
                this.Sections = new UneSectionDeNavire[nb];
                for (int i = 0; i < Sections.Length; i++)
                {
                    Sections[i] = new UneSectionDeNavire();
                }
            }
        }

        public void Réparer()
        {
            for (int i = 0; i < Sections.Length; i++)
            {

                Sections[i].Etat = EtatDeSectionDeNavire.Intact;

            }
            this.Etat = EtatDeNavire.Intact;
        }

        public void Positionner(CoordonnéesDeBatailleNavale coordonnées, OrientationNavire orientation)
        {
            char colonne = coordonnées.Colonne;
            byte ligne = coordonnées.Ligne;
            for (int i = 0; i < this.Sections.Length; i++)
            {
                CoordonnéesDeBatailleNavale coord;

                if (orientation == OrientationNavire.Horizontal)
                    coord = new CoordonnéesDeBatailleNavale(colonne, coordonnées.Ligne);
                else
                    coord = new CoordonnéesDeBatailleNavale(coordonnées.Colonne, ligne);
                this.Sections[i].Position = coord;
                colonne++;
                ligne++;
            }
        }


        public RésultatDeTir VérifierLeRésultatDuTir(CoordonnéesDeBatailleNavale caseCible)
        {
            int nbSection = 0;
            RésultatDeTir res = RésultatDeTir.Raté;


            for (int i = 0; i < Sections.Length; i++)
            {
                if (caseCible == Sections[i].Position)
                {
                    Sections[i].Etat = EtatDeSectionDeNavire.Touché;
                    res = RésultatDeTir.Touché;
                }
            }


            for (int j = 0; j < Sections.Length; j++)
            {
                if (Sections[j].Etat == EtatDeSectionDeNavire.Touché)
                {
                    nbSection++;
                }
            }


            if (nbSection == Sections.Length)
            {
                this.Etat = EtatDeNavire.Coulé;
                res = RésultatDeTir.TouchéCoulé;
            }



            return res;

        }

    }
}
