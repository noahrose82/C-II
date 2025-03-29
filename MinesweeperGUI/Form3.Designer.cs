namespace MinesweeperGUI
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
         private System.Windows.Forms.Button btnSubmit;

        // You shouldn't manually edit this method unless necessary, as it's auto-generated
        private void InitializeComponent()
        {
            txtName = new TextBox();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(10, 50);
            txtName.Width = 260;
            txtName.TextChanged += new EventHandler(txtName_TextChanged); 
            this.Controls.Add(txtName);
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(90, 115);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(101, 33);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += new EventHandler(btnSubmit_Click);
            // 
            // Form3
            // 
            ClientSize = new Size(300, 250);
            Controls.Add(btnSubmit);
            Controls.Add(txtName);
            Name = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        // Dispose method, which is auto-generated, so do not modify unless needed
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
