using OxyPlot.WindowsForms;
using System.Collections.Generic;
using System.Drawing;
using OxyPlot.Series;
using OxyPlot;

namespace PracticaConjuntosDifusos.Logica
{
    public static class Graficador
    { 
        public static PlotView Generar_Grafica(List<double> valoresEcuacion, List<(int,int)> segmentos, string titulo, double salto)
        {
            PlotView pv = new PlotView();
            pv.Location = new Point(220, 0);
            pv.Size = new Size(600, 300);
            pv.Model = new PlotModel { Title = titulo };

            /*FunctionSeries fs = new FunctionSeries();
           
            foreach (var valor in valoresEcuacion)
            {
                DataPoint dp = new DataPoint(valorInicial, valor);
                fs.Points.Add(dp);
                valorInicial += salto;
            }
            
            pv.Model.Series.Add(fs);*/
            var ultimoSegmento = segmentos[segmentos.Count - 1];
            segmentos.RemoveAt(segmentos.Count - 1);
            ultimoSegmento.Item2--;
            segmentos.Add(ultimoSegmento);


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
            }
           
            return pv;
        }
    }
}
