﻿namespace Chat
{
	partial class Configuracion
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.button2 = new System.Windows.Forms.Button();
			this.hora1 = new System.Windows.Forms.NumericUpDown();
			this.seg1 = new System.Windows.Forms.NumericUpDown();
			this.hora2 = new System.Windows.Forms.NumericUpDown();
			this.seg2 = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.hora1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.seg1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hora2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.seg2)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(46, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "HORA INICIO";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(46, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "HORA FIN";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(46, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "DIAS";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(119, 164);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "MENSAJE INICIAL";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(119, 260);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(90, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "MENSAJE FINAL";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(49, 192);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(241, 56);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "Buenos dias";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(49, 285);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(241, 55);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "Buenas Noches";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(79, 359);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "GUARDAR";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(90, 110);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1.TabIndex = 8;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(212, 358);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "FIN";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// hora1
			// 
			this.hora1.Location = new System.Drawing.Point(148, 41);
			this.hora1.Name = "hora1";
			this.hora1.Size = new System.Drawing.Size(42, 20);
			this.hora1.TabIndex = 10;
			// 
			// seg1
			// 
			this.seg1.Location = new System.Drawing.Point(212, 40);
			this.seg1.Name = "seg1";
			this.seg1.Size = new System.Drawing.Size(42, 20);
			this.seg1.TabIndex = 11;
			this.seg1.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
			// 
			// hora2
			// 
			this.hora2.Location = new System.Drawing.Point(148, 68);
			this.hora2.Name = "hora2";
			this.hora2.Size = new System.Drawing.Size(42, 20);
			this.hora2.TabIndex = 12;
			// 
			// seg2
			// 
			this.seg2.Location = new System.Drawing.Point(212, 67);
			this.seg2.Name = "seg2";
			this.seg2.Size = new System.Drawing.Size(42, 20);
			this.seg2.TabIndex = 13;
			// 
			// Configuracion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(348, 394);
			this.Controls.Add(this.seg2);
			this.Controls.Add(this.hora2);
			this.Controls.Add(this.seg1);
			this.Controls.Add(this.hora1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Configuracion";
			this.Text = "Configuracion";
			((System.ComponentModel.ISupportInitialize)(this.hora1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.seg1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hora2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.seg2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.NumericUpDown hora1;
		private System.Windows.Forms.NumericUpDown seg1;
		private System.Windows.Forms.NumericUpDown hora2;
		private System.Windows.Forms.NumericUpDown seg2;
	}
}