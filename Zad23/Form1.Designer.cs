namespace Zad23
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.numChromosomy = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numWielkoscPopulacji = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numTurniej = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numIteracje = new System.Windows.Forms.NumericUpDown();
            this.lvLista = new System.Windows.Forms.ListView();
            this.btnStart2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnStart3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numChromosomy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWielkoscPopulacji)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTurniej)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIteracje)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chromosomy na parametr";
            // 
            // numChromosomy
            // 
            this.numChromosomy.Location = new System.Drawing.Point(203, 20);
            this.numChromosomy.Name = "numChromosomy";
            this.numChromosomy.Size = new System.Drawing.Size(120, 22);
            this.numChromosomy.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(29, 261);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Zad1Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wielkość populacji";
            // 
            // numWielkoscPopulacji
            // 
            this.numWielkoscPopulacji.Location = new System.Drawing.Point(203, 57);
            this.numWielkoscPopulacji.Name = "numWielkoscPopulacji";
            this.numWielkoscPopulacji.Size = new System.Drawing.Size(120, 22);
            this.numWielkoscPopulacji.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Min";
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(227, 108);
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(120, 22);
            this.numMax.TabIndex = 7;
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(62, 110);
            this.numMin.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(120, 22);
            this.numMin.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Procent populacji w turnieju";
            // 
            // numTurniej
            // 
            this.numTurniej.Location = new System.Drawing.Point(227, 156);
            this.numTurniej.Name = "numTurniej";
            this.numTurniej.Size = new System.Drawing.Size(73, 22);
            this.numTurniej.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Liczba iteracji";
            // 
            // numIteracje
            // 
            this.numIteracje.Location = new System.Drawing.Point(227, 200);
            this.numIteracje.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numIteracje.Name = "numIteracje";
            this.numIteracje.Size = new System.Drawing.Size(96, 22);
            this.numIteracje.TabIndex = 12;
            // 
            // lvLista
            // 
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(353, 12);
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(867, 426);
            this.lvLista.TabIndex = 13;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            // 
            // btnStart2
            // 
            this.btnStart2.Location = new System.Drawing.Point(130, 261);
            this.btnStart2.Name = "btnStart2";
            this.btnStart2.Size = new System.Drawing.Size(91, 23);
            this.btnStart2.TabIndex = 14;
            this.btnStart2.Text = "Zad2Start";
            this.btnStart2.UseVisualStyleBackColor = true;
            this.btnStart2.Click += new System.EventHandler(this.btnStart2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(306, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "%";
            // 
            // btnStart3
            // 
            this.btnStart3.Location = new System.Drawing.Point(235, 261);
            this.btnStart3.Name = "btnStart3";
            this.btnStart3.Size = new System.Drawing.Size(91, 23);
            this.btnStart3.TabIndex = 16;
            this.btnStart3.Text = "Zad3Start";
            this.btnStart3.UseVisualStyleBackColor = true;
            this.btnStart3.Click += new System.EventHandler(this.btnStart3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 450);
            this.Controls.Add(this.btnStart3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnStart2);
            this.Controls.Add(this.lvLista);
            this.Controls.Add(this.numIteracje);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numTurniej);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numMin);
            this.Controls.Add(this.numMax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numWielkoscPopulacji);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.numChromosomy);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numChromosomy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWielkoscPopulacji)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTurniej)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIteracje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numChromosomy;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numWielkoscPopulacji;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numTurniej;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numIteracje;
        private System.Windows.Forms.ListView lvLista;
        private System.Windows.Forms.Button btnStart2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnStart3;
    }
}

