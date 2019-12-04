using System;
using static MoteurDeBatailleNavale.Enumeration;

namespace MoteurDeBatailleNavale
{

    public class UneFlotteDeNavires

    {


        public UnNavire[] Navires
        {
            get;
            private set;
        }



        public UneFlotteDeNavires()
        {
            this.Navires = new UnNavire[5];
            Navires[0] = new UnNavire("porte avion", 5);
            Navires[1] = new UnNavire("croiseur", 4);
            Navires[2] = new UnNavire("contre torpilleur", 3);
            Navires[3] = new UnNavire("sous-marin", 3);
            Navires[4] = new UnNavire("torpilleur", 2);


        }


        public void RéparerTousLesNavires()
        {
            foreach (UnNavire navire in Navires)
            {
                navire.Réparer();
            }
        }



        //public RésultatDeTir VérifierLeRésultatDuTir(CoordonnéesDeBatailleNavale caseCible)
        //{
        //    int i = 0;
        //    int couléCount = 0;
        //    RésultatDeTir res = RésultatDeTir.Raté;


        //    while (Navires[i].VérifierLeRésultatDuTir(caseCible) == RésultatDeTir.Raté)
        //    {
        //        if (Navires[i].VérifierLeRésultatDuTir(caseCible) == RésultatDeTir.TouchéCoulé)
        //        {
        //            res = RésultatDeTir.Touché; for (int j = 0; j < Navires.Length; j++)
        //            {
        //                if (Navires[i].Etat == EtatDeNavire.Coulé)
        //                    couléCount++;
        //            }
        //        }
        //        i++;
        //    }


        //    if (couléCount >= Navires.Length)
        //    {
        //        res = RésultatDeTir.TouchéCoulé;
        //    }


        //    return res;

        //}


        public RésultatDeTir VérifierLeRésultatDuTir(CoordonnéesDeBatailleNavale caseCible)
        {
            RésultatDeTir res = RésultatDeTir.Raté;
            bool couléFinal = true;
            foreach (UnNavire navire in Navires)
            {

                RésultatDeTir resTir = navire.VérifierLeRésultatDuTir(caseCible);
                if (navire.Etat != EtatDeNavire.Coulé)
                {
                    couléFinal = false;
                }
                if (resTir == RésultatDeTir.Touché)
                {
                    res = RésultatDeTir.Touché;
                    break;
                }
                if (resTir == RésultatDeTir.TouchéCoulé)
                {
                    res = RésultatDeTir.TouchéCoulé;
                }

            }
            if (couléFinal)
                res = RésultatDeTir.TouchéCouléFinal;
            return res;
        }




    }
}
