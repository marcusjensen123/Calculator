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
        Double sum = 0;
        string actionPerformed = "";
        //Variabel så jag har koll på om något av +, -, * eller / är klickat.
        bool operandClick = false;
        bool parseSuccessful;
        Double a = 0;
        Double b = 0;
        Double c = 0;
        Double d = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            //Ta bort innehållet i userInputBox om användaren klickar på en operand.
            if (operandClick)
            {
                userInputBox.Clear();
            }
            operandClick = false;
            Button number = (Button)sender;
            userInputBox.Text = userInputBox.Text + number.Text;
        }
        private void tecken_click(object sender, EventArgs e)
        {

            Button operand = (Button)sender;

            if (sum != 0)
            {
                //Om summan inte är noll så går man igenom denna loop vilket möjliggör seriella uträkningar 
                equal.PerformClick();
                //Tildelar actionPerformed texten i sign.Text, vilket är den knappen som användaren trycker på
                actionPerformed = operand.Text;
                operandClick = true;
                eventLabel.Text = actionPerformed + " " + sum;

            }
            else
            {
                actionPerformed = operand.Text;
                //Try Catch för att kontrollera om användaren klickar på en operand istället.
                try
                {
                    sum = double.Parse(userInputBox.Text);
                }
                catch
                {
                    MessageBox.Show("Välj en siffra innan du klickar på en operand");
                }

                //Gör så att om operand + en nolla inte dyker upp i eventLabel.Text om användaren klickar på en operand först.
                if (!String.IsNullOrEmpty(userInputBox.Text))
                {
                    // Visar de utförda klicken i eventLabel.
                    eventLabel.Text = actionPerformed + " " + sum;
                    operandClick = true;
                }
            }
        }
        private void reset_click(object sender, EventArgs e)
        {
            userInputBox.Clear();
            eventLabel.Text = "";
            sum = 0;
        }
        private void equal_Click_1(object sender, EventArgs e)
        {
            //Switch beroende på vad användaren väljer för operand
            switch (actionPerformed)
            {
                case "+":
                    parseSuccessful = Double.TryParse(userInputBox.Text, out a);
                    if(parseSuccessful == true)
                    {
                        userInputBox.Text = Convert.ToString(sum + a);
                    }
                    
                    break;
                case "-":
                    Double.TryParse(userInputBox.Text, out b);
                    userInputBox.Text = Convert.ToString(sum - b);
                    break;
                case "*":
                    Double.TryParse(userInputBox.Text, out c);
                    userInputBox.Text = Convert.ToString(sum * c);
                    break;
                case "/":
                    try
                    {
                        Double.TryParse(userInputBox.Text, out d);
                        if (Double.IsInfinity(d))
                        {
                            MessageBox.Show("Divison med noll går inte");
                        }
                        userInputBox.Text = Convert.ToString(sum / d);
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
            //Try Catch som kollar om användaren klickar på "=" innan något annat
             sum = Double.Parse(userInputBox.Text);           
               
            
        }
    }
}

