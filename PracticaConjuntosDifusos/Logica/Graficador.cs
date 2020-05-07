using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OxyPlot.Series;
using OxyPlot;

namespace PracticaConjuntosDifusos.Logica
{
    public class Graficador
    {
      
        public static PlotView Generar_Grafica(List<double> valoresEcuacion, double rangoA)
        {
            PlotView pv = new PlotView();
            pv.Location = new Point(220, 0);
            pv.Size = new Size(600, 300);
            pv.Model = new PlotModel { Title = "Example" };
            
            FunctionSeries fs = new FunctionSeries();
            
            foreach (var valor in valoresEcuacion)
            {
                DataPoint dp = new DataPoint(rangoA, valor);
                fs.Points.Add(dp);
                rangoA += 0.01;
            }
            
            pv.Model.Series.Add(fs);
           
            return pv;
        }

        private static FunctionSeries getFunction(List<double> valoresEcuacion)
        {
            FunctionSeries fs = new FunctionSeries();
            /* for (double i = 11.0; i < 12.0; i += 0.01)
             {
                 DataPoint dp = new DataPoint(i, (i-11));
                 fs.Points.Add(dp);
             }*/

            foreach (var valor in valoresEcuacion)
            {
                DataPoint dp = new DataPoint(0.01, valor);
                fs.Points.Add(dp);
            }
            return fs;
        }

    }
}
