namespace Playfair
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
            Input = new TextBox();
            Output = new TextBox();
            Inputkey = new TextBox();
            Outputkey = new TextBox();
            radioButton5x5 = new RadioButton();
            radioButton6x6 = new RadioButton();
            Encrypt = new Button();
            Decrypt = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // Input
            // 
            Input.Location = new Point(6, 30);
            Input.Multiline = true;
            Input.Name = "Input";
            Input.Size = new Size(382, 144);
            Input.TabIndex = 0;
            // 
            // Output
            // 
            Output.Location = new Point(6, 26);
            Output.Multiline = true;
            Output.Name = "Output";
            Output.ReadOnly = true;
            Output.Size = new Size(382, 155);
            Output.TabIndex = 1;
            // 
            // Inputkey
            // 
            Inputkey.Location = new Point(17, 27);
            Inputkey.Multiline = true;
            Inputkey.Name = "Inputkey";
            Inputkey.Size = new Size(217, 46);
            Inputkey.TabIndex = 2;
            Inputkey.TextChanged += Inputkey_TextChanged;
            // 
            // Outputkey
            // 
            Outputkey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Outputkey.Location = new Point(17, 103);
            Outputkey.Multiline = true;
            Outputkey.Name = "Outputkey";
            Outputkey.ReadOnly = true;
            Outputkey.Size = new Size(217, 186);
            Outputkey.TabIndex = 3;
            Outputkey.TextAlign = HorizontalAlignment.Center;
            // 
            // radioButton5x5
            // 
            radioButton5x5.AutoSize = true;
            radioButton5x5.Checked = true;
            radioButton5x5.Location = new Point(240, 161);
            radioButton5x5.Name = "radioButton5x5";
            radioButton5x5.Size = new Size(119, 29);
            radioButton5x5.TabIndex = 4;
            radioButton5x5.TabStop = true;
            radioButton5x5.Text = "5x5 matrix";
            radioButton5x5.UseVisualStyleBackColor = true;
            // 
            // radioButton6x6
            // 
            radioButton6x6.AutoSize = true;
            radioButton6x6.Location = new Point(240, 196);
            radioButton6x6.Name = "radioButton6x6";
            radioButton6x6.Size = new Size(119, 29);
            radioButton6x6.TabIndex = 5;
            radioButton6x6.Text = "6x6 matrix";
            radioButton6x6.UseVisualStyleBackColor = true;
            // 
            // Encrypt
            // 
            Encrypt.Location = new Point(53, 414);
            Encrypt.Name = "Encrypt";
            Encrypt.Size = new Size(112, 34);
            Encrypt.TabIndex = 6;
            Encrypt.Text = "Encrypt";
            Encrypt.UseVisualStyleBackColor = true;
            // 
            // Decrypt
            // 
            Decrypt.Location = new Point(229, 414);
            Decrypt.Name = "Decrypt";
            Decrypt.Size = new Size(112, 34);
            Decrypt.TabIndex = 7;
            Decrypt.Text = "Decrypt";
            Decrypt.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Input);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(394, 180);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Output);
            groupBox2.Location = new Point(12, 208);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(395, 187);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Output";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(radioButton6x6);
            groupBox3.Controls.Add(radioButton5x5);
            groupBox3.Controls.Add(Outputkey);
            groupBox3.Controls.Add(Inputkey);
            groupBox3.Location = new Point(423, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(370, 318);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Key";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 460);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(Decrypt);
            Controls.Add(Encrypt);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox Input;
        private TextBox Output;
        private TextBox Inputkey;
        private TextBox Outputkey;
        private RadioButton radioButton5x5;
        private RadioButton radioButton6x6;
        private Button Encrypt;
        private Button Decrypt;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
    }
}