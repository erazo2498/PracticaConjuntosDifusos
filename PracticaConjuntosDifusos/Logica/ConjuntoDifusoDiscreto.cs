using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PracticaConjuntosDifusos.Logica
{
    public class ConjuntoDifusoDiscreto
    {
        static List<(int, int)> segmentos = new List<(int, int)>();
        static List<double> valores = new List<double>();
        static List<string> ecuaciones = new List<string>();
        static int rangoA;
        static int rangoB;


        public ConjuntoDifusoDiscreto(int punto, string pertenencia)
        {
            rangoA = Constantes.DominioInicial + punto;
            rangoB = Constantes.DominioFinal + punto;
            AnalizarConjunto(punto, pertenencia);
        }

        /// <summary>
        /// Permite analizar un sistema discreto y generar los valores correspondientes
        /// </summary>
        /// <param name="punto"> parametro para analizar el punto de referencia que ingresa el usuario</param>
        /// <param name="pertenencia"> parametro que nos permite saber si el grado de pertenencia es cerca, muy cerca, lejos o  muy lejos 
        /// y teniendo en cuenta estó, podemos graficar</param>
        public static void AnalizarConjunto (int punto, string pertenencia)
        {
            ResetearValores();

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
                AgregarSegmentos(new List<(int, int)> {(rangoA,limiteInferior), (limiteInferior, punto), (punto, limiteSuperior), (limiteSuperior, rangoB)});
            }
            else
            {
                MessageBox.Show("No existe este caso");
            }
            
            if(pendientes.Count > 0)
            {
                int indice = 0;
                foreach (var m in pendientes)
                {
                    int y1 = m == 0 ? 0 : 1;
                    EcuacionLineal(m, punto, segmentos[indice].Item1, segmentos[indice].Item2, y1);
                    indice++;
                }
            }
        }
        /// <summary>
        /// Se resetan todos los atributos iniciales para no tener problemas al hacer un nuevo llamado
        /// </summary>
        private static void ResetearValores()
        {
            segmentos.Clear();
            valores.Clear();
            ecuaciones.Clear();
        }

        /// <summary>
        /// Permite evaluar el nivel de pertenencia ingresado y generar un retorno numérico.
        /// </summary>
        /// <param name="pertenencia"> parametro de tipo string que indica la variable literal de pertenecia a un punto</param>
        /// <returns>MuyCerca: 1, Cerca: 2, Lejos: 5, MuyLejos: 10</returns>
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

        /// <summary>
        /// Se calcula la pendiente entre dos puntos usando la formula m = (y2-y1)/(x2-x1)
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns> retorna un valor de tipo doble que corresponde a la pendiente entre dos puntos.</returns>
        private static double CalcularPendiente (int x1, int y1, int x2, int y2)
        {
            return Convert.ToDouble((y2-y1)) / Convert.ToDouble((x2-x1));  
        }

        /// <summary>
        /// Se recibe una lista de duplas para se agregadas a una lista de segmentos.
        /// </summary>
        /// <param name="segmentosIn"></param>
        private static void AgregarSegmentos(List<(int, int)> segmentosIn)
        {
            //refactorizar la forma como se está modificando el ultimo segmento
            var ultimoSegmento = segmentosIn[segmentosIn.Count - 1];
            segmentosIn.RemoveAt(segmentosIn.Count - 1);
            ultimoSegmento.Item2++;
            segmentosIn.Add(ultimoSegmento);

            foreach (var segmento in segmentosIn)
            { 
                segmentos.Add(segmento);
            }
           
        }
        /// <summary>
        /// Permite el cálculo del rango de una ecuacion lineal dentro de un intervalo. La ecuacion es de la forma y=ax+b
        /// </summary>
        /// <param name="pendiente"></param>
        /// <param name="punto"></param>
        /// <param name="valorInicial"> valor inicial del intervalo </param>
        /// <param name="valorFinal"> valor final del intervalo</param>
        /// <param name="y1"></param>
        private static void EcuacionLineal(double pendiente, int punto, int valorInicial, int valorFinal, double y1)
        {
            for (int i = valorInicial; i < valorFinal; i++)
            {
                valores.Add((pendiente * (i - punto) + y1));
            }

            if(pendiente == 0)
            {
                ecuaciones.Add("0");
            }
            else
            {
                punto = punto * -1;
                var a = pendiente == 1 ? "x" : pendiente.ToString() + "x";
                a = pendiente == -1 ? "-x" : a;
                var valor = punto * pendiente + y1;
                var b = valor >= 0 ? "+" + valor.ToString() : valor.ToString(); 

                ecuaciones.Add(a + b); 
            }
        }

        public List<double> ObtenerValores()
        {
            return valores;
        }

        public List<(int, int)> ObtenerSegmentos()
        {
            return segmentos;
        }

        public List<string> ObtenerEcuaciones()
        {
            return ecuaciones;
        }
    }
}
