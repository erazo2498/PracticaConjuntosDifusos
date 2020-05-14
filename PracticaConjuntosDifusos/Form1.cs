using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.WindowsForms;
using PracticaConjuntosDifusos.Logica;


namespace PracticaConjuntosDifusos
{
    public partial class Form1 : Form
    {
        PlotView pv = new PlotView();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidarParametros(txtPunto.Text, cbGradoPertenencia.Text))
            {
                this.Size = new Size(888, 363);
                Controls.Remove(pv);
                int punto = int.Parse(txtPunto.Text);
                int rangoA = -50 + punto;
                int rangoB = 50 + punto;
                string pertenencia = cbGradoPertenencia.Text;
                var arrowAnnotation1 = new ArrowAnnotation
                {
                    StartPoint = new DataPoint(rangoA + 1, 0),
                    EndPoint = new DataPoint(rangoA, 0)
                };
                var arrowAnnotation2 = new ArrowAnnotation
                {
                    StartPoint = new DataPoint(rangoB - 1, 0),
                    EndPoint = new DataPoint(rangoB, 0)
                };
                if (rbDiscreto.Checked)
                {
                    ConjuntoDifusoDiscreto conjuntoDiscreto = new ConjuntoDifusoDiscreto(punto, pertenencia);
                    var valores = conjuntoDiscreto.ObtenerValores();
                    var segmentos = conjuntoDiscreto.ObtenerSegmentos();
                    var ecuaciones = conjuntoDiscreto.ObtenerEcuaciones();
                    pv = Graficador.Generar_Grafica(valores, segmentos, ecuaciones, 1.0);
                    Controls.Add(pv);
                }
                else if(rbContinuo.Checked)
                {
                    ConjuntoDifusoContinuo conjuntoContinuo = new ConjuntoDifusoContinuo(rangoA, rangoB, punto, pertenencia);
                    var valores = conjuntoContinuo.ObtenerValores();
                    var ecuacion = conjuntoContinuo.OtenerEcuacion();
                    pv = Graficador.Generar_Grafica(valores, new List<(int, int)> {(rangoA, rangoB+1) }, new List<string> {ecuacion}, 0.01);
                    Controls.Add(pv);
                }
                pv.Model.Annotations.Add(arrowAnnotation1);
                pv.Model.Annotations.Add(arrowAnnotation2);

            }
            else
            {
                MessageBox.Show("Debe ingresar los parametros correctamente");
            }
            
            
            
        }

        private bool ValidarParametros(string punto, string pertenencia)
        {
            return (!punto.Equals(0) && !pertenencia.Equals(""));
        }
    }
}
