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
            catchButton = new Button();
            runButton = new Button();
            releaseButton = new Button();
            pokemonImage = new PictureBox();
            releasePokemontxt = new TextBox();
            label1 = new Label();
            responseLabel = new Label();
            pokedexNumber = new Label();
            displayMessage = new Label();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pokemonImage).BeginInit();
            SuspendLayout();
            // 
            // catchButton
            // 
            catchButton.Location = new Point(149, 555);
            catchButton.Name = "catchButton";
            catchButton.Size = new Size(85, 46);
            catchButton.TabIndex = 0;
            catchButton.Text = "Catch";
            catchButton.UseVisualStyleBackColor = true;
            catchButton.Click += catchButton_Click;
            // 
            // runButton
            // 
            runButton.Location = new Point(276, 555);
            runButton.Name = "runButton";
            runButton.Size = new Size(85, 46);
            runButton.TabIndex = 2;
            runButton.Text = "Run Away!";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // releaseButton
            // 
            releaseButton.Location = new Point(688, 555);
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
            // releasePokemontxt
            // 
            releasePokemontxt.Location = new Point(526, 568);
            releasePokemontxt.Name = "releasePokemontxt";
            releasePokemontxt.Size = new Size(124, 23);
            releasePokemontxt.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(526, 522);
            label1.Name = "label1";
            label1.Size = new Size(247, 15);
            label1.TabIndex = 6;
            label1.Text = "Type the Pokedex# of the Pokemon to release";
            label1.Click += label1_Click;
            // 
            // responseLabel
            // 
            responseLabel.AutoSize = true;
            responseLabel.Location = new Point(149, 537);
            responseLabel.Name = "responseLabel";
            responseLabel.Size = new Size(0, 15);
            responseLabel.TabIndex = 7;
            // 
            // pokedexNumber
            // 
            pokedexNumber.AutoSize = true;
            pokedexNumber.Location = new Point(149, 9);
            pokedexNumber.Name = "pokedexNumber";
            pokedexNumber.Size = new Size(62, 15);
            pokedexNumber.TabIndex = 8;
            pokedexNumber.Text = "PokeDex# ";
            // 
            // displayMessage
            // 
            displayMessage.AutoSize = true;
            displayMessage.Location = new Point(149, 522);
            displayMessage.Name = "displayMessage";
            displayMessage.Size = new Size(153, 15);
            displayMessage.TabIndex = 9;
            displayMessage.Text = "A Wild Pokemon Appeared!";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(276, 605);
            progressBar1.Maximum = 1025;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(374, 23);
            progressBar1.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 632);
            Controls.Add(progressBar1);
            Controls.Add(displayMessage);
            Controls.Add(pokedexNumber);
            Controls.Add(responseLabel);
            Controls.Add(label1);
            Controls.Add(releasePokemontxt);
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
        private TextBox releasePokemontxt;
        private Label label1;
        private Label responseLabel;
        private Label pokedexNumber;
        private Label displayMessage;
        private ProgressBar progressBar1;
    }
}
