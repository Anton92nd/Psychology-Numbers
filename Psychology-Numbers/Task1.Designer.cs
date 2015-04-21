namespace Psychology_Numbers
{
	partial class Task1
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
			this.tableLayoutPanel1 = new Psychology_Numbers.Table();
			this.SuspendLayout();
			// 
			// Task1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(705, 370);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Task1";
			this.Text = "Тест 1";
			this.Load += new System.EventHandler(this.Task1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Table tableLayoutPanel1;

	}
}