using System;
using System.Collections.Generic;

namespace PracticaConjuntosDifusos.Logica
{
    public static class ConjuntoDifuso
    {
        //refactorizar esto en una sola matriz
        static List<int> valoresIniciales = new List<int>();
        static List<int> valoresFinales = new List<int>();
        static List<double> valores = new List<double>();

        public static void Analizar (int rangoA, int rangoB, int punto, string pertenencia)
        {
            
            List<double> pendientes = new List<double>();
            int distancia = CalcularDistancia(pertenencia);
            int limiteInferior = punto - distancia;
            int limiteSuperior = punto + distancia;

            if(rangoA < limiteInferior && limiteInferior < punto && punto < limiteSuperior && limiteSuperior < rangoB)
            {
                pendientes.Add(CalcularPendiente(rangoA, 0, limiteInferior, 0));
                pendientes.Add(CalcularPendiente(limiteInferior, 0, punto, 1));
                pendientes.Add(CalcularPendiente(punto, 1, limiteSuperior, 0));
                pendientes.Add(CalcularPendiente(limiteSuperior, 0, rangoB, 0));
            }
            else if(limiteInferior < rangoA && rangoA < punto && punto < limiteSuperior && limiteSuperior < rangoB)
            {
                pendientes.Add(CalcularPendiente(limiteInferior, 0, punto, 1));
                pendientes.Add(CalcularPendiente(punto, 1, limiteSuperior, 0));
                pendientes.Add(CalcularPendiente(limiteSuperior, 0, rangoB, 0));
            }
            else if(limiteInferior < rangoA && rangoA < punto && punto < rangoB && rangoB < limiteSuperior)
            {
                pendientes.Add(CalcularPendiente(limiteInferior, 0, punto, 1));
                pendientes.Add(CalcularPendiente(punto, 1, limiteSuperior, 0));
            }
            else if(rangoA < limiteInferior && limiteInferior < punto && punto < rangoB && rangoB < limiteSuperior)
            {
                pendientes.Add(CalcularPendiente(rangoA, 0, limiteInferior, 0));
                pendientes.Add(CalcularPendiente(limiteInferior, 0, punto, 1));
                pendientes.Add(CalcularPendiente(punto, 1, limiteSuperior, 0));
            }
            else if (rangoA < limiteInferior && limiteInferior < punto && punto == rangoB && punto < limiteSuperior)
            {
                pendientes.Add(CalcularPendiente(rangoA, 0, limiteInferior, 0));
                pendientes.Add(CalcularPendiente(limiteInferior, 0, punto, 1));
            }
            else if(limiteInferior < punto && punto == rangoA && punto < limiteSuperior && limiteSuperior < rangoB)
            {
                pendientes.Add(CalcularPendiente(punto, 1, limiteSuperior, 0));
                pendientes.Add(CalcularPendiente(limiteSuperior, 0, rangoB, 0));
            }
            else if (limiteInferior < punto && punto == rangoA && punto < rangoB && rangoB < limiteSuperior)
            {
                pendientes.Add(CalcularPendiente(punto, 1, limiteSuperior, 0));
            }
            else if(limiteInferior < rangoA && rangoA < punto && punto == rangoB && punto < limiteSuperior)
            {
                pendientes.Add(CalcularPendiente(limiteInferior, 0, punto, 1));
            }

            int indice = 0;
            foreach (var m in pendientes)
            {
                int y1 = m == 0 ? 0 : 1;
                EcuacionLineal(m, punto, valoresIniciales[indice], valoresFinales[indice], y1);
                indice++;
            }
        }

        private static int CalcularDistancia(string pertenencia)
        {
            switch (pertenencia)
            {
                case "Muy Cerca":
                    return 1;
                case "Cerca":
                    return 2;
                case "Lejos":
                    return 5;
                case "Muy Lejos":
                    return 10;
                default:
                    return -1;
            }
        }

        private static double CalcularPendiente (int x1, int y1, int x2, int y2)
        {
            valoresIniciales.Add(x1);
            valoresFinales.Add(x2);
            return Convert.ToDouble((y2-y1)) / Convert.ToDouble((x2-x1));  
        }

        private static void EcuacionLineal(double pendiente, int punto, int valorInicial, int valorFinal, int y1)
        {
            for (int i = valorInicial; i < valorFinal; i++)
            {
                valores.Add((pendiente * (i - punto) + y1));
            }
        }

        private static double EcuacionGaussiana()
        {
            return 0;
        }
        public static List<double> ObtenerValores()
        {
            return valores;
        }
    }
}
