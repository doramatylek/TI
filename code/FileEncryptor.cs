using System;
using System.IO;
using System.Linq;
using System.Text;

namespace TI
{
    public class FileEncryptor
    {
        private StringBuilder _encryptionLog = new StringBuilder();

        public string EncryptionLog => _encryptionLog.ToString();

        public byte[] EncryptFunction(byte[] buffer, byte[] register)
        {
            byte[] encryptionKey = GenerateEncryptionKey(register);

            // Добавляем информацию о ключе и исходных данных в лог (в двоичном формате)
            _encryptionLog.AppendLine($"Key (binary): {BytesToBinaryString(encryptionKey)}");
          
            // Шифрование блока данных
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] ^= encryptionKey[i]; // Выполняем XOR для каждого байта данных и ключа
            }

            // Добавляем информацию о зашифрованных данных в лог (в двоичном формате)
            _encryptionLog.AppendLine($"Result (binary): {BytesToBinaryString(buffer)}");
            _encryptionLog.AppendLine("----------------------");

            return buffer;
        }

        // Вспомогательный метод для преобразования массива байт в двоичную строку
        private string BytesToBinaryString(byte[] bytes)
        {
            return string.Join(" ", bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
        }

        public MemoryStream StreamEncrypt(string inputFilePath, byte[] register, int bufferSize = 4)
        {
            MemoryStream encryptedBuffer = new MemoryStream();
            _encryptionLog.Clear(); // Очищаем лог перед новым шифрованием

            // Открытие потока для чтения исходного файла
            using (FileStream inputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;
                int blockCounter = 0;

                while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    _encryptionLog.AppendLine($"Block {++blockCounter}:");

                    // Шифрование прочитанных данных
                    byte[] dataToEncrypt = buffer.Take(bytesRead).ToArray();
                    byte[] encryptedBlock = EncryptFunction(dataToEncrypt, register);

                    // Запись зашифрованного блока в буфер
                    encryptedBuffer.Write(encryptedBlock, 0, encryptedBlock.Length);
                }
            }

            // Возврат зашифрованного буфера
            encryptedBuffer.Position = 0;
            return encryptedBuffer;
        }

        public byte[] GenerateEncryptionKey(byte[] register)
        {
            byte[] key = new byte[4];
           
           

            for (int i = 0; i < 4; i++)
            {
                byte currentByte = 0;

                for (int bit = 0; bit < 8; bit++)
                {
                    int nextBit = GetNextBit(register);
                    currentByte = (byte)((currentByte << 1) | nextBit);
                }

                key[i] = currentByte;
            }

            return key;
        }

        private int GetNextBit(byte[] register)
        {
            if (register.Length < 4)
            {
                throw new ArgumentException("Массив должен содержать как минимум 4 элемента (32 бита).");
            }

            int pushedBit = (register[0] >> 7) & 1;
            int bit23 = (register[2] >>1) & 1;
            int newBit = ((register[0] >> 7) & 1) ^ bit23;

            for (int i = 0; i < register.Length - 1; i++)
            {
                register[i] = (byte)((register[i] << 1) | (register[i + 1] >> 7) & 0x01);
            }

            register[register.Length - 1] = (byte)((register[register.Length - 1] & ~(1 << 7)) | (newBit << 7));

            return pushedBit;
        }
    }
}