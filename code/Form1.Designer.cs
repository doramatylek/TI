namespace TI
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
            menuStrip1 = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            fileOpenMenu = new ToolStripMenuItem();
            fileSaveMenu = new ToolStripMenuItem();
            keyTextBox = new TextBox();
            keylabel = new Label();
            targetTextlabel = new Label();
            targetTextBox = new TextBox();
            resultTextLabel = new Label();
            resultTextBox = new TextBox();
            encoderButton = new Button();
            decodeButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(614, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { fileOpenMenu, fileSaveMenu });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(46, 24);
            fileMenu.Text = "File";
            // 
            // fileOpenMenu
            // 
            fileOpenMenu.Name = "fileOpenMenu";
            fileOpenMenu.Size = new Size(155, 26);
            fileOpenMenu.Text = "File Open";
            fileOpenMenu.Click += fileOpenMenu_Click;
            // 
            // fileSaveMenu
            // 
            fileSaveMenu.Name = "fileSaveMenu";
            fileSaveMenu.Size = new Size(155, 26);
            fileSaveMenu.Text = "File Save";
            fileSaveMenu.Click += fileSaveMenu_Click;
            // 
            // keyTextBox
            // 
            keyTextBox.Location = new Point(23, 86);
            keyTextBox.MaxLength = 25;
            keyTextBox.Name = "keyTextBox";
            keyTextBox.Size = new Size(125, 27);
            keyTextBox.TabIndex = 1;
            keyTextBox.TextChanged += keyTextBox_TextChanged;
            // 
            // keylabel
            // 
            keylabel.AutoSize = true;
            keylabel.Location = new Point(23, 51);
            keylabel.Name = "keylabel";
            keylabel.Size = new Size(156, 20);
            keylabel.TabIndex = 2;
            keylabel.Text = "Введите регистр (25):";
            keylabel.Click += keylabel_Click;
            // 
            // targetTextlabel
            // 
            targetTextlabel.AutoSize = true;
            targetTextlabel.Location = new Point(23, 134);
            targetTextlabel.Name = "targetTextlabel";
            targetTextlabel.Size = new Size(120, 20);
            targetTextlabel.TabIndex = 3;
            targetTextlabel.Text = "исходный файл:";
            // 
            // targetTextBox
            // 
            targetTextBox.Location = new Point(23, 172);
            targetTextBox.MaxLength = 327678;
            targetTextBox.Multiline = true;
            targetTextBox.Name = "targetTextBox";
            targetTextBox.ScrollBars = ScrollBars.Both;
            targetTextBox.Size = new Size(242, 234);
            targetTextBox.TabIndex = 4;
            // 
            // resultTextLabel
            // 
            resultTextLabel.AutoSize = true;
            resultTextLabel.Location = new Point(329, 134);
            resultTextLabel.Name = "resultTextLabel";
            resultTextLabel.Size = new Size(79, 20);
            resultTextLabel.TabIndex = 5;
            resultTextLabel.Text = "результат:";
            // 
            // resultTextBox
            // 
            resultTextBox.Location = new Point(329, 172);
            resultTextBox.MaxLength = 327678;
            resultTextBox.Multiline = true;
            resultTextBox.Name = "resultTextBox";
            resultTextBox.ScrollBars = ScrollBars.Both;
            resultTextBox.Size = new Size(254, 234);
            resultTextBox.TabIndex = 6;
            // 
            // encoderButton
            // 
            encoderButton.Location = new Point(170, 86);
            encoderButton.Name = "encoderButton";
            encoderButton.Size = new Size(153, 29);
            encoderButton.TabIndex = 7;
            encoderButton.Text = "Зашифровать";
            encoderButton.UseVisualStyleBackColor = true;
            encoderButton.Click += encoderButton_Click;
            // 
            // decodeButton
            // 
            decodeButton.Location = new Point(347, 86);
            decodeButton.Name = "decodeButton";
            decodeButton.Size = new Size(163, 29);
            decodeButton.TabIndex = 8;
            decodeButton.Text = "Расшифровать";
            decodeButton.UseVisualStyleBackColor = true;
            decodeButton.Click += decodeButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "\"Text Files (*.txt)|*.txt\"";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "\"Text Files (*.txt)|*.txt\"";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 450);
            Controls.Add(decodeButton);
            Controls.Add(encoderButton);
            Controls.Add(resultTextBox);
            Controls.Add(resultTextLabel);
            Controls.Add(targetTextBox);
            Controls.Add(targetTextlabel);
            Controls.Add(keylabel);
            Controls.Add(keyTextBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "ТИ Лаб. раб. 1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem fileOpenMenu;
        private ToolStripMenuItem fileSaveMenu;
        private TextBox keyTextBox;
        private Label keylabel;
        private Label targetTextlabel;
        private TextBox targetTextBox;
        private Label resultTextLabel;
        private TextBox resultTextBox;
        private Button encoderButton;
        private Button decodeButton;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
