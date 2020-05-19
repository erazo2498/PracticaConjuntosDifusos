

using System.Collections.Generic;

namespace PracticaConjuntosDifusos
{
    public static class Constantes
    {
        public static string[] valoresPertenecia =  { "Muy Cerca", "Cerca", "Lejos", "Muy Lejos" };
        public static int DominioFinal = 50;
        public static int DominioInicial = DominioFinal * -1;
        public static double SaltoContinuo = 0.01;
        public static double SaltoDiscreto = 1;
    }
}
