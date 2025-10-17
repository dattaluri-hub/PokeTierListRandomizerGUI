namespace PokeTierListRandomizerGUI
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
            components = new System.ComponentModel.Container();
            catchButton = new Button();
            runButton = new Button();
            releaseButton = new Button();
            pokemonImage = new PictureBox();
            searchPokemontxt = new TextBox();
            label1 = new Label();
            responseLabel = new Label();
            pokedexNumber = new Label();
            displayMessage = new Label();
            progressBar1 = new ProgressBar();
            Countdown = new System.Windows.Forms.Timer(components);
            Timer = new Label();
            type = new Label();
            height = new Label();
            weight = new Label();
            typeValue = new Label();
            heightValue = new Label();
            weightValue = new Label();
            releasePokemonDdl = new ComboBox();
            searchButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pokemonImage).BeginInit();
            SuspendLayout();
            // 
            // catchButton
            // 
            catchButton.Location = new Point(156, 633);
            catchButton.Name = "catchButton";
            catchButton.Size = new Size(85, 46);
            catchButton.TabIndex = 0;
            catchButton.Text = "Catch";
            catchButton.UseVisualStyleBackColor = true;
            catchButton.Click += catchButton_Click;
            // 
            // runButton
            // 
            runButton.Location = new Point(283, 633);
            runButton.Name = "runButton";
            runButton.Size = new Size(85, 46);
            runButton.TabIndex = 2;
            runButton.Text = "Run Away!";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // releaseButton
            // 
            releaseButton.Location = new Point(688, 677);
            releaseButton.Name = "releaseButton";
            releaseButton.Size = new Size(85, 46);
            releaseButton.TabIndex = 3;
            releaseButton.Text = "Release";
            releaseButton.UseVisualStyleBackColor = true;
            releaseButton.Click += releaseButton_Click;
            // 
            // pokemonImage
            // 
            pokemonImage.Location = new Point(149, 33);
            pokemonImage.Name = "pokemonImage";
            pokemonImage.Size = new Size(624, 459);
            pokemonImage.TabIndex = 4;
            pokemonImage.TabStop = false;
            // 
            // searchPokemontxt
            // 
            searchPokemontxt.Location = new Point(533, 646);
            searchPokemontxt.Name = "searchPokemontxt";
            searchPokemontxt.Size = new Size(124, 23);
            searchPokemontxt.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(533, 600);
            label1.Name = "label1";
            label1.Size = new Size(260, 21);
            label1.TabIndex = 6;
            label1.Text = "Pokedex# of the Pokemon to release";
            label1.Click += label1_Click;
            // 
            // responseLabel
            // 
            responseLabel.AutoSize = true;
            responseLabel.Location = new Point(156, 615);
            responseLabel.Name = "responseLabel";
            responseLabel.Size = new Size(0, 15);
            responseLabel.TabIndex = 7;
            // 
            // pokedexNumber
            // 
            pokedexNumber.AutoSize = true;
            pokedexNumber.Font = new Font("Segoe UI", 12F);
            pokedexNumber.Location = new Point(149, 9);
            pokedexNumber.Name = "pokedexNumber";
            pokedexNumber.Size = new Size(82, 21);
            pokedexNumber.TabIndex = 8;
            pokedexNumber.Text = "PokeDex# ";
            // 
            // displayMessage
            // 
            displayMessage.AutoSize = true;
            displayMessage.Font = new Font("Segoe UI", 12F);
            displayMessage.Location = new Point(156, 600);
            displayMessage.Name = "displayMessage";
            displayMessage.Size = new Size(201, 21);
            displayMessage.TabIndex = 9;
            displayMessage.Text = "A Wild Pokemon Appeared!";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(276, 752);
            progressBar1.Maximum = 1025;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(374, 23);
            progressBar1.TabIndex = 10;
            // 
            // Countdown
            // 
            Countdown.Interval = 1000;
            Countdown.Tick += Countdown_Tick;
            // 
            // Timer
            // 
            Timer.AutoSize = true;
            Timer.Font = new Font("Segoe UI", 20F);
            Timer.Location = new Point(428, 615);
            Timer.Name = "Timer";
            Timer.Size = new Size(47, 37);
            Timer.TabIndex = 11;
            Timer.Text = "60";
            // 
            // type
            // 
            type.AutoSize = true;
            type.Font = new Font("Segoe UI", 15F);
            type.Location = new Point(303, 508);
            type.Name = "type";
            type.Size = new Size(53, 28);
            type.TabIndex = 12;
            type.Text = "Type";
            // 
            // height
            // 
            height.AutoSize = true;
            height.Font = new Font("Segoe UI", 15F);
            height.Location = new Point(418, 508);
            height.Name = "height";
            height.Size = new Size(71, 28);
            height.TabIndex = 13;
            height.Text = "Height";
            // 
            // weight
            // 
            weight.AutoSize = true;
            weight.Font = new Font("Segoe UI", 15F);
            weight.Location = new Point(543, 508);
            weight.Name = "weight";
            weight.Size = new Size(75, 28);
            weight.TabIndex = 14;
            weight.Text = "Weight";
            // 
            // typeValue
            // 
            typeValue.AutoSize = true;
            typeValue.Font = new Font("Segoe UI", 12F);
            typeValue.Location = new Point(303, 553);
            typeValue.Name = "typeValue";
            typeValue.Size = new Size(75, 21);
            typeValue.TabIndex = 15;
            typeValue.Text = "unknown";
            // 
            // heightValue
            // 
            heightValue.AutoSize = true;
            heightValue.Font = new Font("Segoe UI", 12F);
            heightValue.Location = new Point(427, 553);
            heightValue.Name = "heightValue";
            heightValue.Size = new Size(56, 21);
            heightValue.TabIndex = 16;
            heightValue.Text = "00'00\"";
            // 
            // weightValue
            // 
            weightValue.AutoSize = true;
            weightValue.Font = new Font("Segoe UI", 12F);
            weightValue.Location = new Point(552, 553);
            weightValue.Name = "weightValue";
            weightValue.Size = new Size(55, 21);
            weightValue.TabIndex = 17;
            weightValue.Text = "0.0 lbs";
            // 
            // releasePokemonDdl
            // 
            releasePokemonDdl.FormattingEnabled = true;
            releasePokemonDdl.Location = new Point(533, 690);
            releasePokemonDdl.Name = "releasePokemonDdl";
            releasePokemonDdl.Size = new Size(124, 23);
            releasePokemonDdl.TabIndex = 18;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(688, 625);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(85, 46);
            searchButton.TabIndex = 19;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 787);
            Controls.Add(searchButton);
            Controls.Add(releasePokemonDdl);
            Controls.Add(weightValue);
            Controls.Add(heightValue);
            Controls.Add(typeValue);
            Controls.Add(weight);
            Controls.Add(height);
            Controls.Add(type);
            Controls.Add(Timer);
            Controls.Add(progressBar1);
            Controls.Add(displayMessage);
            Controls.Add(pokedexNumber);
            Controls.Add(responseLabel);
            Controls.Add(label1);
            Controls.Add(searchPokemontxt);
            Controls.Add(pokemonImage);
            Controls.Add(releaseButton);
            Controls.Add(runButton);
            Controls.Add(catchButton);
            Name = "Form1";
            Text = "Pokemon Tier List Randomizer";
            ((System.ComponentModel.ISupportInitialize)pokemonImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button catchButton;
        private Button runButton;
        private Button releaseButton;
        private PictureBox pokemonImage;
        private TextBox searchPokemontxt;
        private Label label1;
        private Label responseLabel;
        private Label pokedexNumber;
        private Label displayMessage;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer Countdown;
        private Label Timer;
        private Label type;
        private Label height;
        private Label weight;
        private Label typeValue;
        private Label heightValue;
        private Label weightValue;
        private ComboBox releasePokemonDdl;
        private Button searchButton;
    }
}
