namespace IntegracaoMSV
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrlPrimitiva = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtParametros = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTabela = new System.Windows.Forms.TextBox();
            this.lblTabela = new System.Windows.Forms.Label();
            this.listResposta = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleName = "lblUrl";
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digite a URL a ser integrada";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtUrlPrimitiva
            // 
            this.txtUrlPrimitiva.Location = new System.Drawing.Point(46, 88);
            this.txtUrlPrimitiva.Name = "txtUrlPrimitiva";
            this.txtUrlPrimitiva.Size = new System.Drawing.Size(514, 20);
            this.txtUrlPrimitiva.TabIndex = 1;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(210, 280);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(165, 47);
            this.btnEnviar.TabIndex = 12;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtParametros
            // 
            this.txtParametros.Location = new System.Drawing.Point(46, 165);
            this.txtParametros.Name = "txtParametros";
            this.txtParametros.Size = new System.Drawing.Size(253, 20);
            this.txtParametros.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AccessibleName = "lblUrl";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Digite os parametros";
            // 
            // txtTabela
            // 
            this.txtTabela.Location = new System.Drawing.Point(46, 234);
            this.txtTabela.Name = "txtTabela";
            this.txtTabela.Size = new System.Drawing.Size(253, 20);
            this.txtTabela.TabIndex = 16;
            // 
            // lblTabela
            // 
            this.lblTabela.AccessibleName = "lblUrl";
            this.lblTabela.AutoSize = true;
            this.lblTabela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabela.Location = new System.Drawing.Point(42, 202);
            this.lblTabela.Name = "lblTabela";
            this.lblTabela.Size = new System.Drawing.Size(221, 20);
            this.lblTabela.TabIndex = 15;
            this.lblTabela.Text = "Nome da tabela a ser gravada";
            // 
            // listResposta
            // 
            this.listResposta.Location = new System.Drawing.Point(358, 152);
            this.listResposta.Name = "listResposta";
            this.listResposta.Size = new System.Drawing.Size(202, 102);
            this.listResposta.TabIndex = 17;
            this.listResposta.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 450);
            this.Controls.Add(this.listResposta);
            this.Controls.Add(this.txtTabela);
            this.Controls.Add(this.lblTabela);
            this.Controls.Add(this.txtParametros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtUrlPrimitiva);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrlPrimitiva;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtParametros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTabela;
        private System.Windows.Forms.Label lblTabela;
        private System.Windows.Forms.ListView listResposta;
    }
}

