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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void HideFileButton_Click(object sender, EventArgs e)
        {
            string pathToFile = getPathToFileFromDialog();
            if (!isPathEmpty(pathToFile))
            {
                setAttributeHidden(pathToFile);
                MessageBox.Show("Выбранный файл теперь скрыт", "Успех", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите файл", "Файл не выбран", MessageBoxButtons.OK);
            }
        }

        private void ShowHiddenFileButton_Click(object sender, EventArgs e)
        {
            string promptValue = PasswordPrompt.ShowDialog("Введите пароль", "Авторизация");
            string promptValueHash = sha256_hash(promptValue);
            if (isPasswordCorrect(promptValueHash))
            {
                //open choose folder dialog to choose folder where file is located potntially
                folderBrowserDialog1.SelectedPath = "";
                string pathToFile = "";
                using (folderBrowserDialog1)
                {
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pathToFile = folderBrowserDialog1.SelectedPath;
                    }
                }
                //ask for file name with extension
                string filename = Prompt.ShowDialog("Напр. image.jpg", "Введите имя файла");
                //build a string as path to folder get from folderBrowserDialog1 + filename with extension
                if (!isPathEmpty(pathToFile))
                {
                    string fullPathToFile = pathToFile + @"\" + filename;
                    try
                    {
                        if (isFileHidden(fullPathToFile))
                        {
                            //REMOVE all specific attributes from file to make it fully visible
                            removeAllSpecificAttributes(fullPathToFile);
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

        //HELPER METHODS BELOW
        private string getPathToFileFromDialog()
        {
            using (openFileDialog1)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog1.FileName;
                    return filename;
                }
                else
                {
                    return "";
                }
            }
        }

        private bool isFileHidden(string filePath)
        {
                FileAttributes fileAttributes = File.GetAttributes(filePath);
                return ((fileAttributes & FileAttributes.Hidden) == FileAttributes.Hidden) ? true : false;
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

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

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
