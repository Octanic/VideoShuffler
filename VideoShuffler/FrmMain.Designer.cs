
namespace VideoShuffler
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdFindApp = new System.Windows.Forms.Button();
            this.cmdFindFolder = new System.Windows.Forms.Button();
            this.txtApp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listFiles = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.numFileQty = new System.Windows.Forms.NumericUpDown();
            this.cmdRun = new System.Windows.Forms.Button();
            this.dlgBuscaArquivo = new System.Windows.Forms.OpenFileDialog();
            this.dlgBuscaDiretorio = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFileQty)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pasta de Origem";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(111, 30);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(403, 20);
            this.txtFolder.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdRefresh);
            this.groupBox1.Controls.Add(this.cmdFindApp);
            this.groupBox1.Controls.Add(this.cmdFindFolder);
            this.groupBox1.Controls.Add(this.txtApp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 134);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuração inicial";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(111, 102);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(353, 20);
            this.txtFilter.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filtro de arquivo";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(470, 100);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(75, 23);
            this.cmdRefresh.TabIndex = 3;
            this.cmdRefresh.Text = "&Atualizar";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdFindApp
            // 
            this.cmdFindApp.Location = new System.Drawing.Point(520, 66);
            this.cmdFindApp.Name = "cmdFindApp";
            this.cmdFindApp.Size = new System.Drawing.Size(25, 23);
            this.cmdFindApp.TabIndex = 5;
            this.cmdFindApp.Text = "...";
            this.cmdFindApp.UseVisualStyleBackColor = true;
            this.cmdFindApp.Click += new System.EventHandler(this.cmdFindApp_Click);
            // 
            // cmdFindFolder
            // 
            this.cmdFindFolder.Location = new System.Drawing.Point(520, 28);
            this.cmdFindFolder.Name = "cmdFindFolder";
            this.cmdFindFolder.Size = new System.Drawing.Size(25, 23);
            this.cmdFindFolder.TabIndex = 4;
            this.cmdFindFolder.Text = "...";
            this.cmdFindFolder.UseVisualStyleBackColor = true;
            this.cmdFindFolder.Click += new System.EventHandler(this.cmdFindFolder_Click);
            // 
            // txtApp
            // 
            this.txtApp.Location = new System.Drawing.Point(111, 68);
            this.txtApp.Name = "txtApp";
            this.txtApp.Size = new System.Drawing.Size(403, 20);
            this.txtApp.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aplicativo de vídeo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listFiles);
            this.groupBox2.Location = new System.Drawing.Point(12, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 200);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultado";
            // 
            // listFiles
            // 
            this.listFiles.HideSelection = false;
            this.listFiles.Location = new System.Drawing.Point(9, 20);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(542, 174);
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pegar                     Arquivos aleatórios";
            // 
            // numFileQty
            // 
            this.numFileQty.Location = new System.Drawing.Point(57, 369);
            this.numFileQty.Name = "numFileQty";
            this.numFileQty.Size = new System.Drawing.Size(46, 20);
            this.numFileQty.TabIndex = 5;
            // 
            // cmdRun
            // 
            this.cmdRun.Location = new System.Drawing.Point(494, 358);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 39);
            this.cmdRun.TabIndex = 6;
            this.cmdRun.Text = "&Executar";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // dlgBuscaArquivo
            // 
            this.dlgBuscaArquivo.Filter = "Executáveis|*.exe";
            this.dlgBuscaArquivo.Title = "Buscar Aplicativo para execução";
            // 
            // dlgBuscaDiretorio
            // 
            this.dlgBuscaDiretorio.Description = "Selecione a pasta para procurar os arquivos";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 414);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.numFileQty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Video Shuffler";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFileQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdFindApp;
        private System.Windows.Forms.Button cmdFindFolder;
        private System.Windows.Forms.TextBox txtApp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numFileQty;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.OpenFileDialog dlgBuscaArquivo;
        private System.Windows.Forms.FolderBrowserDialog dlgBuscaDiretorio;
    }
}

