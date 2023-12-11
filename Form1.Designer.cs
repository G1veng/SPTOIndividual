namespace SPTOIndividual
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
            formsPlot1 = new ScottPlot.FormsPlot();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            coefficients = new TextBox();
            startTest = new Button();
            label6 = new Label();
            label7 = new Label();
            leftBorder = new TextBox();
            rightBorder = new TextBox();
            stepStart = new TextBox();
            stepEnd = new TextBox();
            stepOfStep = new TextBox();
            label4 = new Label();
            compareError = new TextBox();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(267, 1);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(532, 448);
            formsPlot1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 33);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 1;
            label1.Text = "Левая граница:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 80);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 2;
            label2.Text = "Правая граница:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 135);
            label3.Name = "label3";
            label3.Size = new Size(125, 15);
            label3.TabIndex = 5;
            label3.Text = "Шаг интегрирования:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 236);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 9;
            label5.Text = "Коэффициенты:";
            // 
            // coefficients
            // 
            coefficients.Location = new Point(173, 233);
            coefficients.Name = "coefficients";
            coefficients.Size = new Size(94, 23);
            coefficients.TabIndex = 10;
            coefficients.KeyPress += coefficientsBox_KeyPress;
            // 
            // startTest
            // 
            startTest.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            startTest.Location = new Point(92, 330);
            startTest.Name = "startTest";
            startTest.Size = new Size(134, 43);
            startTest.TabIndex = 11;
            startTest.Text = "Тестирование";
            startTest.UseVisualStyleBackColor = true;
            startTest.Click += startTest_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(215, 135);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 12;
            label6.Text = "-";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(43, 173);
            label7.Name = "label7";
            label7.Size = new Size(100, 30);
            label7.TabIndex = 14;
            label7.Text = "Шаг шага \r\nинтегрирования:";
            // 
            // leftBorder
            // 
            leftBorder.Location = new Point(170, 30);
            leftBorder.Name = "leftBorder";
            leftBorder.Size = new Size(100, 23);
            leftBorder.TabIndex = 16;
            leftBorder.KeyPress += textBox_KeyPress;
            // 
            // rightBorder
            // 
            rightBorder.Location = new Point(170, 77);
            rightBorder.Name = "rightBorder";
            rightBorder.Size = new Size(100, 23);
            rightBorder.TabIndex = 17;
            rightBorder.KeyPress += textBox_KeyPress;
            // 
            // stepStart
            // 
            stepStart.Location = new Point(165, 132);
            stepStart.Name = "stepStart";
            stepStart.Size = new Size(49, 23);
            stepStart.TabIndex = 18;
            stepStart.KeyPress += textBox_KeyPress;
            // 
            // stepEnd
            // 
            stepEnd.Location = new Point(228, 132);
            stepEnd.Name = "stepEnd";
            stepEnd.Size = new Size(49, 23);
            stepEnd.TabIndex = 19;
            stepEnd.KeyPress += textBox_KeyPress;
            // 
            // stepOfStep
            // 
            stepOfStep.Location = new Point(183, 180);
            stepOfStep.Name = "stepOfStep";
            stepOfStep.Size = new Size(70, 23);
            stepOfStep.TabIndex = 20;
            stepOfStep.KeyPress += textBox_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 270);
            label4.Name = "label4";
            label4.Size = new Size(86, 30);
            label4.TabIndex = 21;
            label4.Text = "Погрешность \r\nсравнения:";
            // 
            // compareError
            // 
            compareError.Location = new Point(173, 277);
            compareError.Name = "compareError";
            compareError.Size = new Size(94, 23);
            compareError.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(compareError);
            Controls.Add(label4);
            Controls.Add(stepOfStep);
            Controls.Add(stepEnd);
            Controls.Add(stepStart);
            Controls.Add(rightBorder);
            Controls.Add(leftBorder);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(startTest);
            Controls.Add(coefficients);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(formsPlot1);
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Form1";
            Text = "Вариант 2 (Варьирование шага интегрирования)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private TextBox coefficients;
        private Button startTest;
        private Label label6;
        private Label label7;
        private TextBox leftBorder;
        private TextBox rightBorder;
        private TextBox stepStart;
        private TextBox stepEnd;
        private TextBox stepOfStep;
        private Label label4;
        private TextBox compareError;
    }
}