using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Windows;

namespace Processes.Multithreads.HW
{
    public class Crypt
    {
        // Ctor - default
        public Crypt()
        {
            cryptInfo = new CryptInfo();
        }

        // Crypt info
        [JsonIgnore]
        public CryptInfo cryptInfo;

        // if IsEncrypt equeals true - true, if IsDecrypt equeals true - false
        public bool? CryptType { get; set; } = null;

        // Editable file
        public string FullPath { get; set; } = null;

        // Editable file passwd
        public ulong? Password { get; set; } = null;

        // Editable file message
        public string MessagePath { get; set; }

        // XOR Enrypt
        public static void Encrypt(object obj)
        {
            CryptInfo cryptInfo = obj as CryptInfo;

            if (cryptInfo == null)
            {
                MessageBox.Show("CryptInfo is equeal null.");
                return;
            }

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).Progress.Maximum = cryptInfo.Message.Length;
                        break;
                    }
                }
            }));

            string result = String.Empty;
            for (int i = 0; i < cryptInfo.Message.Length; i++)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).Progress.Value = i;
                        }
                    }
                }));
                result += (char)(cryptInfo.Message[i] ^ cryptInfo.Key);
            }

            File.WriteAllText(Directory.GetCurrentDirectory() + @"\result_encrypt.txt", result);
        }

        // XOR Decrypt
        public static void Decrypt(object obj)
        {
            CryptInfo cryptInfo = obj as CryptInfo;

            if (cryptInfo == null)
            {
                MessageBox.Show("CryptInfo is equeal null.");
                return;
            }

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).Progress.Maximum = cryptInfo.Message.Length;
                        break;
                    }
                }
            }));

            string result = String.Empty;
            for (int i = 0; i < cryptInfo.Message.Length; i++)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).Progress.Value = i;
                        }
                    }
                }));
                result += (char)(cryptInfo.Message[i] ^ cryptInfo.Key);
            }

            File.WriteAllText(Directory.GetCurrentDirectory() + @"\result_decrypt.txt", result);
        }
    }
}
