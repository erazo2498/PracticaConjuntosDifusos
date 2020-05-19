using System;
using System.Collections.Generic;


namespace PracticaConjuntosDifusos.Logica
{
    public class ConjuntoDifusoContinuo
    {
        static List<double> valores = new List<double>();
        static string ecuacion;
        static int rangoA;
        static int rangoB;

        public ConjuntoDifusoContinuo(int punto, string pertenencia)
        {
            rangoA = Constantes.DominioInicial + punto;
            rangoB = Constantes.DominioFinal + punto;
            AnalizarConjunto(punto, pertenencia);
        }

        /// <summary>
        /// Permite el análisis de un cojunto difuso continuo
        /// </summary>
        /// <param name="punto">Punto de referencia para el análisis</param>
        /// <param name="pertenencia">parametro de tipo string que indica la variable literal de pertenecia a un punto. Muy Cerca, Cerca, Lejos, MuyLejos</param>
        private void AnalizarConjunto(int punto, string pertenencia)
        {
            ResetearValores();
            int exponente = CalcularDistancia(pertenencia);
            int desplazamiento = CalcularAmplitud(pertenencia);
            EcuacionGaussiana(punto, rangoA, rangoB, exponente, desplazamiento);
        }

        /// <summary>
        /// Dependiendo del valor de pertenencia se genera un valor que permite ampliar horizontalmente la funcion gaussiana.
        /// </summary>
        /// <param name="pertenencia"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Permite evaluar el nivel de pertenencia ingresado y generar un retorno numérico.
        /// </summary>
        /// <param name="pertenencia"> parametro de tipo string que indica la variable literal de pertenecia a un punto</param>
        /// <returns>MuyCerca: 2, Cerca: 4, Lejos: 4, MuyLejos: 2 </returns>
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

        /// <summary>
        /// Permite el cálculo del rango de una funcion Gaussiana dentro de un intervalo o dominio.
        /// </summary>
        /// <param name="punto">Punto en x que se está evaluando</param>
        /// <param name="valorInicial">valor inicial del intervalo</param>
        /// <param name="valorFinal">valor final del intervalo</param>
        /// <param name="exponente"></param>
        /// <param name="desplazamiento">Coeficiente que permite </param>
        private static void EcuacionGaussiana(int punto, int valorInicial, int valorFinal, int exponente, int desplazamiento)
        { 
            for (double i = valorInicial; i < valorFinal; i += Constantes.SaltoContinuo)
            {
                valores.Add(( desplazamiento/ (desplazamiento + Math.Pow((punto - i), exponente))));
            }

            ecuacion = desplazamiento.ToString() + "/" + "[" + desplazamiento.ToString() + "+" + "(" + punto.ToString() + "-" + "x" + ")" + "^" + exponente.ToString() + "]";
                 
        }

        public List<(int, int)> ObtenerSegmento()
        {
            return new List<(int, int)> { (rangoA, rangoB + 1) };
        }

        private static void ResetearValores()
        {
            ecuacion = "";
            valores.Clear();
        }

        public List<double> ObtenerValores()
        {
            return valores;
        }

        public List<string> OtenerEcuacion()
        {
            return new List<string> { ecuacion };
        }
    }
}
