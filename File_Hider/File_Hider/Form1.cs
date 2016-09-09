using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.IO;


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
            folderBrowserDialog1.SelectedPath = "";
            using (folderBrowserDialog1)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = folderBrowserDialog1.SelectedPath;
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

        private void HideFileButton_Click(object sender, EventArgs e)
        {
            //ask for file name with extension
            string filename = Prompt.ShowDialog("Введите имя файла", "Введите полное имя файла (напр. example.jpg)");
            //build a string as path to folder get from folderBrowserDialog1 + filename with extension
            string pathToFile = "";
            if (!isPathEmpty(folderBrowserDialog1.SelectedPath))
            {
                pathToFile = textBox1.Text + "\\" + filename;
                setAttributeHidden(pathToFile);
            }
            else
            {
                MessageBox.Show("Выберите папку, где находится файл", "Отсутствует каталог", MessageBoxButtons.OK);
            }
        }

        private void ShowHiddenFileButton_Click(object sender, EventArgs e)
        {
            string promptValue = PasswordPrompt.ShowDialog("Введите пароль", "Авторизация");
            string promptValueHash = sha256_hash(promptValue);
            if (isPasswordCorrect(promptValueHash))
            {
                //ask for file name with extension
                string filename = Prompt.ShowDialog("Введите имя файла", "Введите полное имя файла (напр. example.jpg)");
                //build a string as path to folder get from folderBrowserDialog1 + filename with extension
                string pathToFile = "";
                if (!isPathEmpty(folderBrowserDialog1.SelectedPath))
                {
                    pathToFile = textBox1.Text + "\\" + filename;
                    try
                    {
                        if (isFileHidden(pathToFile))
                        {
                            //REMOVE all specific attributes from file to make it fully visible
                            removeAllSpecificAttributes(pathToFile);
                            MessageBox.Show("Выбранный файл теперь является видимым", "Получилось", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Выбранный файл не является скрытым, пожалуйста, выберите другой", "Ошибка", MessageBoxButtons.OK);
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("Файл не существует в текущем каталоге", "Ошибка", MessageBoxButtons.OK);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Выберите каталог для файла", "Отсутствует каталог", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный пароль", "Ошибка авторизации", MessageBoxButtons.OK);
            }
        }

        private bool isFileHidden(string filePath)
        {
            //try
            //{
                FileAttributes fileAttributes = File.GetAttributes(filePath);
                return ((fileAttributes & FileAttributes.Hidden) == FileAttributes.Hidden) ? true : false;
            //}
            //catch (FileNotFoundException e)
            //{
            //    MessageBox.Show("Файл не существует в текущем каталоге", "Ошибка", MessageBoxButtons.OK);
            //    return false;
            //}

        }

        private void setAttributeHidden(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.SetAttributes(filePath, FileAttributes.Hidden);
            }
            else
            {
                MessageBox.Show("Файл не найден в текущем каталоге", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void removeAllSpecificAttributes(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
            }
            else
            {
                MessageBox.Show("Файл не найден в текущем каталоге", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private bool isPathEmpty(string path)
        {
            return (path == "") ? true : false;
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
            Button confirmation = new Button() { Text = "OK", Left = 70, Width = 50, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }

    public static class PasswordPrompt
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
