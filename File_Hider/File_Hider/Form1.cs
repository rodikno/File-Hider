using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;


namespace File_Hider
{
    public partial class Form1 : Form
    {
        private const string defaultPassword_SHA256 = "66306b6849d7272b10657dc9f19e7ba9f094d17a2f138405ea869a493a2cccbd";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (folderBrowserDialog1)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    var path = folderBrowserDialog1.SelectedPath;
                    textBox1.Text = path;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void HideUnhideButton_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Введите пароль", "Авторизация");
            string promptValueHash = sha256_hash(promptValue);
            if (isPasswordCorrect(promptValueHash))
            {
                MessageBox.Show("Error Message", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        private bool isPasswordCorrect(string password_SHA256)
        {
            if (password_SHA256 == defaultPassword_SHA256)
            {
                return true;
            }
            else
            {
                return false;
            }
            //check if password hash is equal to hash we have hardcoded in constant
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 200,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 150 };
            textBox.Text = "";
            textBox.UseSystemPasswordChar = true;
            textBox.MaxLength = 14;
            Button confirmation = new Button() { Text = "OK", Left = 70, Width = 50, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
