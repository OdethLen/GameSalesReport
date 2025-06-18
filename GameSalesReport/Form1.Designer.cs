namespace GameSalesReport
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRead = new Button();
            dgvData = new DataGridView();
            btnPie = new Button();
            formsPlotPie = new ScottPlot.WinForms.FormsPlot();
            treeViewData = new TreeView();
            btnTreeView = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // btnRead
            // 
            btnRead.Location = new Point(27, 43);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(75, 23);
            btnRead.TabIndex = 0;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(135, 43);
            dgvData.Name = "dgvData";
            dgvData.Size = new Size(656, 197);
            dgvData.TabIndex = 1;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // btnPie
            // 
            btnPie.Location = new Point(261, 261);
            btnPie.Name = "btnPie";
            btnPie.Size = new Size(75, 23);
            btnPie.TabIndex = 2;
            btnPie.Text = "Pie";
            btnPie.UseVisualStyleBackColor = true;
            btnPie.Click += btnPie_Click;
            // 
            // formsPlotPie
            // 
            formsPlotPie.DisplayScale = 1F;
            formsPlotPie.Location = new Point(27, 290);
            formsPlotPie.Name = "formsPlotPie";
            formsPlotPie.Size = new Size(538, 271);
            formsPlotPie.TabIndex = 3;
            formsPlotPie.Load += formsPlotPie_Load;
            // 
            // treeViewData
            // 
            treeViewData.Location = new Point(592, 290);
            treeViewData.Name = "treeViewData";
            treeViewData.Size = new Size(226, 271);
            treeViewData.TabIndex = 4;
            treeViewData.AfterSelect += treeViewData_AfterSelect;
            // 
            // btnTreeView
            // 
            btnTreeView.Location = new Point(657, 261);
            btnTreeView.Name = "btnTreeView";
            btnTreeView.Size = new Size(75, 23);
            btnTreeView.TabIndex = 5;
            btnTreeView.Text = "Tree";
            btnTreeView.UseVisualStyleBackColor = true;
            btnTreeView.Click += btnTreeView_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 573);
            Controls.Add(btnTreeView);
            Controls.Add(treeViewData);
            Controls.Add(formsPlotPie);
            Controls.Add(btnPie);
            Controls.Add(dgvData);
            Controls.Add(btnRead);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRead;
        private DataGridView dgvData;
        private Button btnPie;
        private ScottPlot.WinForms.FormsPlot formsPlotPie;
        private TreeView treeViewData;
        private Button btnTreeView;
    }
}
