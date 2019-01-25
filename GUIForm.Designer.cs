namespace LuceneAdvancedSearchApplication
{
    partial class GUIForm
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
            this.TextEnter = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.TextShowEnter = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Index = new System.Windows.Forms.Label();
            this.Source = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Standard_button = new System.Windows.Forms.RadioButton();
            this.Snowball = new System.Windows.Forms.RadioButton();
            this.Both = new System.Windows.Forms.RadioButton();
            this.LastButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.keyword = new System.Windows.Forms.RadioButton();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.NumberOfresults = new System.Windows.Forms.Label();
            this.queryExpansion = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.querylabel = new System.Windows.Forms.Label();
            this.WeightTerm = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TextEnter
            // 
            this.TextEnter.Location = new System.Drawing.Point(50, 33);
            this.TextEnter.Margin = new System.Windows.Forms.Padding(2);
            this.TextEnter.Name = "TextEnter";
            this.TextEnter.Size = new System.Drawing.Size(173, 20);
            this.TextEnter.TabIndex = 0;
            this.TextEnter.TextChanged += new System.EventHandler(this.QueryBox_TextChanged);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(245, 28);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(107, 28);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // TextShowEnter
            // 
            this.TextShowEnter.AutoSize = true;
            this.TextShowEnter.Location = new System.Drawing.Point(48, 9);
            this.TextShowEnter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextShowEnter.Name = "TextShowEnter";
            this.TextShowEnter.Size = new System.Drawing.Size(97, 13);
            this.TextShowEnter.TabIndex = 2;
            this.TextShowEnter.Text = "Please enter Query";
            this.TextShowEnter.Click += new System.EventHandler(this.label1_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(426, 48);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(353, 400);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Browse Source Collection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(50, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 27);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save Index ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Index
            // 
            this.Index.AutoSize = true;
            this.Index.Location = new System.Drawing.Point(48, 387);
            this.Index.Name = "Index";
            this.Index.Size = new System.Drawing.Size(78, 13);
            this.Index.TabIndex = 7;
            this.Index.Text = "Index Directory";
            // 
            // Source
            // 
            this.Source.AutoSize = true;
            this.Source.Location = new System.Drawing.Point(56, 262);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(89, 13);
            this.Source.TabIndex = 8;
            this.Source.Text = "Source Directory ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(426, 464);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 29);
            this.button3.TabIndex = 9;
            this.button3.Text = "Save Result";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Result Directory";
            // 
            // Standard_button
            // 
            this.Standard_button.AutoSize = true;
            this.Standard_button.Location = new System.Drawing.Point(50, 72);
            this.Standard_button.Name = "Standard_button";
            this.Standard_button.Size = new System.Drawing.Size(68, 17);
            this.Standard_button.TabIndex = 13;
            this.Standard_button.TabStop = true;
            this.Standard_button.Text = "Standard";
            this.Standard_button.UseVisualStyleBackColor = true;
            this.Standard_button.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Snowball
            // 
            this.Snowball.AutoSize = true;
            this.Snowball.Location = new System.Drawing.Point(150, 72);
            this.Snowball.Name = "Snowball";
            this.Snowball.Size = new System.Drawing.Size(74, 17);
            this.Snowball.TabIndex = 14;
            this.Snowball.TabStop = true;
            this.Snowball.Text = "Snowball  ";
            this.Snowball.UseVisualStyleBackColor = true;
            // 
            // Both
            // 
            this.Both.AutoSize = true;
            this.Both.Location = new System.Drawing.Point(265, 72);
            this.Both.Name = "Both";
            this.Both.Size = new System.Drawing.Size(47, 17);
            this.Both.TabIndex = 15;
            this.Both.TabStop = true;
            this.Both.Text = "Both";
            this.Both.UseVisualStyleBackColor = true;
            // 
            // LastButton
            // 
            this.LastButton.Location = new System.Drawing.Point(608, 464);
            this.LastButton.Name = "LastButton";
            this.LastButton.Size = new System.Drawing.Size(75, 23);
            this.LastButton.TabIndex = 16;
            this.LastButton.Text = "Last Page";
            this.LastButton.UseVisualStyleBackColor = true;
            this.LastButton.Click += new System.EventHandler(this.LastButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(709, 464);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 17;
            this.NextButton.Text = "Next Page";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // keyword
            // 
            this.keyword.AutoSize = true;
            this.keyword.Location = new System.Drawing.Point(336, 72);
            this.keyword.Name = "keyword";
            this.keyword.Size = new System.Drawing.Size(66, 17);
            this.keyword.TabIndex = 18;
            this.keyword.TabStop = true;
            this.keyword.Text = "Keyword";
            this.keyword.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Location = new System.Drawing.Point(790, 12);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(393, 523);
            this.buttonPanel.TabIndex = 19;
            // 
            // NumberOfresults
            // 
            this.NumberOfresults.AutoSize = true;
            this.NumberOfresults.Location = new System.Drawing.Point(423, 28);
            this.NumberOfresults.Name = "NumberOfresults";
            this.NumberOfresults.Size = new System.Drawing.Size(153, 13);
            this.NumberOfresults.TabIndex = 20;
            this.NumberOfresults.Text = "Number of relevant document: ";
            // 
            // queryExpansion
            // 
            this.queryExpansion.AutoSize = true;
            this.queryExpansion.Location = new System.Drawing.Point(45, 109);
            this.queryExpansion.Name = "queryExpansion";
            this.queryExpansion.Size = new System.Drawing.Size(106, 17);
            this.queryExpansion.TabIndex = 21;
            this.queryExpansion.Text = "Query Expansion";
            this.queryExpansion.UseVisualStyleBackColor = true;
            this.queryExpansion.CheckedChanged += new System.EventHandler(this.queryExpansion_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(157, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(155, 29);
            this.button4.TabIndex = 22;
            this.button4.Text = "Load WordNet";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // querylabel
            // 
            this.querylabel.AutoSize = true;
            this.querylabel.Location = new System.Drawing.Point(45, 156);
            this.querylabel.Name = "querylabel";
            this.querylabel.Size = new System.Drawing.Size(60, 13);
            this.querylabel.TabIndex = 23;
            this.querylabel.Text = "Final Query";
            // 
            // WeightTerm
            // 
            this.WeightTerm.AutoSize = true;
            this.WeightTerm.Location = new System.Drawing.Point(181, 156);
            this.WeightTerm.Name = "WeightTerm";
            this.WeightTerm.Size = new System.Drawing.Size(87, 17);
            this.WeightTerm.TabIndex = 24;
            this.WeightTerm.Text = "Weight Term";
            this.WeightTerm.UseVisualStyleBackColor = true;
            this.WeightTerm.CheckedChanged += new System.EventHandler(this.WeightTerm_CheckedChanged);
            // 
            // GUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 576);
            this.Controls.Add(this.WeightTerm);
            this.Controls.Add(this.querylabel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.queryExpansion);
            this.Controls.Add(this.NumberOfresults);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.keyword);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.LastButton);
            this.Controls.Add(this.Both);
            this.Controls.Add(this.Snowball);
            this.Controls.Add(this.Standard_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.Index);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.TextShowEnter);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.TextEnter);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GUIForm";
            this.Text = "GUIForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextEnter;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label TextShowEnter;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label Index;
        private System.Windows.Forms.Label Source;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Standard_button;
        private System.Windows.Forms.RadioButton Snowball;
        private System.Windows.Forms.RadioButton Both;
        private System.Windows.Forms.Button LastButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.RadioButton keyword;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Label NumberOfresults;
        private System.Windows.Forms.CheckBox queryExpansion;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label querylabel;
        public System.Windows.Forms.CheckBox WeightTerm;
    }
}