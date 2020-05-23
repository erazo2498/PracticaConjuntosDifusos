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
                double punto = double.Parse(txtPunto.Text);
                string pertenencia = cbGradoPertenencia.Text;
               
                if (rbDiscreto.Checked)
                {
                    ConjuntoDifusoDiscreto conjuntoDiscreto = new ConjuntoDifusoDiscreto( (int) punto, pertenencia);
                    var valores = conjuntoDiscreto.ObtenerValores();
                    var segmentos = conjuntoDiscreto.ObtenerSegmentos();
                    var ecuaciones = conjuntoDiscreto.ObtenerEcuaciones();
                    pv = Graficador.Generar_Grafica(valores, segmentos, ecuaciones, "Discreto", (int) punto);
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
            //Para obligar a que sólo se introduzcan números y permitir teclas de control como retroceso
            if (Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (rbContinuo.Checked && (e.KeyChar.Equals('.') || e.KeyChar.Equals(',')) && txtPunto.Text.Length != 0 ) 
            {
                string numero = txtPunto.Text.Substring(0,txtPunto.Text.Length);
                MessageBox.Show(numero);
                //Si ya hay un punto, no dejaremos poner el punto(.)
                if (numero.Contains(System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator))
                {
                    e.Handled = true; // Interceptamos la pulsación para que no permitirla.
                }
                else //Si hay caracteres continuamos las comprobaciones
                {       //Cambiamos la pulsación al separador decimal definido por el sistema 
                        e.KeyChar = Convert.ToChar(System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator);
                        e.Handled = false; // No hacemos nada y dejamos que el sistema controle la pulsación de tecla
                }
            }
            
            else
            {
                if (e.KeyChar.Equals('-')) { 
                    
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void rbDiscreto_CheckedChanged(object sender, EventArgs e)
        {
            txtPunto.Clear();
        }
    }
}
