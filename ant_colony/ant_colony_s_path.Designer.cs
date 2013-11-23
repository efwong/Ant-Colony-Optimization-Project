namespace ant_colony
{
    partial class ant_colony_s_path
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
            this.Draw_button = new System.Windows.Forms.Button();
            this.alpha_Box = new System.Windows.Forms.TextBox();
            this.beta_Box = new System.Windows.Forms.TextBox();
            this.rho_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.random_cities_button = new System.Windows.Forms.Button();
            this.define_cities_Button = new System.Windows.Forms.Button();
            this.number_Cities_Box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.number_Ants_Box = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.iterationBox = new System.Windows.Forms.TextBox();
            this.clear_button = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Best_Tour_Box = new System.Windows.Forms.Label();
            this.brute_force_button = new System.Windows.Forms.Button();
            this.brute_length_label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.totalTimeBrute = new System.Windows.Forms.Label();
            this.timeBruteLabel = new System.Windows.Forms.Label();
            this.antColonyTimeLabel = new System.Windows.Forms.Label();
            this.totalTimeACO = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Draw_button
            // 
            this.Draw_button.Location = new System.Drawing.Point(458, 311);
            this.Draw_button.Name = "Draw_button";
            this.Draw_button.Size = new System.Drawing.Size(75, 55);
            this.Draw_button.TabIndex = 0;
            this.Draw_button.Text = "Ant Colony Optimization";
            this.Draw_button.UseVisualStyleBackColor = true;
            this.Draw_button.Click += new System.EventHandler(this.Draw_button_Click);
            // 
            // alpha_Box
            // 
            this.alpha_Box.Location = new System.Drawing.Point(492, 47);
            this.alpha_Box.Name = "alpha_Box";
            this.alpha_Box.Size = new System.Drawing.Size(41, 20);
            this.alpha_Box.TabIndex = 1;
            this.alpha_Box.Text = "1";
            // 
            // beta_Box
            // 
            this.beta_Box.Location = new System.Drawing.Point(492, 73);
            this.beta_Box.Name = "beta_Box";
            this.beta_Box.Size = new System.Drawing.Size(41, 20);
            this.beta_Box.TabIndex = 2;
            this.beta_Box.Text = "1";
            // 
            // rho_Box
            // 
            this.rho_Box.Location = new System.Drawing.Point(492, 99);
            this.rho_Box.Name = "rho_Box";
            this.rho_Box.Size = new System.Drawing.Size(41, 20);
            this.rho_Box.TabIndex = 3;
            this.rho_Box.Text = "0.5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Alpha: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Beta: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rho:";
            // 
            // random_cities_button
            // 
            this.random_cities_button.Location = new System.Drawing.Point(448, 216);
            this.random_cities_button.Name = "random_cities_button";
            this.random_cities_button.Size = new System.Drawing.Size(124, 21);
            this.random_cities_button.TabIndex = 7;
            this.random_cities_button.Text = "Auto-Random Cities";
            this.random_cities_button.UseVisualStyleBackColor = true;
            this.random_cities_button.Click += new System.EventHandler(this.random_cities_button_Click);
            // 
            // define_cities_Button
            // 
            this.define_cities_Button.Location = new System.Drawing.Point(448, 243);
            this.define_cities_Button.Name = "define_cities_Button";
            this.define_cities_Button.Size = new System.Drawing.Size(91, 23);
            this.define_cities_Button.TabIndex = 8;
            this.define_cities_Button.Text = "Place Cities";
            this.define_cities_Button.UseVisualStyleBackColor = true;
            this.define_cities_Button.Click += new System.EventHandler(this.define_cities_Button_Click);
            // 
            // number_Cities_Box
            // 
            this.number_Cities_Box.Location = new System.Drawing.Point(492, 126);
            this.number_Cities_Box.Name = "number_Cities_Box";
            this.number_Cities_Box.Size = new System.Drawing.Size(41, 20);
            this.number_Cities_Box.TabIndex = 9;
            this.number_Cities_Box.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(433, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "# of Cities:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(437, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "# of Ants:";
            // 
            // number_Ants_Box
            // 
            this.number_Ants_Box.Location = new System.Drawing.Point(492, 152);
            this.number_Ants_Box.Name = "number_Ants_Box";
            this.number_Ants_Box.Size = new System.Drawing.Size(41, 20);
            this.number_Ants_Box.TabIndex = 11;
            this.number_Ants_Box.Text = "20";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "# of Iterations:";
            // 
            // iterationBox
            // 
            this.iterationBox.Location = new System.Drawing.Point(492, 178);
            this.iterationBox.Name = "iterationBox";
            this.iterationBox.Size = new System.Drawing.Size(41, 20);
            this.iterationBox.TabIndex = 13;
            this.iterationBox.Text = "100";
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(448, 272);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(91, 23);
            this.clear_button.TabIndex = 15;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 422);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Best ACO Tour Distance: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(142, 422);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 17;
            // 
            // Best_Tour_Box
            // 
            this.Best_Tour_Box.AutoSize = true;
            this.Best_Tour_Box.Location = new System.Drawing.Point(142, 422);
            this.Best_Tour_Box.Name = "Best_Tour_Box";
            this.Best_Tour_Box.Size = new System.Drawing.Size(13, 13);
            this.Best_Tour_Box.TabIndex = 18;
            this.Best_Tour_Box.Text = "0";
            // 
            // brute_force_button
            // 
            this.brute_force_button.Location = new System.Drawing.Point(458, 372);
            this.brute_force_button.Name = "brute_force_button";
            this.brute_force_button.Size = new System.Drawing.Size(75, 23);
            this.brute_force_button.TabIndex = 19;
            this.brute_force_button.Text = "Brute Force";
            this.brute_force_button.UseVisualStyleBackColor = true;
            this.brute_force_button.Click += new System.EventHandler(this.brute_force_button_Click);
            // 
            // brute_length_label
            // 
            this.brute_length_label.AutoSize = true;
            this.brute_length_label.Location = new System.Drawing.Point(404, 422);
            this.brute_length_label.Name = "brute_length_label";
            this.brute_length_label.Size = new System.Drawing.Size(13, 13);
            this.brute_length_label.TabIndex = 21;
            this.brute_length_label.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 422);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Best Brute Tour Distance: ";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // totalTimeBrute
            // 
            this.totalTimeBrute.AutoSize = true;
            this.totalTimeBrute.Location = new System.Drawing.Point(378, 447);
            this.totalTimeBrute.Name = "totalTimeBrute";
            this.totalTimeBrute.Size = new System.Drawing.Size(13, 13);
            this.totalTimeBrute.TabIndex = 22;
            this.totalTimeBrute.Text = "0";
            // 
            // timeBruteLabel
            // 
            this.timeBruteLabel.AutoSize = true;
            this.timeBruteLabel.Location = new System.Drawing.Point(273, 447);
            this.timeBruteLabel.Name = "timeBruteLabel";
            this.timeBruteLabel.Size = new System.Drawing.Size(99, 13);
            this.timeBruteLabel.TabIndex = 23;
            this.timeBruteLabel.Text = "Brute Total Time(s):";
            // 
            // antColonyTimeLabel
            // 
            this.antColonyTimeLabel.AutoSize = true;
            this.antColonyTimeLabel.Location = new System.Drawing.Point(13, 447);
            this.antColonyTimeLabel.Name = "antColonyTimeLabel";
            this.antColonyTimeLabel.Size = new System.Drawing.Size(96, 13);
            this.antColonyTimeLabel.TabIndex = 24;
            this.antColonyTimeLabel.Text = "ACO Total Time(s):";
            // 
            // totalTimeACO
            // 
            this.totalTimeACO.AutoSize = true;
            this.totalTimeACO.Location = new System.Drawing.Point(115, 447);
            this.totalTimeACO.Name = "totalTimeACO";
            this.totalTimeACO.Size = new System.Drawing.Size(13, 13);
            this.totalTimeACO.TabIndex = 25;
            this.totalTimeACO.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(458, 422);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(425, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Specify Properties:";
            // 
            // ant_colony_s_path
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(599, 469);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.totalTimeACO);
            this.Controls.Add(this.antColonyTimeLabel);
            this.Controls.Add(this.timeBruteLabel);
            this.Controls.Add(this.totalTimeBrute);
            this.Controls.Add(this.brute_length_label);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.brute_force_button);
            this.Controls.Add(this.Best_Tour_Box);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.iterationBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.number_Ants_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.number_Cities_Box);
            this.Controls.Add(this.define_cities_Button);
            this.Controls.Add(this.random_cities_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rho_Box);
            this.Controls.Add(this.beta_Box);
            this.Controls.Add(this.alpha_Box);
            this.Controls.Add(this.Draw_button);
            this.Name = "ant_colony_s_path";
            this.Text = "Ant Colony Optimization";
            this.Load += new System.EventHandler(this.ant_colony_s_path_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Draw_button;
        private System.Windows.Forms.TextBox alpha_Box;
        private System.Windows.Forms.TextBox beta_Box;
        private System.Windows.Forms.TextBox rho_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button random_cities_button;
        private System.Windows.Forms.Button define_cities_Button;
        private System.Windows.Forms.TextBox number_Cities_Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox number_Ants_Box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox iterationBox;
        private System.Windows.Forms.Button clear_button;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Best_Tour_Box;
        private System.Windows.Forms.Button brute_force_button;
        private System.Windows.Forms.Label brute_length_label;
        private System.Windows.Forms.Label label10;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label totalTimeBrute;
        private System.Windows.Forms.Label timeBruteLabel;
        private System.Windows.Forms.Label antColonyTimeLabel;
        private System.Windows.Forms.Label totalTimeACO;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label9;

    }
}

