using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace juego_de_parejas1
{

    public partial class Form1 : Form
    {

        Label firstClicked = null;


        Label secondClicked = null;

        Random random = new Random();


        List<string> icons = new List<string>()
        {
         "!", "!", "N", "N", ",", ",", "k", "k",
         "b", "b", "v", "v", "w", "w", "z", "z"
        };
        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }
        private void AssignIconsToSquares()
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {

                Label iconLabel = control as Label;
                if (iconLabel != null)

                {
                    iconLabel.ForeColor = iconLabel.BackColor;
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];

                    icons.RemoveAt(randomNumber);

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)

            {
                if (timer1.Enabled == true)
                    return;
                 

                
                if (firstClicked != null)

                {
                    if (clickedLabel.ForeColor == Color.Black)
                        return;

                    if (firstClicked == null)
                    {
                        firstClicked = clickedLabel;
                        firstClicked.ForeColor = Color.Black;

                        return;
                    }


                    secondClicked = clickedLabel;
                    secondClicked.ForeColor = Color.Black;

                    Checkforwinner();

                    if (firstClicked.Text == secondClicked.Text)
                    {
                        firstClicked = null;
                        secondClicked = null;
                        return;
                    }

                    timer1.Start();

                }

            }
        }
       
        private void Checkforwinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("has encontrado todas las parejas, FELICIDADES!!");
                Close();
               
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;


            firstClicked = null;
            secondClicked = null;

        }
    }
}
        
    

    





            