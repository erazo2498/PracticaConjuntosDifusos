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
           
                int rangoA = int.Parse(txtRangoA.Text);
                int rangoB = int.Parse(txtRangoB.Text);
                int punto = int.Parse(txtPunto.Text);
                string pertenencia = cbGradoPertenencia.Text;
                ConjuntoDifuso.Analizar(rangoA, rangoB, punto, pertenencia);
                var valores = ConjuntoDifuso.ObtenerValores();
                Controls.Add(Graficador.Generar_Grafica(valores, rangoA));
            }
            else
            {
                MessageBox.Show("Debe ingresar los parametros");
            }
            
            
            
        }

        private bool ValidarParametros(string rangoA, string rangoB, string punto, string pertenencia)
        {
            return (!rangoA.Equals(0) && !rangoB.Equals(0) && !punto.Equals(0) && !pertenencia.Equals(""));
        }
    }
}
