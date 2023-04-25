using System;
using System.Windows;

namespace Cesar_code
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            string textToEncrypt = textToEncryptTextBox.Text;
            int encryptionKey;
            if (int.TryParse(encryptionKeyTextBox.Text, out encryptionKey))
            {
                string encryptedText = Encrypt(textToEncrypt, encryptionKey);
                encryptedTextBox.Text = encryptedText;
            }
            else
            {
                MessageBox.Show("Please enter a valid encryption key (0-25).");
            }
        }

        private string Encrypt(string textToEncrypt, int encryptionKey)
        {
            string encryptedText = "";
            const int alphabetSize = 26;

            foreach (char c in textToEncrypt)
            {
                if (char.IsLetter(c))
                {
                    char currentChar = char.ToLower(c);
                    int shiftedChar = currentChar + encryptionKey;

                    if (shiftedChar > 'z')
                    {
                        shiftedChar -= alphabetSize;
                    }

                    encryptedText += char.IsLower(c) ? (char)shiftedChar : char.ToUpper((char)shiftedChar);
                }
                else
                {
                    encryptedText += c;
                }
            }

            return encryptedText;
        }
    }
}
