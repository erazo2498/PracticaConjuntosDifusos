using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaConjuntosDifusos.Logica
{
    public static class ConjuntoDifuso
    {
        public static List<double> Analizar ( int rangoA, int rangoB, int punto, string pertenencia)
        {
            
            double pendiente;
            List<double> valoresEcuacion = new List<double>();
            int distancia = CalcularDistancia(pertenencia);
            int limiteInferior = punto - distancia;
            int limiteSuperior = punto + distancia;

            
            //[rangoA-LimiteInferior]
            if(rangoA < limiteInferior)
            {
                pendiente = CalcularPendiente(rangoA, 0, limiteInferior, 0);
                for (double i = rangoA; i < limiteInferior; i += 0.01)
                {
                    valoresEcuacion.Add(EcuacionLineal(pendiente, punto, i, 0));
                }

            }
            else
            {
                pendiente = CalcularPendiente(punto, 1, limiteInferior, 0);
                for (double i = rangoA; i < punto; i += 0.01)
                {
                    valoresEcuacion.Add(EcuacionLineal(pendiente, punto, i, 1));
                    
                }
            }
            
            //[LimiteInferior - Punto]
            pendiente = CalcularPendiente(limiteInferior, 0, punto, 1);
            for (double i = limiteInferior; i < punto; i += 0.01)
            {
                valoresEcuacion.Add(EcuacionLineal(pendiente, punto, i, 1));
            }

            
            //[PuntoLimiteSuperior]
            pendiente = CalcularPendiente(punto, 1, limiteSuperior, 0);
            for (double i = punto; i < limiteSuperior; i += 0.01)
            {
                valoresEcuacion.Add(EcuacionLineal(pendiente, punto, i, 1));
            }

            
            //[LimiteSuperior - RangoB]
            if (rangoB> limiteSuperior)
            {
                pendiente = CalcularPendiente(limiteSuperior, 0, rangoB, 0);
                for (double i = limiteSuperior; i < rangoB; i += 0.01)
                {
                    valoresEcuacion.Add(EcuacionLineal(pendiente, punto, i, 0));
                }
            }
            
            return valoresEcuacion;

        }

        public static int CalcularDistancia(string pertenencia)
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

        public static double CalcularPendiente (int x1, int y1, int x2, int y2)
        {
            double resultado =  Convert.ToDouble((y2-y1)) / Convert.ToDouble((x2-x1));
            return resultado;
        }

        public static double EcuacionLineal(double pendiente, int punto, double valor, double y)
        {
            double resultado = (pendiente * (valor - punto) + y);
            return resultado;
        }

        public static double EcuacionGaussiana()
        {
            return 0;
        }
    }
}
