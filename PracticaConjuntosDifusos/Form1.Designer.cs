namespace PracticaConjuntosDifusos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbGradoPertenencia = new System.Windows.Forms.ComboBox();
            this.txtPunto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rbDiscreto = new System.Windows.Forms.RadioButton();
            this.rbContinuo = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cbGradoPertenencia
            // 
            this.cbGradoPertenencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGradoPertenencia.FormattingEnabled = true;
            this.cbGradoPertenencia.Items.AddRange(new object[] {
            "Muy Cerca",
            "Cerca",
            "Lejos",
            "Muy Lejos"});
            this.cbGradoPertenencia.Location = new System.Drawing.Point(44, 141);
            this.cbGradoPertenencia.Name = "cbGradoPertenencia";
            this.cbGradoPertenencia.Size = new System.Drawing.Size(121, 21);
            this.cbGradoPertenencia.TabIndex = 7;
            // 
            // txtPunto
            // 
            this.txtPunto.Location = new System.Drawing.Point(86, 200);
            this.txtPunto.Name = "txtPunto";
            this.txtPunto.Size = new System.Drawing.Size(43, 20);
            this.txtPunto.TabIndex = 8;
            this.txtPunto.TextChanged += new System.EventHandler(this.txtPunto_TextChanged);
            this.txtPunto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPunto_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "PERTENENCIA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "PUNTO";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "GENERAR GRÁFICA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbDiscreto
            // 
            this.rbDiscreto.AutoSize = true;
            this.rbDiscreto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDiscreto.Location = new System.Drawing.Point(66, 25);
            this.rbDiscreto.Name = "rbDiscreto";
            this.rbDiscreto.Size = new System.Drawing.Size(95, 20);
            this.rbDiscreto.TabIndex = 0;
            this.rbDiscreto.TabStop = true;
            this.rbDiscreto.Text = "DISCRETO";
            this.rbDiscreto.UseVisualStyleBackColor = true;
            // 
            // rbContinuo
            // 
            this.rbContinuo.AutoSize = true;
            this.rbContinuo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbContinuo.Location = new System.Drawing.Point(66, 51);
            this.rbContinuo.Name = "rbContinuo";
            this.rbContinuo.Size = new System.Drawing.Size(97, 20);
            this.rbContinuo.TabIndex = 1;
            this.rbContinuo.TabStop = true;
            this.rbContinuo.Text = "CONTINUO";
            this.rbContinuo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 324);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPunto);
            this.Controls.Add(this.cbGradoPertenencia);
            this.Controls.Add(this.rbContinuo);
            this.Controls.Add(this.rbDiscreto);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbGradoPertenencia;
        private System.Windows.Forms.TextBox txtPunto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbDiscreto;
        private System.Windows.Forms.RadioButton rbContinuo;
    }
}

