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

        public ConjuntoDifusoDiscreto(int punto, string pertenencia)
        {
            AnalizarConjunto(punto, pertenencia);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="punto"> parametro para analizar el punto de referencia que ingresa el usuario</param>
        /// <param name="pertenencia"> parametro que nos permite saber si el grado de pertenencia es cerca, muy cerca, lejos o  muy lejos 
        /// y teniendo en cuenta estó, podemos graficar</param>
        public static void AnalizarConjunto (int punto, string pertenencia)
        {
            ResetearValores();

            List<double> pendientes = new List<double>();
            int rangoA = -50 + punto;
            int rangoB = 50 + punto;
            int distancia = CalcularDistancia(pertenencia);
            int limiteInferior = punto - distancia;
            int limiteSuperior = punto + distancia;
            bool ecuacionValida = true;

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
                ecuacionValida = false;
                MessageBox.Show("No existe este caso");
            }
            
            if(pendientes.Count > 0 && ecuacionValida)
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
        /// Resetea la informacion utilizada para realizar las graficas y así no tener problemas a la hora
        /// de una nueva grafica
        /// </summary>
        private static void ResetearValores()
        {
            segmentos.Clear();
            valores.Clear();
            ecuaciones.Clear();
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
            return Convert.ToDouble((y2-y1)) / Convert.ToDouble((x2-x1));  
        }

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
                ecuaciones.Add(pendiente.ToString() + "*(" + "x -" + punto.ToString() + ") +" + y1.ToString()); 
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
