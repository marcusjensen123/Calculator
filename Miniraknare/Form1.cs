using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miniraknare
{
    public partial class Form1 : Form
    {
        //Deklarerar nödvändiga variablar
        int sum = 0;
        string actionPerformed = "";
        //Variabel så jag har koll på om något av +, -, * eller / är klickat.
        bool signClicked = false;

        public Form1()
        {
            InitializeComponent();

        }

        private void button_click(object sender, EventArgs e)
        {
            //Ta bort innehållet i userInputBox om innehållet är 0 eller användaren klickar på en operand.
            if (userInputBox.Text == "0" || (signClicked == true))
            {
                userInputBox.Clear();
            }
            signClicked = false;
            Button number = (Button)sender;
            userInputBox.Text = userInputBox.Text + number.Text;


        }

        private void tecken_click(object sender, EventArgs e)
        {

            Button sign = (Button)sender;
            //Tildelar actionPerformed texten i sign.Text, vilket är den knappen som användaren trycker på.
            actionPerformed = sign.Text;
            try
            {
                sum = int.Parse(userInputBox.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Talet är för stort. Inga tal mellan 2,147,483,647 och -2,147,483,648 är tillåtna");
            }
            //Visar de utförda klicken i eventLabel.
            eventLabel.Text = sum + " " + actionPerformed;
            signClicked = true;

        }

        private void reset_click(object sender, EventArgs e)
        {
            userInputBox.Clear();
            eventLabel.Text = "";
            sum = 0;
        }

        private void equal_click(object sender, EventArgs e)
        {

            if (sum == 0)
            {
                MessageBox.Show("Använd en miniräknare korrekt istället");
            }

            switch (actionPerformed)
            {
                case "+":
                    userInputBox.Text = (sum + int.Parse(userInputBox.Text)).ToString();
                    break;
                case "-":
                    userInputBox.Text = (sum - int.Parse(userInputBox.Text)).ToString();
                    break;
                case "*":
                    userInputBox.Text = (sum * int.Parse(userInputBox.Text)).ToString();
                    break;
                case "/":
                    try
                    {
                        userInputBox.Text = (sum / int.Parse(userInputBox.Text)).ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Divison med noll går inte");
                    }
                    break;
                default:
                    break;
            }

            eventLabel.Text = " ";


        }


    }
}
