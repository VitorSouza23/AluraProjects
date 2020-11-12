namespace ByteBank.View
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnProcessar = new System.Windows.Forms.Button();
            this.ListResultados = new System.Windows.Forms.ListBox();
            this.TxtTempo = new System.Windows.Forms.Label();
            this.PsgProgresso = new System.Windows.Forms.ProgressBar();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnProcessar
            // 
            this.BtnProcessar.Location = new System.Drawing.Point(12, 402);
            this.BtnProcessar.Name = "BtnProcessar";
            this.BtnProcessar.Size = new System.Drawing.Size(248, 23);
            this.BtnProcessar.TabIndex = 0;
            this.BtnProcessar.Text = "Processar Movimentações";
            this.BtnProcessar.UseVisualStyleBackColor = true;
            this.BtnProcessar.Click += new System.EventHandler(this.BtnProcessar_Click);
            // 
            // ListResultados
            // 
            this.ListResultados.FormattingEnabled = true;
            this.ListResultados.Location = new System.Drawing.Point(13, 13);
            this.ListResultados.Name = "ListResultados";
            this.ListResultados.Size = new System.Drawing.Size(456, 329);
            this.ListResultados.TabIndex = 1;
            // 
            // TxtTempo
            // 
            this.TxtTempo.AutoSize = true;
            this.TxtTempo.Location = new System.Drawing.Point(12, 386);
            this.TxtTempo.Name = "TxtTempo";
            this.TxtTempo.Size = new System.Drawing.Size(0, 13);
            this.TxtTempo.TabIndex = 2;
            // 
            // PsgProgresso
            // 
            this.PsgProgresso.Location = new System.Drawing.Point(15, 349);
            this.PsgProgresso.Name = "PsgProgresso";
            this.PsgProgresso.Size = new System.Drawing.Size(454, 23);
            this.PsgProgresso.TabIndex = 3;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Enabled = false;
            this.BtnCancelar.Location = new System.Drawing.Point(267, 402);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(202, 23);
            this.BtnCancelar.TabIndex = 4;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 437);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.PsgProgresso);
            this.Controls.Add(this.TxtTempo);
            this.Controls.Add(this.ListResultados);
            this.Controls.Add(this.BtnProcessar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnProcessar;
        private System.Windows.Forms.ListBox ListResultados;
        private System.Windows.Forms.Label TxtTempo;
        private System.Windows.Forms.ProgressBar PsgProgresso;
        private System.Windows.Forms.Button BtnCancelar;
    }
}

