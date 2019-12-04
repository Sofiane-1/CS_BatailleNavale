using System;

namespace MoteurDeBatailleNavale
{

    public class CoordonnéesDeBatailleNavale
    {
        public enum RésultatDeTir
        {
            Inconnu, Raté, Touché, TouchéCoulé, TouchéCouléFinal
        }
        private char _Colonne;
        private byte _Ligne;
        public char Colonne
        {
            get => _Colonne;
        }

        public byte Ligne
        {
            get => _Ligne;
        }

        private CoordonnéesDeBatailleNavale() { }
        public CoordonnéesDeBatailleNavale(char Colonne, byte Ligne)
        {
            char[] myColonnes = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'};
            byte[] myLignes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            if (!(Colonne >= 'A' && Colonne <= 'J'))
            {
                throw new ArgumentOutOfRangeException("lettre non valide");
            }
            else
            {
                _Colonne = Colonne;
            }

            if (!(Ligne >= 1 && Ligne <= 10))
            {
                throw new ArgumentOutOfRangeException("chiffre non valide");
            }
            else
            {
                _Ligne = Ligne;
            }

        }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            bool res = false;
            if (obj is CoordonnéesDeBatailleNavale cord)
            {
                res = cord.Colonne == this.Colonne && cord.Ligne == this.Ligne;
            }
            return res;

        }

        public static bool operator ==(CoordonnéesDeBatailleNavale c1, CoordonnéesDeBatailleNavale c2)
        {
            if (c1 is null)
            {
                return c2 is null;
            }
            return c1.Equals(c2);
        }

        public static bool operator!=(CoordonnéesDeBatailleNavale c1, CoordonnéesDeBatailleNavale c2)
        {
            return !(c1 == c2);
        }

    }
}
