using System;
using System.Drawing;
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
            cbGradoPertenencia.Items.AddRange(Constantes.valoresPertenecia);
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidarParametros(txtPunto.Text, cbGradoPertenencia.Text))
            {
                this.Size = new Size(1400, 600);
                Controls.Remove(pv);
                int punto = int.Parse(txtPunto.Text);
                string pertenencia = cbGradoPertenencia.Text;
               
                if (rbDiscreto.Checked)
                {
                    ConjuntoDifusoDiscreto conjuntoDiscreto = new ConjuntoDifusoDiscreto(punto, pertenencia);
                    var valores = conjuntoDiscreto.ObtenerValores();
                    var segmentos = conjuntoDiscreto.ObtenerSegmentos();
                    var ecuaciones = conjuntoDiscreto.ObtenerEcuaciones();
                    pv = Graficador.Generar_Grafica(valores, segmentos, ecuaciones, "Discreto", punto);
                    Controls.Add(pv);
                }
                else if(rbContinuo.Checked)
                {
                    ConjuntoDifusoContinuo conjuntoContinuo = new ConjuntoDifusoContinuo(punto, pertenencia);
                    var valores = conjuntoContinuo.ObtenerValores();
                    var ecuacion = conjuntoContinuo.OtenerEcuacion();
                    var segmento = conjuntoContinuo.ObtenerSegmento();
                    pv = Graficador.Generar_Grafica(valores, segmento, ecuacion,"Continuo", punto);
                    Controls.Add(pv);
                }
               
            }
            else
            {
                MessageBox.Show("Debe ingresar los parametros correctamente");
            }
                 
        }

        private bool ValidarParametros(string punto, string pertenencia)
        {
            return (!punto.Equals("") && !pertenencia.Equals(""));
        }

        private void txtPunto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPunto_KeyPress (object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar)) 
            {
                e.Handled = false;
            }
            
            else
            {
                if (e.KeyChar.Equals('-'))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

    }
}
