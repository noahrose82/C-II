namespace MinesweeperGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\minesweeper-tiles being used.
        /// </summary>
        /// <param name="disposing">true if managed C:\Users\james\source\repos\noahrose82\C-II\MineSweeperClasses\minesweeper-tiles should be disposed; otherwise, false.</param>
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
            label1 = new Label();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(765, 47);
            label1.Name = "label1";
            label1.Size = new Size(0, 0);
            label1.TabIndex = 1;
            label1.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(765, 121);
            label3.Name = "label3";
            label3.Size = new Size(0, 0);
            label3.TabIndex = 3;
            label3.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(270, 600);
            button1.Name = "button1";
            button1.Size = new Size(0, 0);
            button1.TabIndex = 5;
            button1.Text = "Restart";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(765, 145);
            label4.Name = "label4";
            label4.Size = new Size(0, 0);
            label4.TabIndex = 4;
            label4.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(765, 71);
            label2.Name = "label2";
            label2.Size = new Size(0, 0);
            label2.TabIndex = 2;
            label2.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 849);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Minesweeper";
            ResumeLayout(false);
            PerformLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}
