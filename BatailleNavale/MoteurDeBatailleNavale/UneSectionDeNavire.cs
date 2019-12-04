using System;
using static MoteurDeBatailleNavale.Enumeration;

namespace MoteurDeBatailleNavale
{

    public class UneSectionDeNavire
    {

        public EtatDeSectionDeNavire Etat{
            get;
            set;
            }

        public CoordonnéesDeBatailleNavale Position
        {
            get;
            set;
        }

        
        public UneSectionDeNavire()
        {
            Etat = EtatDeSectionDeNavire.Intact;
            Position = new CoordonnéesDeBatailleNavale('A', 1);
            if (Position == null)
            {
                throw new ArgumentOutOfRangeException("la position ne peux pas être null");
            }
        }
    }
}
