using System;

namespace MoteurDeBatailleNavale
{

    public class Enumeration
    {
        public enum RésultatDeTir
        {
            Inconnu, Raté, Touché, TouchéCoulé, TouchéCouléFinal
        }

        public enum EtatDeSectionDeNavire
        {
            Intact, Touché
        }
        public enum EtatDeNavire
        {
            Intact, Touché, Coulé
        }
        public enum OrientationNavire
        {
            Horizontal, Vertical
        }



    }
}
