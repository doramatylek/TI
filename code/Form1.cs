using Microsoft.VisualBasic.Devices;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TI
{


    public partial class Form1 : Form
    {
        private FileEncryptor encryptor = new FileEncryptor();


        MemoryStream encryptedBuffer = new MemoryStream();
        public Form1()
        {
            InitializeComponent();
         

         
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

    

        private void fileOpenMenu_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Выберите файл";
            openFileDialog1.Filter = "Все файлы (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Чтение байтов из выбранного файла
                    string filePath = openFileDialog1.FileName;
                    byte[] fileContent = File.ReadAllBytes(filePath);

                    // Преобразование байтов в строку с использованием формата
                    string bitString = string.Join(" ", fileContent.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));

                    // Вставка битовой строки в TextBox
                    targetTextBox.Text = bitString;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                }
            }
        }



        private void fileSaveMenu_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Сохранить файл";
            saveFileDialog1.Filter = "Все файлы (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Получение пути к файлу
                    string filePath = saveFileDialog1.FileName;

                    // Извлечение массива байтов из буфера
                    byte[] data = encryptedBuffer.ToArray();

                    // Запись байтов в файл с помощью File.WriteAllBytes
                    File.WriteAllBytes(filePath, data);
                    MessageBox.Show("Файл успешно сохранен.");
                    encryptedBuffer.SetLength(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении файла: " + ex.Message);
                    encryptedBuffer.SetLength(0);
                }
            }
        }











        private byte[] ConvertBinaryStringToByteArray(string binaryString)
        {
            // Убедимся, что строка не длиннее 25 бит
            if (binaryString.Length > 25)
            {
                throw new ArgumentException("Входная строка не должна превышать 25 бит.");
            }

            // Создаем массив байтов, достаточный для 25 бит (4 байта)
            byte[] byteArray = new byte[4];

            // Проходим по каждому символу в строке
            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == '1')
                {
                    byteArray[i / 8] |= (byte)(1 << (7 - (i % 8))); // Устанавливаем бит
                }
            }

            return byteArray;
        }




        private void encoderButton_Click(object sender, EventArgs e)
        {
            // Проверка: строка должна содержать только 0 и 1 и быть длиной 25 символов
            if (keyTextBox.Text.Length != 25 || !keyTextBox.Text.All(c => c == '0' || c == '1'))
            {
                MessageBox.Show("Введите строку из 25 символов (0 и 1) в поле ключа!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                byte[] byteArray = ConvertBinaryStringToByteArray(keyTextBox.Text);
                if (string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    resultTextBox.Text += "Выберите файл перед шифрованием!\r\n";
                    return;
                }

                // Запуск шифрования
                resultTextBox.Text += "Начинается шифрование...\r\n";

                encryptedBuffer = encryptor.StreamEncrypt(openFileDialog1.FileName, byteArray);
                string encryptionLog = encryptor.EncryptionLog;
                resultTextBox.Text += encryptor.EncryptionLog;
                resultTextBox.Text += "Шифрование завершено!\r\n";
            }
              
        }




        private void decodeButton_Click(object sender, EventArgs e)
        {
            // Проверка: строка должна содержать только 0 и 1 и быть длиной 25 символов
            if (keyTextBox.Text.Length != 25 || !keyTextBox.Text.All(c => c == '0' || c == '1'))
            {
                MessageBox.Show("Введите строку из 25 символов (0 и 1) в поле ключа!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                byte[] byteArray = ConvertBinaryStringToByteArray(keyTextBox.Text);
                if (string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    resultTextBox.Text += "Выберите файл перед шифрованием!\r\n";
                    return;
                }

                // Запуск шифрования
                resultTextBox.Text += "Начинается шифрование...\r\n";

                encryptedBuffer = encryptor.StreamEncrypt(openFileDialog1.FileName, byteArray);
                string encryptionLog = encryptor.EncryptionLog;
                resultTextBox.Text += encryptor.EncryptionLog;
                resultTextBox.Text += "Шифрование завершено!\r\n";
            }
        }

        private void keyFileOpenMenu_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Выберите файл";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"; // Убедитесь, что фильтр установлен


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Чтение текста из выбранного файла
                    string filePath = openFileDialog1.FileName;
                    string fileContent = File.ReadAllText(filePath);

                    // Вставка текста в TextBox
                    keyTextBox.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                }
            }
        }

        private void keylabel_Click(object sender, EventArgs e)
        {

        }

        private void keyTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }





}
