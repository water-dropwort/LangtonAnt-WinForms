
namespace LangtonAnt_WinForms
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
            this.pctboxCells = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblStepTitle = new System.Windows.Forms.Label();
            this.lblStepValue = new System.Windows.Forms.Label();
            this.grpParameter = new System.Windows.Forms.GroupBox();
            this.btnDeleteAntParam = new System.Windows.Forms.Button();
            this.btnAddAntParam = new System.Windows.Forms.Button();
            this.dgrdAntParameter = new System.Windows.Forms.DataGridView();
            this.positionX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initDirection = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txbCellsWidth = new System.Windows.Forms.TextBox();
            this.lblCellsWidthTitle = new System.Windows.Forms.Label();
            this.txbCellsHeight = new System.Windows.Forms.TextBox();
            this.lblCellsHeightTitle = new System.Windows.Forms.Label();
            this.txbRule = new System.Windows.Forms.TextBox();
            this.lblRuleTitle = new System.Windows.Forms.Label();
            this.pctboxColorPalette = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctboxCells)).BeginInit();
            this.grpParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdAntParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctboxColorPalette)).BeginInit();
            this.SuspendLayout();
 
            this.pctboxCells.Location = new System.Drawing.Point(120, 24);
            this.pctboxCells.Name = "pctboxCells";
            this.pctboxCells.Size = new System.Drawing.Size(952, 800);
            this.pctboxCells.TabIndex = 0;
            this.pctboxCells.TabStop = false;
            
            this.btnStart.Location = new System.Drawing.Point(1096, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 40);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            
            this.btnStop.Location = new System.Drawing.Point(1224, 24);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 40);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            
            this.lblStepTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStepTitle.Location = new System.Drawing.Point(1104, 72);
            this.lblStepTitle.Name = "lblStepTitle";
            this.lblStepTitle.Size = new System.Drawing.Size(48, 24);
            this.lblStepTitle.TabIndex = 3;
            this.lblStepTitle.Text = "Gen = ";
            this.lblStepTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            this.lblStepValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStepValue.Location = new System.Drawing.Point(1152, 72);
            this.lblStepValue.Name = "lblStepValue";
            this.lblStepValue.Size = new System.Drawing.Size(176, 24);
            this.lblStepValue.TabIndex = 4;
            this.lblStepValue.Text = "0";
            this.lblStepValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            this.grpParameter.Controls.Add(this.btnDeleteAntParam);
            this.grpParameter.Controls.Add(this.btnAddAntParam);
            this.grpParameter.Controls.Add(this.dgrdAntParameter);
            this.grpParameter.Controls.Add(this.txbCellsWidth);
            this.grpParameter.Controls.Add(this.lblCellsWidthTitle);
            this.grpParameter.Controls.Add(this.txbCellsHeight);
            this.grpParameter.Controls.Add(this.lblCellsHeightTitle);
            this.grpParameter.Controls.Add(this.txbRule);
            this.grpParameter.Controls.Add(this.lblRuleTitle);
            this.grpParameter.Location = new System.Drawing.Point(1088, 104);
            this.grpParameter.Name = "grpParameter";
            this.grpParameter.Size = new System.Drawing.Size(264, 720);
            this.grpParameter.TabIndex = 5;
            this.grpParameter.TabStop = false;
            this.grpParameter.Text = "Parameter";
            
            this.btnDeleteAntParam.Location = new System.Drawing.Point(176, 136);
            this.btnDeleteAntParam.Name = "btnDeleteAntParam";
            this.btnDeleteAntParam.Size = new System.Drawing.Size(72, 24);
            this.btnDeleteAntParam.TabIndex = 15;
            this.btnDeleteAntParam.Text = "Delete";
            this.btnDeleteAntParam.UseVisualStyleBackColor = true;
            
            this.btnAddAntParam.Location = new System.Drawing.Point(88, 136);
            this.btnAddAntParam.Name = "btnAddAntParam";
            this.btnAddAntParam.Size = new System.Drawing.Size(72, 24);
            this.btnAddAntParam.TabIndex = 14;
            this.btnAddAntParam.Text = "Add";
            this.btnAddAntParam.UseVisualStyleBackColor = true;
            
            this.dgrdAntParameter.AllowUserToAddRows = false;
            this.dgrdAntParameter.AllowUserToDeleteRows = false;
            this.dgrdAntParameter.AllowUserToResizeColumns = false;
            this.dgrdAntParameter.AllowUserToResizeRows = false;
            this.dgrdAntParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdAntParameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.positionX,
            this.positionY,
            this.initDirection});
            this.dgrdAntParameter.GridColor = System.Drawing.Color.Gainsboro;
            this.dgrdAntParameter.Location = new System.Drawing.Point(16, 176);
            this.dgrdAntParameter.Name = "dgrdAntParameter";
            this.dgrdAntParameter.RowHeadersVisible = false;
            this.dgrdAntParameter.RowTemplate.Height = 25;
            this.dgrdAntParameter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdAntParameter.Size = new System.Drawing.Size(232, 512);
            this.dgrdAntParameter.TabIndex = 16;
            
            this.positionX.HeaderText = "X";
            this.positionX.Name = "positionX";
            this.positionX.Width = 64;
            
            this.positionY.HeaderText = "Y";
            this.positionY.Name = "positionY";
            this.positionY.Width = 64;
            
            this.initDirection.HeaderText = "Direction";
            this.initDirection.Name = "initDirection";
            this.initDirection.Width = 88;
            
            this.txbCellsWidth.Location = new System.Drawing.Point(88, 64);
            this.txbCellsWidth.Name = "txbCellsWidth";
            this.txbCellsWidth.Size = new System.Drawing.Size(160, 23);
            this.txbCellsWidth.TabIndex = 8;
            
            this.lblCellsWidthTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCellsWidthTitle.Location = new System.Drawing.Point(16, 64);
            this.lblCellsWidthTitle.Name = "lblCellsWidthTitle";
            this.lblCellsWidthTitle.Size = new System.Drawing.Size(64, 24);
            this.lblCellsWidthTitle.TabIndex = 10;
            this.lblCellsWidthTitle.Text = "Width";
            this.lblCellsWidthTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            this.txbCellsHeight.Location = new System.Drawing.Point(88, 96);
            this.txbCellsHeight.Name = "txbCellsHeight";
            this.txbCellsHeight.Size = new System.Drawing.Size(160, 23);
            this.txbCellsHeight.TabIndex = 9;
            
            this.lblCellsHeightTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCellsHeightTitle.Location = new System.Drawing.Point(16, 96);
            this.lblCellsHeightTitle.Name = "lblCellsHeightTitle";
            this.lblCellsHeightTitle.Size = new System.Drawing.Size(64, 24);
            this.lblCellsHeightTitle.TabIndex = 8;
            this.lblCellsHeightTitle.Text = "Height";
            this.lblCellsHeightTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            this.txbRule.Location = new System.Drawing.Point(88, 32);
            this.txbRule.Name = "txbRule";
            this.txbRule.Size = new System.Drawing.Size(160, 23);
            this.txbRule.TabIndex = 7;
            
            this.lblRuleTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRuleTitle.Location = new System.Drawing.Point(16, 32);
            this.lblRuleTitle.Name = "lblRuleTitle";
            this.lblRuleTitle.Size = new System.Drawing.Size(64, 24);
            this.lblRuleTitle.TabIndex = 6;
            this.lblRuleTitle.Text = "Rule";
            this.lblRuleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            this.pctboxColorPalette.Location = new System.Drawing.Point(24, 24);
            this.pctboxColorPalette.Name = "pctboxColorPalette";
            this.pctboxColorPalette.Size = new System.Drawing.Size(96, 800);
            this.pctboxColorPalette.TabIndex = 6;
            this.pctboxColorPalette.TabStop = false;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 839);
            this.Controls.Add(this.pctboxColorPalette);
            this.Controls.Add(this.grpParameter);
            this.Controls.Add(this.lblStepValue);
            this.Controls.Add(this.lblStepTitle);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pctboxCells);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Langton\'s ant simulator";
            ((System.ComponentModel.ISupportInitialize)(this.pctboxCells)).EndInit();
            this.grpParameter.ResumeLayout(false);
            this.grpParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdAntParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctboxColorPalette)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctboxCells;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStepTitle;
        private System.Windows.Forms.Label lblStepValue;
        private System.Windows.Forms.GroupBox grpParameter;
        private System.Windows.Forms.TextBox txbRule;
        private System.Windows.Forms.Label lblRuleTitle;
        private System.Windows.Forms.TextBox txbCellsWidth;
        private System.Windows.Forms.Label lblCellsWidthTitle;
        private System.Windows.Forms.TextBox txbCellsHeight;
        private System.Windows.Forms.Label lblCellsHeightTitle;
        private System.Windows.Forms.DataGridView dgrdAntParameter;
        private System.Windows.Forms.Button btnDeleteAntParam;
        private System.Windows.Forms.Button btnAddAntParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionX;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionY;
        private System.Windows.Forms.DataGridViewComboBoxColumn initDirection;
        private System.Windows.Forms.PictureBox pctboxColorPalette;
    }
}

