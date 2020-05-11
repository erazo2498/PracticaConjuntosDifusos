using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PracticaConjuntosDifusos.Logica
{
    public static class ConjuntoDifuso
    {
        static List<(int, int)> segmentos = new List<(int, int)>();
        static List<double> valores = new List<double>();

        public static void Analizar (int rangoA, int rangoB, int punto, string pertenencia)
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
                //calcularUltimoValor o incrementarlo en el ultimo rango

            }
            else if(limiteInferior < rangoA && rangoA < punto && punto < limiteSuperior && limiteSuperior < rangoB)
            {
                pendientes.Add(CalcularPendiente(limiteInferior, 0, punto, 1));
                pendientes.Add(CalcularPendiente(punto, 1, limiteSuperior, 0));
                pendientes.Add(CalcularPendiente(limiteSuperior, 0, rangoB, 0));
                AgregarSegmentos(new List<(int, int)> { (rangoA, punto), (punto, limiteSuperior), (limiteSuperior, rangoB)});
                //ultimo valor
            }
            else if(limiteInferior < rangoA && rangoA < punto && punto < rangoB && rangoB < limiteSuperior)
            {
                pendientes.Add(CalcularPendiente(limiteInferior, 0, punto, 1));
                pendientes.Add(CalcularPendiente(punto, 1, limiteSuperior, 0));
                AgregarSegmentos(new List<(int, int)> { (rangoA, punto), (punto, rangoB)});
                //ultimo valor
            }
            else if(rangoA < limiteInferior && limiteInferior < punto && punto < rangoB && rangoB < limiteSuperior)
            {
                pendientes.Add(CalcularPendiente(rangoA, 0, limiteInferior, 0));
                pendientes.Add(CalcularPendiente(limiteInferior, 0, punto, 1));
                pendientes.Add(CalcularPendiente(punto, 1, limiteSuperior, 0));
                AgregarSegmentos(new List<(int, int)> { (rangoA, limiteInferior), (limiteInferior, punto), (punto, rangoB) });

            }
            else if (rangoA < limiteInferior && limiteInferior < punto && punto == rangoB && punto < limiteSuperior)
            {
                pendientes.Add(CalcularPendiente(rangoA, 0, limiteInferior, 0));
                pendientes.Add(CalcularPendiente(limiteInferior, 0, punto, 1));
                AgregarSegmentos(new List<(int, int)> { (rangoA, limiteInferior), (limiteInferior, punto)});

            }
            else if(limiteInferior < punto && punto == rangoA && punto < limiteSuperior && limiteSuperior < rangoB)
            {
                pendientes.Add(CalcularPendiente(punto, 1, limiteSuperior, 0));
                pendientes.Add(CalcularPendiente(limiteSuperior, 0, rangoB, 0));
                AgregarSegmentos(new List<(int, int)> { (punto, limiteSuperior), (limiteSuperior, rangoB)});
            }
            else if (limiteInferior < punto && punto == rangoA && punto < rangoB && rangoB < limiteSuperior)
            {
                pendientes.Add(CalcularPendiente(punto, 1, limiteSuperior, 0));
                AgregarSegmentos(new List<(int, int)> { (rangoA, rangoB)});
            }
            else if(limiteInferior < rangoA && rangoA < punto && punto == rangoB && punto < limiteSuperior)
            {
                pendientes.Add(CalcularPendiente(limiteInferior, 0, punto, 1));
                AgregarSegmentos(new List<(int, int)> { (rangoA, rangoB) });
            }
            else if(rangoA == limiteInferior && rangoA < punto && punto < rangoB && rangoB == limiteSuperior)
            {
                pendientes.Add(CalcularPendiente(rangoA, 0, punto, 1));
                pendientes.Add(CalcularPendiente(punto, 1, rangoB, 0));
                AgregarSegmentos(new List<(int, int)> { (rangoA, punto), (punto, rangoB) });

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

        private static void ResetearValores()
        {
          
            segmentos.Clear();
            valores.Clear();
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
        }

        private static double EcuacionGaussiana()
        {
            return 0;
        }
        public static List<double> ObtenerValores()
        {
            return valores;
        }

        public static List<(int, int)> ObtenerSegmentos()
        {
            return segmentos;
        }
    }
}
