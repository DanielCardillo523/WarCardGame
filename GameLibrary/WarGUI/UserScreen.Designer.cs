namespace WarGUI
{
    partial class UserScreen
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
            this.lblWendyCardCount = new System.Windows.Forms.Label();
            this.lblWraithCardCount = new System.Windows.Forms.Label();
            this.btnDeal = new System.Windows.Forms.Button();
            this.lblBoard = new System.Windows.Forms.Label();
            this.imgPlayer2Card = new System.Windows.Forms.PictureBox();
            this.imgPlayer1Card = new System.Windows.Forms.PictureBox();
            this.vsImage = new System.Windows.Forms.PictureBox();
            this.Warrior2Avatar = new System.Windows.Forms.PictureBox();
            this.Warrior1Avatar = new System.Windows.Forms.PictureBox();
            this.imgPlayer1CardB = new System.Windows.Forms.PictureBox();
            this.imgPlayer1CardC = new System.Windows.Forms.PictureBox();
            this.imgPlayer1CardD = new System.Windows.Forms.PictureBox();
            this.imgPlayer1CardE = new System.Windows.Forms.PictureBox();
            this.imgPlayer2CardB = new System.Windows.Forms.PictureBox();
            this.imgPlayer2CardC = new System.Windows.Forms.PictureBox();
            this.imgPlayer2CardE = new System.Windows.Forms.PictureBox();
            this.imgPlayer2CardD = new System.Windows.Forms.PictureBox();
            this.lblPlayer1Outcome = new System.Windows.Forms.Label();
            this.lblPlayer2Outcome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer2Card)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer1Card)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vsImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warrior2Avatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warrior1Avatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer1CardB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer1CardC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer1CardD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer1CardE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer2CardB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer2CardC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer2CardE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer2CardD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Warrior Wendy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(495, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "White Wraith";
            // 
            // lblWendyCardCount
            // 
            this.lblWendyCardCount.AutoSize = true;
            this.lblWendyCardCount.Location = new System.Drawing.Point(124, 300);
            this.lblWendyCardCount.Name = "lblWendyCardCount";
            this.lblWendyCardCount.Size = new System.Drawing.Size(37, 13);
            this.lblWendyCardCount.TabIndex = 7;
            this.lblWendyCardCount.Text = "Cards:";
            this.lblWendyCardCount.Visible = false;
            // 
            // lblWraithCardCount
            // 
            this.lblWraithCardCount.AutoSize = true;
            this.lblWraithCardCount.Location = new System.Drawing.Point(520, 300);
            this.lblWraithCardCount.Name = "lblWraithCardCount";
            this.lblWraithCardCount.Size = new System.Drawing.Size(37, 13);
            this.lblWraithCardCount.TabIndex = 8;
            this.lblWraithCardCount.Text = "Cards:";
            this.lblWraithCardCount.Visible = false;
            // 
            // btnDeal
            // 
            this.btnDeal.Location = new System.Drawing.Point(311, 279);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(77, 33);
            this.btnDeal.TabIndex = 9;
            this.btnDeal.Text = "Deal";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // lblBoard
            // 
            this.lblBoard.BackColor = System.Drawing.Color.Green;
            this.lblBoard.Location = new System.Drawing.Point(0, 326);
            this.lblBoard.Name = "lblBoard";
            this.lblBoard.Size = new System.Drawing.Size(706, 249);
            this.lblBoard.TabIndex = 11;
            // 
            // imgPlayer2Card
            // 
            this.imgPlayer2Card.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            this.imgPlayer2Card.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgPlayer2Card.Location = new System.Drawing.Point(414, 340);
            this.imgPlayer2Card.Name = "imgPlayer2Card";
            this.imgPlayer2Card.Size = new System.Drawing.Size(71, 96);
            this.imgPlayer2Card.TabIndex = 10;
            this.imgPlayer2Card.TabStop = false;
            // 
            // imgPlayer1Card
            // 
            this.imgPlayer1Card.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            this.imgPlayer1Card.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgPlayer1Card.Location = new System.Drawing.Point(212, 340);
            this.imgPlayer1Card.Name = "imgPlayer1Card";
            this.imgPlayer1Card.Size = new System.Drawing.Size(74, 96);
            this.imgPlayer1Card.TabIndex = 10;
            this.imgPlayer1Card.TabStop = false;
            // 
            // vsImage
            // 
            this.vsImage.BackgroundImage = global::WarGUI.Properties.Resources.vs_gray;
            this.vsImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vsImage.Location = new System.Drawing.Point(295, 58);
            this.vsImage.Name = "vsImage";
            this.vsImage.Size = new System.Drawing.Size(100, 192);
            this.vsImage.TabIndex = 5;
            this.vsImage.TabStop = false;
            // 
            // Warrior2Avatar
            // 
            this.Warrior2Avatar.BackgroundImage = global::WarGUI.Properties.Resources.Warrior1;
            this.Warrior2Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Warrior2Avatar.Location = new System.Drawing.Point(414, 23);
            this.Warrior2Avatar.Name = "Warrior2Avatar";
            this.Warrior2Avatar.Size = new System.Drawing.Size(250, 250);
            this.Warrior2Avatar.TabIndex = 4;
            this.Warrior2Avatar.TabStop = false;
            // 
            // Warrior1Avatar
            // 
            this.Warrior1Avatar.BackgroundImage = global::WarGUI.Properties.Resources.Warrior2c;
            this.Warrior1Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Warrior1Avatar.Location = new System.Drawing.Point(36, 23);
            this.Warrior1Avatar.Name = "Warrior1Avatar";
            this.Warrior1Avatar.Size = new System.Drawing.Size(250, 250);
            this.Warrior1Avatar.TabIndex = 3;
            this.Warrior1Avatar.TabStop = false;
            // 
            // imgPlayer1CardB
            // 
            this.imgPlayer1CardB.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            this.imgPlayer1CardB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgPlayer1CardB.Location = new System.Drawing.Point(127, 340);
            this.imgPlayer1CardB.Name = "imgPlayer1CardB";
            this.imgPlayer1CardB.Size = new System.Drawing.Size(74, 96);
            this.imgPlayer1CardB.TabIndex = 10;
            this.imgPlayer1CardB.TabStop = false;
            this.imgPlayer1CardB.Visible = false;
            // 
            // imgPlayer1CardC
            // 
            this.imgPlayer1CardC.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            this.imgPlayer1CardC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgPlayer1CardC.Location = new System.Drawing.Point(42, 340);
            this.imgPlayer1CardC.Name = "imgPlayer1CardC";
            this.imgPlayer1CardC.Size = new System.Drawing.Size(74, 96);
            this.imgPlayer1CardC.TabIndex = 10;
            this.imgPlayer1CardC.TabStop = false;
            this.imgPlayer1CardC.Visible = false;
            // 
            // imgPlayer1CardD
            // 
            this.imgPlayer1CardD.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            this.imgPlayer1CardD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgPlayer1CardD.Location = new System.Drawing.Point(127, 442);
            this.imgPlayer1CardD.Name = "imgPlayer1CardD";
            this.imgPlayer1CardD.Size = new System.Drawing.Size(74, 96);
            this.imgPlayer1CardD.TabIndex = 12;
            this.imgPlayer1CardD.TabStop = false;
            this.imgPlayer1CardD.Visible = false;
            // 
            // imgPlayer1CardE
            // 
            this.imgPlayer1CardE.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            this.imgPlayer1CardE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgPlayer1CardE.Location = new System.Drawing.Point(212, 442);
            this.imgPlayer1CardE.Name = "imgPlayer1CardE";
            this.imgPlayer1CardE.Size = new System.Drawing.Size(74, 96);
            this.imgPlayer1CardE.TabIndex = 13;
            this.imgPlayer1CardE.TabStop = false;
            this.imgPlayer1CardE.Visible = false;
            // 
            // imgPlayer2CardB
            // 
            this.imgPlayer2CardB.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            this.imgPlayer2CardB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgPlayer2CardB.Location = new System.Drawing.Point(497, 340);
            this.imgPlayer2CardB.Name = "imgPlayer2CardB";
            this.imgPlayer2CardB.Size = new System.Drawing.Size(74, 96);
            this.imgPlayer2CardB.TabIndex = 14;
            this.imgPlayer2CardB.TabStop = false;
            this.imgPlayer2CardB.Visible = false;
            // 
            // imgPlayer2CardC
            // 
            this.imgPlayer2CardC.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            this.imgPlayer2CardC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgPlayer2CardC.Location = new System.Drawing.Point(582, 340);
            this.imgPlayer2CardC.Name = "imgPlayer2CardC";
            this.imgPlayer2CardC.Size = new System.Drawing.Size(74, 96);
            this.imgPlayer2CardC.TabIndex = 15;
            this.imgPlayer2CardC.TabStop = false;
            this.imgPlayer2CardC.Visible = false;
            // 
            // imgPlayer2CardE
            // 
            this.imgPlayer2CardE.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            this.imgPlayer2CardE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgPlayer2CardE.Location = new System.Drawing.Point(413, 442);
            this.imgPlayer2CardE.Name = "imgPlayer2CardE";
            this.imgPlayer2CardE.Size = new System.Drawing.Size(74, 96);
            this.imgPlayer2CardE.TabIndex = 16;
            this.imgPlayer2CardE.TabStop = false;
            this.imgPlayer2CardE.Visible = false;
            // 
            // imgPlayer2CardD
            // 
            this.imgPlayer2CardD.BackgroundImage = global::WarGUI.Properties.Resources.backOfCard;
            this.imgPlayer2CardD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgPlayer2CardD.Location = new System.Drawing.Point(498, 442);
            this.imgPlayer2CardD.Name = "imgPlayer2CardD";
            this.imgPlayer2CardD.Size = new System.Drawing.Size(74, 96);
            this.imgPlayer2CardD.TabIndex = 17;
            this.imgPlayer2CardD.TabStop = false;
            this.imgPlayer2CardD.Visible = false;
            // 
            // lblPlayer1Outcome
            // 
            this.lblPlayer1Outcome.AutoSize = true;
            this.lblPlayer1Outcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1Outcome.ForeColor = System.Drawing.Color.Green;
            this.lblPlayer1Outcome.Location = new System.Drawing.Point(208, 279);
            this.lblPlayer1Outcome.Name = "lblPlayer1Outcome";
            this.lblPlayer1Outcome.Size = new System.Drawing.Size(85, 20);
            this.lblPlayer1Outcome.TabIndex = 18;
            this.lblPlayer1Outcome.Text = "WINNER!";
            this.lblPlayer1Outcome.Visible = false;
            // 
            // lblPlayer2Outcome
            // 
            this.lblPlayer2Outcome.AutoSize = true;
            this.lblPlayer2Outcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2Outcome.ForeColor = System.Drawing.Color.Red;
            this.lblPlayer2Outcome.Location = new System.Drawing.Point(409, 279);
            this.lblPlayer2Outcome.Name = "lblPlayer2Outcome";
            this.lblPlayer2Outcome.Size = new System.Drawing.Size(74, 20);
            this.lblPlayer2Outcome.TabIndex = 19;
            this.lblPlayer2Outcome.Text = "LOSER!";
            this.lblPlayer2Outcome.Visible = false;
            // 
            // UserScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 574);
            this.Controls.Add(this.lblPlayer2Outcome);
            this.Controls.Add(this.lblPlayer1Outcome);
            this.Controls.Add(this.imgPlayer2CardE);
            this.Controls.Add(this.imgPlayer2CardD);
            this.Controls.Add(this.imgPlayer2CardB);
            this.Controls.Add(this.imgPlayer2CardC);
            this.Controls.Add(this.imgPlayer1CardD);
            this.Controls.Add(this.imgPlayer1CardE);
            this.Controls.Add(this.imgPlayer2Card);
            this.Controls.Add(this.imgPlayer1CardC);
            this.Controls.Add(this.imgPlayer1CardB);
            this.Controls.Add(this.imgPlayer1Card);
            this.Controls.Add(this.btnDeal);
            this.Controls.Add(this.lblWraithCardCount);
            this.Controls.Add(this.lblWendyCardCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vsImage);
            this.Controls.Add(this.Warrior2Avatar);
            this.Controls.Add(this.Warrior1Avatar);
            this.Controls.Add(this.lblBoard);
            this.Name = "UserScreen";
            this.Text = "WAR";
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer2Card)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer1Card)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vsImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warrior2Avatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warrior1Avatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer1CardB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer1CardC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer1CardD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer1CardE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer2CardB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer2CardC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer2CardE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer2CardD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox vsImage;
        private System.Windows.Forms.PictureBox Warrior2Avatar;
        private System.Windows.Forms.PictureBox Warrior1Avatar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWendyCardCount;
        private System.Windows.Forms.Label lblWraithCardCount;
        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.PictureBox imgPlayer1Card;
        private System.Windows.Forms.PictureBox imgPlayer2Card;
        private System.Windows.Forms.Label lblBoard;
        private System.Windows.Forms.PictureBox imgPlayer1CardB;
        private System.Windows.Forms.PictureBox imgPlayer1CardC;
        private System.Windows.Forms.PictureBox imgPlayer1CardD;
        private System.Windows.Forms.PictureBox imgPlayer1CardE;
        private System.Windows.Forms.PictureBox imgPlayer2CardB;
        private System.Windows.Forms.PictureBox imgPlayer2CardC;
        private System.Windows.Forms.PictureBox imgPlayer2CardE;
        private System.Windows.Forms.PictureBox imgPlayer2CardD;
        private System.Windows.Forms.Label lblPlayer1Outcome;
        private System.Windows.Forms.Label lblPlayer2Outcome;
    }
}

