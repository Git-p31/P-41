namespace FactoryMethodWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Label labelResult;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonA = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // buttonA
            // 
            this.buttonA.Location = new System.Drawing.Point(12, 12);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(150, 23);
            this.buttonA.TabIndex = 0;
            this.buttonA.Text = "Создать Продукт A";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.Click += new System.EventHandler(this.buttonA_Click);

            // 
            // buttonB
            // 
            this.buttonB.Location = new System.Drawing.Point(12, 41);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(150, 23);
            this.buttonB.TabIndex = 1;
            this.buttonB.Text = "Создать Продукт B";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Click += new System.EventHandler(this.buttonB_Click);

            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(12, 70);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 13);
            this.labelResult.TabIndex = 2;

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.labelResult);
            this.Name = "Form1";
            this.Text = "Factory Method Example";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
