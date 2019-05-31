namespace UI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormPickAColor : Form
    {
        private const int k_ButtonSize = 55;
        private const int k_ButtonsInRow = 4;
        private const int k_ButtonsInColumn = 2;
        private const int k_MarginSize = 6;
        private Button m_ButtonPurple;
        private Button m_ButtonBrown;
        private Button m_ButtonLime;
        private Button m_ButtonGold;
        private Button m_ButtonRed;
        private Button m_ButtonBlue;
        private Button m_ButtonTurquoise;
        private Button m_ButtonWhite;
        private Button m_Sender;
 
        public FormPickAColor()
        {
            int length = ((k_ButtonSize + k_MarginSize) * k_ButtonsInRow) + k_MarginSize;
            int height = ((k_ButtonSize + k_MarginSize) * k_ButtonsInColumn) + k_MarginSize;
            int xValue = k_MarginSize;
            int yValue = k_MarginSize;

            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(length, height);           
            this.Name = "FormPickAColor";
            this.Text = "Pick A Color";
            this.MaximizeBox = false;
        
            
            m_ButtonPurple = new Button();
            this.Controls.Add(m_ButtonPurple);
            m_ButtonPurple.BackColor = Color.Purple;
            m_ButtonPurple.Location = new Point(xValue, yValue);
            m_ButtonPurple.Name = "buttonPurple";
            m_ButtonPurple.Size = new Size(k_ButtonSize, k_ButtonSize);
            m_ButtonPurple.TabIndex = 1;
            m_ButtonPurple.Click += new EventHandler(buttonColored_Click);
            
            m_ButtonRed = new Button();
            this.Controls.Add(m_ButtonRed);
            m_ButtonRed.BackColor = Color.Red;
            xValue = k_MarginSize + k_ButtonSize + k_MarginSize;
            m_ButtonRed.Location = new Point(xValue, yValue);
            m_ButtonRed.Name = "buttonRed";
            m_ButtonRed.Size = new Size(k_ButtonSize, k_ButtonSize);
            m_ButtonRed.TabIndex = 2;
            m_ButtonRed.Click += new EventHandler(buttonColored_Click);
           
            m_ButtonLime = new Button();
            this.Controls.Add(m_ButtonLime);
            m_ButtonLime.BackColor = Color.Lime;
            xValue = k_MarginSize + (k_MarginSize + k_ButtonSize) * 2 ;
            m_ButtonLime.Location = new Point(xValue, yValue);
            m_ButtonLime.Name = "buttonLime";
            m_ButtonLime.Size = new Size(k_ButtonSize, k_ButtonSize);
            m_ButtonLime.TabIndex = 3;
            m_ButtonLime.Click += new EventHandler(buttonColored_Click);
           
            m_ButtonTurquoise = new Button();
            this.Controls.Add(m_ButtonTurquoise);
            m_ButtonTurquoise.BackColor = Color.Turquoise;
            xValue = k_MarginSize + (k_MarginSize + k_ButtonSize) * 3;
            m_ButtonTurquoise.Location = new Point(xValue, yValue);
            m_ButtonTurquoise.Name = "buttonTurquoise";
            m_ButtonTurquoise.Size = new Size(k_ButtonSize, k_ButtonSize);
            m_ButtonTurquoise.TabIndex = 4;
            m_ButtonTurquoise.Click += new EventHandler(buttonColored_Click);
            
            m_ButtonBlue = new Button();
            this.Controls.Add(m_ButtonBlue);
            m_ButtonBlue.BackColor = Color.Blue;
            xValue = k_MarginSize;
            yValue = k_MarginSize + k_ButtonSize + k_MarginSize;
            m_ButtonBlue.Location = new Point(xValue, yValue);
            m_ButtonBlue.Name = "buttonBlue";
            m_ButtonBlue.Size = new Size(k_ButtonSize, k_ButtonSize);
            m_ButtonBlue.TabIndex = 5;
            m_ButtonBlue.Click += new EventHandler(buttonColored_Click);
           
            m_ButtonGold = new Button();
            this.Controls.Add(m_ButtonGold);
            m_ButtonGold.BackColor = Color.Gold;
            xValue = k_MarginSize + k_ButtonSize + k_MarginSize;
            yValue = k_MarginSize + k_ButtonSize + k_MarginSize;
            m_ButtonGold.Location = new Point(xValue, yValue);
            m_ButtonGold.Name = "buttonGold";
            m_ButtonGold.Size = new System.Drawing.Size(k_ButtonSize, k_ButtonSize);
            m_ButtonGold.TabIndex = 6;
            m_ButtonGold.Click += new EventHandler(buttonColored_Click);
           
            m_ButtonBrown = new Button();
            this.Controls.Add(m_ButtonBrown);
            m_ButtonBrown.BackColor = Color.Brown;
            xValue = k_MarginSize + (k_MarginSize + k_ButtonSize) * 2;
            yValue = k_MarginSize + k_ButtonSize + k_MarginSize;
            m_ButtonBrown.Location = new Point(xValue, yValue);
            m_ButtonBrown.Name = "buttonBrown";
            m_ButtonBrown.Size = new Size(k_ButtonSize, k_ButtonSize);
            m_ButtonBrown.TabIndex = 7;
            m_ButtonBrown.Click += new EventHandler(buttonColored_Click);
            
            m_ButtonWhite = new Button();
            this.Controls.Add(m_ButtonWhite);
            m_ButtonWhite.BackColor = Color.White;
            xValue = k_MarginSize + (k_MarginSize + k_ButtonSize) * 3;
            yValue = k_MarginSize + k_ButtonSize + k_MarginSize;
            m_ButtonWhite.Location = new Point(xValue, yValue);
            m_ButtonWhite.Name = "buttonWhite";
            m_ButtonWhite.Size = new Size(k_ButtonSize, k_ButtonSize);
            m_ButtonWhite.TabIndex = 8;
            m_ButtonWhite.Click += new EventHandler(buttonColored_Click);
        }

        public Button Sender
        {
            get { return m_Sender; }
            set { m_Sender = value; }
        }

        private void buttonColored_Click(object sender, EventArgs e)
        {
            Sender.BackColor = (sender as Button).BackColor;
            Sender.UseVisualStyleBackColor = true;
            this.Close();           
        }
    }
}
