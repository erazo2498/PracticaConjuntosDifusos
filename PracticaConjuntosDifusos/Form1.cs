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
            
            ConjuntoDifuso.Analizar(5, 25, 12, "Muy Lejos");
            var valores = ConjuntoDifuso.ObtenerValores();
            Controls.Add(Graficador.Generar_Grafica(valores, 5.0));
            
        }
    }
}
