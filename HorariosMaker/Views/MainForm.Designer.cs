namespace HorariosMaker
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.scheduleDataGrid = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generationLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.configGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.populationTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maxGenerationTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.databaseFilePathTextBox = new System.Windows.Forms.TextBox();
            this.generateDbButton = new System.Windows.Forms.Button();
            this.searchDbTextBox = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.delayTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.coursesTextBox = new System.Windows.Forms.RichTextBox();
            this.courseMaxCountTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleDataGrid)).BeginInit();
            this.configGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // scheduleDataGrid
            // 
            this.scheduleDataGrid.AllowUserToAddRows = false;
            this.scheduleDataGrid.AllowUserToDeleteRows = false;
            this.scheduleDataGrid.AllowUserToResizeColumns = false;
            this.scheduleDataGrid.AllowUserToResizeRows = false;
            this.scheduleDataGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.scheduleDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.scheduleDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.monday,
            this.tuesday,
            this.tednesday,
            this.thursday,
            this.friday});
            this.scheduleDataGrid.EnableHeadersVisualStyles = false;
            this.scheduleDataGrid.Location = new System.Drawing.Point(194, 270);
            this.scheduleDataGrid.MultiSelect = false;
            this.scheduleDataGrid.Name = "scheduleDataGrid";
            this.scheduleDataGrid.ReadOnly = true;
            this.scheduleDataGrid.RowHeadersVisible = false;
            this.scheduleDataGrid.ShowCellErrors = false;
            this.scheduleDataGrid.ShowCellToolTips = false;
            this.scheduleDataGrid.ShowEditingIcon = false;
            this.scheduleDataGrid.ShowRowErrors = false;
            this.scheduleDataGrid.Size = new System.Drawing.Size(555, 377);
            this.scheduleDataGrid.TabIndex = 0;
            // 
            // time
            // 
            this.time.HeaderText = "";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.time.Width = 50;
            // 
            // monday
            // 
            this.monday.HeaderText = "Lunes";
            this.monday.Name = "monday";
            this.monday.ReadOnly = true;
            this.monday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.monday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tuesday
            // 
            this.tuesday.HeaderText = "Martes";
            this.tuesday.Name = "tuesday";
            this.tuesday.ReadOnly = true;
            this.tuesday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tuesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tednesday
            // 
            this.tednesday.HeaderText = "Miercoles";
            this.tednesday.Name = "tednesday";
            this.tednesday.ReadOnly = true;
            this.tednesday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tednesday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // thursday
            // 
            this.thursday.HeaderText = "Jueves";
            this.thursday.Name = "thursday";
            this.thursday.ReadOnly = true;
            this.thursday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.thursday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // friday
            // 
            this.friday.HeaderText = "Viernes";
            this.friday.Name = "friday";
            this.friday.ReadOnly = true;
            this.friday.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.friday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // generationLabel
            // 
            this.generationLabel.AutoSize = true;
            this.generationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generationLabel.Location = new System.Drawing.Point(459, 234);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(130, 25);
            this.generationLabel.TabIndex = 1;
            this.generationLabel.Text = "Generation: 0";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(363, 232);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 32);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Empezar";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // configGroupBox
            // 
            this.configGroupBox.Controls.Add(this.groupBox2);
            this.configGroupBox.Controls.Add(this.delayTextBox);
            this.configGroupBox.Controls.Add(this.label4);
            this.configGroupBox.Controls.Add(this.searchDbTextBox);
            this.configGroupBox.Controls.Add(this.databaseFilePathTextBox);
            this.configGroupBox.Controls.Add(this.label3);
            this.configGroupBox.Controls.Add(this.maxGenerationTextBox);
            this.configGroupBox.Controls.Add(this.label2);
            this.configGroupBox.Controls.Add(this.populationTextBox);
            this.configGroupBox.Controls.Add(this.label1);
            this.configGroupBox.Location = new System.Drawing.Point(194, 12);
            this.configGroupBox.Name = "configGroupBox";
            this.configGroupBox.Size = new System.Drawing.Size(555, 214);
            this.configGroupBox.TabIndex = 4;
            this.configGroupBox.TabStop = false;
            this.configGroupBox.Text = "Configuración";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tamaño de la población:";
            // 
            // populationTextBox
            // 
            this.populationTextBox.Location = new System.Drawing.Point(141, 34);
            this.populationTextBox.MaxLength = 3;
            this.populationTextBox.Name = "populationTextBox";
            this.populationTextBox.Size = new System.Drawing.Size(100, 20);
            this.populationTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Máxima generación:";
            // 
            // maxGenerationTextBox
            // 
            this.maxGenerationTextBox.Location = new System.Drawing.Point(141, 80);
            this.maxGenerationTextBox.MaxLength = 3;
            this.maxGenerationTextBox.Name = "maxGenerationTextBox";
            this.maxGenerationTextBox.Size = new System.Drawing.Size(100, 20);
            this.maxGenerationTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Base de datos:";
            // 
            // databaseFilePathTextBox
            // 
            this.databaseFilePathTextBox.Location = new System.Drawing.Point(14, 188);
            this.databaseFilePathTextBox.MaxLength = 3;
            this.databaseFilePathTextBox.Name = "databaseFilePathTextBox";
            this.databaseFilePathTextBox.ReadOnly = true;
            this.databaseFilePathTextBox.Size = new System.Drawing.Size(245, 20);
            this.databaseFilePathTextBox.TabIndex = 5;
            // 
            // generateDbButton
            // 
            this.generateDbButton.Location = new System.Drawing.Point(6, 160);
            this.generateDbButton.Name = "generateDbButton";
            this.generateDbButton.Size = new System.Drawing.Size(267, 23);
            this.generateDbButton.TabIndex = 6;
            this.generateDbButton.Text = "Generar base de datos aleatoria";
            this.generateDbButton.UseVisualStyleBackColor = true;
            this.generateDbButton.Click += new System.EventHandler(this.generateDbButton_Click);
            // 
            // searchDbTextBox
            // 
            this.searchDbTextBox.Location = new System.Drawing.Point(141, 157);
            this.searchDbTextBox.Name = "searchDbTextBox";
            this.searchDbTextBox.Size = new System.Drawing.Size(100, 23);
            this.searchDbTextBox.TabIndex = 7;
            this.searchDbTextBox.Text = "Buscar";
            this.searchDbTextBox.UseVisualStyleBackColor = true;
            this.searchDbTextBox.Click += new System.EventHandler(this.searchDbTextBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Delay:";
            // 
            // delayTextBox
            // 
            this.delayTextBox.Location = new System.Drawing.Point(141, 120);
            this.delayTextBox.MaxLength = 3;
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.Size = new System.Drawing.Size(100, 20);
            this.delayTextBox.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.courseMaxCountTextBox);
            this.groupBox2.Controls.Add(this.coursesTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.generateDbButton);
            this.groupBox2.Location = new System.Drawing.Point(270, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 189);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generacion de base de datos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Cursos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cantidad por curso:";
            // 
            // coursesTextBox
            // 
            this.coursesTextBox.Location = new System.Drawing.Point(9, 35);
            this.coursesTextBox.Name = "coursesTextBox";
            this.coursesTextBox.Size = new System.Drawing.Size(264, 90);
            this.coursesTextBox.TabIndex = 9;
            this.coursesTextBox.Text = "";
            // 
            // courseMaxCountTextBox
            // 
            this.courseMaxCountTextBox.Location = new System.Drawing.Point(111, 135);
            this.courseMaxCountTextBox.Name = "courseMaxCountTextBox";
            this.courseMaxCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.courseMaxCountTextBox.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 659);
            this.Controls.Add(this.configGroupBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.generationLabel);
            this.Controls.Add(this.scheduleDataGrid);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HorariosMaker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleDataGrid)).EndInit();
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView scheduleDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn tednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn friday;
        private System.Windows.Forms.Label generationLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.GroupBox configGroupBox;
        private System.Windows.Forms.TextBox populationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox maxGenerationTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generateDbButton;
        private System.Windows.Forms.TextBox databaseFilePathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchDbTextBox;
        private System.Windows.Forms.TextBox delayTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox courseMaxCountTextBox;
        private System.Windows.Forms.RichTextBox coursesTextBox;

    }
}

