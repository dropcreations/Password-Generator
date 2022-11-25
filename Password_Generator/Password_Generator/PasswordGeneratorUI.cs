using System;
using System.Drawing;
using System.Windows.Forms;

namespace Password_Generator
{
    public partial class PasswordGeneratorUI : Form
    {
        public PasswordGeneratorUI()
        {
            InitializeComponent();
        }

        // HIde caret from textbox

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        // Create a random character object

        Random randomChar = new Random();

        // Password generator

        private void PasswordGenerator(int PasswordLength)
        {
            string UppercaseChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string LowercaseChar = "abcdefghijklmnopqrstuvwxyz";
            string NumbersChar = "0123456789";
            string SymbolsChar = "!@#$%^&*";
            string CharLibrary = "";
            string randomPassword = "";

            if (chUppercase.Checked == true)
            {
                CharLibrary += UppercaseChar;
            }
            if (chLowercase.Checked == true)
            {
                CharLibrary += LowercaseChar;
            }
            if (chNumbers.Checked == true)
            {
                CharLibrary += NumbersChar;
            }
            if (chSymbols.Checked == true)
            {
                CharLibrary += SymbolsChar;
            }

            for (int i = 0; i < PasswordLength; i++)
            {
                int randomIndex = randomChar.Next(0, CharLibrary.Length);
                randomPassword += CharLibrary[randomIndex];
            }
            txtPassword.Text = randomPassword;
        }

        // Copy button

        private void copyBox_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPassword.Text);
            MessageBox.Show("Password successfully copied to the clipboard!", "Password copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hide blinking cursor

        private void txtBorder_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(txtBorder.Handle);
        }

        private void txtPassword_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(txtPassword.Handle);
        }

        // Copy button's visibility

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            copyBox.Visible = true;
        }

        // Generate button

        private void btGenerate_Click(object sender, EventArgs e)
        {
            if (chUppercase.Checked == false && chLowercase.Checked == false && chNumbers.Checked == false && chSymbols.Checked == false)
            {
                MessageBox.Show("You haven't selceted any character type.\nPlease select at least one type.", "Character type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtPassword.Clear();
                PasswordGenerator(lengthSlider.Value);
                if (lengthSlider.Value == 4)
                {
                    strengthBar.Visible = true;
                    strengthBar.BackColor = Color.Red;
                    strengthBar.Size = new Size(80, 2);
                }
            }
        }

        // length slider's scroll event

        private void lengthSlider_Scroll(object sender, EventArgs e)
        {
            if (chUppercase.Checked == false && chLowercase.Checked == false && chNumbers.Checked == false && chSymbols.Checked == false)
            {
                MessageBox.Show("You haven't selceted any character type.\nPlease select at least one type.", "Character type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sliderValue.Text = lengthSlider.Value.ToString();
                txtPassword.Clear();
                PasswordGenerator(lengthSlider.Value);
                if (lengthSlider.Value == 4 || lengthSlider.Value == 5 || lengthSlider.Value == 6)
                {
                    strengthBar.Visible = true;
                    strengthBar.BackColor = Color.Red;
                    strengthBar.Size = new Size(80, 2);
                }
                else if (lengthSlider.Value == 7 || lengthSlider.Value == 8 || lengthSlider.Value == 9)
                {
                    strengthBar.Visible = true;
                    strengthBar.BackColor = Color.Gold;
                    strengthBar.Size = new Size(160, 2);
                }
                else if (lengthSlider.Value == 10 || lengthSlider.Value == 11 || lengthSlider.Value == 12)
                {
                    strengthBar.Visible = true;
                    strengthBar.BackColor = Color.LimeGreen;
                    strengthBar.Size = new Size(240, 2);
                }
                else if (lengthSlider.Value == 13 || lengthSlider.Value == 14 || lengthSlider.Value == 15 || lengthSlider.Value == 16)
                {
                    strengthBar.Visible = true;
                    strengthBar.BackColor = Color.DeepSkyBlue;
                    strengthBar.Size = new Size(327, 2);
                }
            }
        }
    }
}
