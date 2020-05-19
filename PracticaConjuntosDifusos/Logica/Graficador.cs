using OxyPlot.WindowsForms;
using System.Collections.Generic;
using System.Drawing;
using OxyPlot.Series;
using OxyPlot;
using OxyPlot.Annotations;


namespace PracticaConjuntosDifusos.Logica
{
    public static class Graficador
    { 

        /// <summary>
        /// Permite generar una gráfica en base a los valores y segmentos que se le ingresen, Además valida si el sistema es discreto para crear lineas punteadas o en caso de ser continuo crea lineas continuas.
        /// </summary>
        /// <param name="valoresEcuacion"> valores en y para ser graficados</param>
        /// <param name="segmentos"> valores en x para ser graficados</param>
        /// <param name="titulos"> titulo correspondiente a cada ecuacion de cada segmento</param>
        /// <param name="tipoSistema"> de tipo string "Discreto" ó "Continuo"</param>
        /// <param name="punto">punto de refencia para el analisis</param>
        /// <returns></returns>
        public static PlotView Generar_Grafica(List<double> valoresEcuacion, List<(int,int)> segmentos, List<string> titulos, string tipoSistema, int punto)
        {
            double salto = tipoSistema == "Discreto" ? Constantes.SaltoDiscreto : Constantes.SaltoContinuo;
            PlotView pv = new PlotView();
            pv.Location = new Point(220, 0);
            pv.Size = new Size(1100, 500);
            pv.Model = new PlotModel { Title = tipoSistema=="Discreto"? "Sistema Difuso Discreto": "Sistema Difuso continuo" };
            pv = CrearFlechasContinuidad(punto, pv);

            //para evitar que se desborde la lista
            var ultimoSegmento = segmentos[segmentos.Count - 1];
            segmentos.RemoveAt(segmentos.Count - 1);
            ultimoSegmento.Item2--;
            segmentos.Add(ultimoSegmento);

            int indiceTitulo = 0;
            int indice = segmentos[0].Item1;
            int indiceValorEcuacion = 0;
            foreach (var segmento in segmentos)
            {
                FunctionSeries fs = new FunctionSeries();
                for (double i = indice; i <= segmento.Item2; i+=salto)
                {
                    DataPoint dp = new DataPoint(i, valoresEcuacion[indiceValorEcuacion]);
                    fs.Points.Add(dp);
                    indiceValorEcuacion++;
                }
      
                indiceValorEcuacion--;
                indice = segmento.Item2;
                pv.Model.Series.Add(fs);
                fs.LineStyle = tipoSistema == "Discreto" ? LineStyle.Dash : LineStyle.Solid;
                

                if (segmentos.Count > 1)
                {
                    var limiteInferior = segmento == segmentos[0] ? "(-∞" : "[" + segmentos[indiceTitulo].Item1.ToString();
                    var limiteSuperior = segmento == segmentos[3] ? "∞)" : segmentos[indiceTitulo].Item2.ToString() + ")";
                    fs.Title = titulos[indiceTitulo] + "  para: " + limiteInferior + "," + limiteSuperior;
                }
                else
                {
                    fs.Title = titulos[indiceTitulo] + "  para: " + "(-∞" +"," + "∞)";
                }
                indiceTitulo++;
            }

            return pv;
        }

        /// <summary>
        /// Genera en la gráfica  dos flechas para indicar que la gráfica continua hasta el infinito.
        /// </summary>
        /// <param name="punto"></param>
        /// <param name="plotView"></param>
        /// <returns></returns>
        private static PlotView CrearFlechasContinuidad(double punto, PlotView plotView )
        {
            var arrowAnnotation1 = new ArrowAnnotation
            {
                StartPoint = new DataPoint(Constantes.DominioInicial+punto + 1, 0),
                EndPoint = new DataPoint(Constantes.DominioInicial+punto, 0)
            };
            var arrowAnnotation2 = new ArrowAnnotation
            {
                StartPoint = new DataPoint(Constantes.DominioFinal+punto - 1, 0),
                EndPoint = new DataPoint(Constantes.DominioFinal+punto, 0)
            };

            plotView.Model.Annotations.Add(arrowAnnotation1);
            plotView.Model.Annotations.Add(arrowAnnotation2);

            return plotView;
        }

       
    }
}
