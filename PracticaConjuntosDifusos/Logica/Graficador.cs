using OxyPlot.WindowsForms;
using System.Collections.Generic;
using System.Drawing;
using OxyPlot.Series;
using OxyPlot;

namespace PracticaConjuntosDifusos.Logica
{
    public static class Graficador
    { 
        public static PlotView Generar_Grafica(List<double> valoresEcuacion, double rangoA)
        {
            PlotView pv = new PlotView();
            pv.Location = new Point(220, 0);
            pv.Size = new Size(600, 300);
            pv.Model = new PlotModel { Title = "Discreto" };
            
            FunctionSeries fs = new FunctionSeries();
           
            foreach (var valor in valoresEcuacion)
            {
                DataPoint dp = new DataPoint(rangoA, valor);
                fs.Points.Add(dp);
                rangoA += 1 ;
            }
            
            pv.Model.Series.Add(fs);
           
            return pv;
        }
    }
}
