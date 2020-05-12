using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaConjuntosDifusos.Logica
{
    public class ConjuntoDifusoContinuo
    {
        static List<double> valores = new List<double>();
        static string ecuacion;
        public ConjuntoDifusoContinuo(int rangoA, int rangoB, int punto, string pertenencia)
        {
            AnalizarConjunto(rangoA, rangoB, punto, pertenencia);
        }

        private void AnalizarConjunto(int rangoA, int rangoB, int punto, string pertenencia)
        {
            ResetearValores();
            int exponente = CalcularDistancia(pertenencia);
            int desplazamiento = CalcularAmplitud(pertenencia);
            EcuacionGaussiana(punto, rangoA, rangoB, exponente, desplazamiento);
        }

        private int CalcularAmplitud(string pertenencia)
        {
            if(pertenencia =="Muy Cerca" || pertenencia == "Cerca")
            {
                return 1;
            }
            else
            {
                return 6;
            }
        }

        private static int CalcularDistancia(string pertenencia)
        {
            switch (pertenencia)
            {
                case "Muy Cerca":
                    return 2;
                case "Cerca":
                    return 4;
                case "Lejos":
                    return 4;
                case "Muy Lejos":
                    return 2;
                default:
                    return -1;
            }
        }

        private static void EcuacionGaussiana(int punto, int valorInicial, int valorFinal, int exponente, int desplazamiento)
        {
         
            for (double i = valorInicial; i < valorFinal; i += 0.01)
            {
                valores.Add(( desplazamiento/ (desplazamiento + Math.Pow((punto - i), exponente))));
            }

            ecuacion = desplazamiento.ToString() + "/" + "[" + desplazamiento.ToString() + "+" + "(" + punto.ToString() + "-" + "x" + ")" + "^" + exponente.ToString() + "]";
            
             
        }

        private static void ResetearValores()
        {
            valores.Clear();
        }

        public List<double> ObtenerValores()
        {
            return valores;
        }

        public string OtenerEcuacion()
        {
            return ecuacion;
        }
    }
}
