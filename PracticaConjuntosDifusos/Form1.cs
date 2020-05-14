using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            
            if(ValidarParametros(txtRangoA.Text, txtRangoB.Text, txtPunto.Text, cbGradoPertenencia.Text))
            {
                
                Controls.Remove(pv);
                int rangoA = int.Parse(txtRangoA.Text);
                int rangoB = int.Parse(txtRangoB.Text);
                int punto = int.Parse(txtPunto.Text);
                string pertenencia = cbGradoPertenencia.Text;
                
                if (rbDiscreto.Checked)
                {
                    ConjuntoDifusoDiscreto conjuntoDiscreto = new ConjuntoDifusoDiscreto(punto, pertenencia);
                    var valores = conjuntoDiscreto.ObtenerValores();
                    var segmentos = conjuntoDiscreto.ObtenerSegmentos();
                    var ecuaciones = conjuntoDiscreto.ObtenerEcuaciones();
                    if(valores.Count != 0)
                    {
                        this.Size = new Size(888, 363);
                        pv = Graficador.Generar_Grafica(valores, segmentos, ecuaciones, 1.0);
                        Controls.Add(pv);
                    }
                    
                }
                else if(rbContinuo.Checked)
                {
                    ConjuntoDifusoContinuo conjuntoContinuo = new ConjuntoDifusoContinuo(rangoA, rangoB, punto, pertenencia);
                    var valores = conjuntoContinuo.ObtenerValores();
                    var ecuacion = conjuntoContinuo.OtenerEcuacion();
                    pv = Graficador.Generar_Grafica(valores, new List<(int, int)> {(rangoA, rangoB+1) }, new List<string> {ecuacion}, 0.01);
                    Controls.Add(pv);
                }
                
            }
            else
            {
                MessageBox.Show("Debe ingresar los parametros correctamente");
            }
            
            
            
        }

        private bool ValidarParametros(string rangoA, string rangoB, string punto, string pertenencia)
        {
            return (!rangoA.Equals(0) && !rangoB.Equals(0) && !punto.Equals(0) && !pertenencia.Equals(""));
        }
    }
}
