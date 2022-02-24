using Microsoft.Win32;
using System;
using System.Linq;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Processes.Multithreads.HW
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Crypt crypt = new Crypt();
        public Thread thread = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.LWin || e.Key ==  Key.RWin)
            {
                btnStart_Click(null, null);
            }
        }

        private void SerializeCrypt(string type)
        {
            string json = JsonConvert.SerializeObject(crypt);
            File.WriteAllText(Directory.GetCurrentDirectory() + $"\\CryptInfo_{type}.json", json);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (crypt.FullPath != null && File.Exists(crypt.FullPath))
            {
                if (Path.Text.Contains("json") || Path.Text.Contains("txt"))
                {
                    if (crypt.Password == null)
                    {
                        MessageBox.Show("Password isn't set.");
                        return;
                    }

                    if (crypt.CryptType == null)
                    {
                        MessageBox.Show("Crypt type isn't set.");
                        return;
                    }

                    if (crypt.CryptType == true)
                    {
                        thread = new Thread(Crypt.Encrypt);
                        thread.IsBackground = true;
                        crypt.MessagePath = Directory.GetCurrentDirectory() + @"\result_encrypt.txt";
                        thread.Start(new CryptInfo(File.ReadAllText(Path.Text), ulong.Parse(Passwd.Text)));
                        SerializeCrypt("Encrypt");
                    }
                    else
                    {
                        thread = new Thread(Crypt.Decrypt);
                        thread.IsBackground = true;
                        crypt.MessagePath = Directory.GetCurrentDirectory() + @"\result_decrypt.txt";
                        thread.Start(new CryptInfo(File.ReadAllText(Path.Text), ulong.Parse(Passwd.Text)));
                        SerializeCrypt("Decrypt");
                    }

                    MessageBox.Show("Done");
                    Path.Text = null;
                    Progress.Maximum = 1;
                    Progress.Value = 0;
                    IsDecrypt.IsChecked = false;
                    IsEncrypt.IsChecked = false;
                    Passwd.Text = null;
                }
                else
                {
                    Path.Text = null;
                    MessageBox.Show("Boom! Only txt and json files you may use.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Boom! Only txt and json files you may use.");
            }
        }

        private void FileSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt|Json files (*.json)|*.json";
            dialog.InitialDirectory = @"C:\";

            if (dialog.ShowDialog() == true)
            {
                string tmp = null;
                foreach (char item in dialog.FileName.Reverse())
                {
                    tmp += item;

                    if (tmp == "nosj")
                    {
                        string json = File.ReadAllText(dialog.FileName);
                        Crypt tmpCrypt = JsonConvert.DeserializeObject<Crypt>(json);
                        Path.Text = tmpCrypt.MessagePath;
                        Passwd.Text = Convert.ToString(tmpCrypt.Password);

                        if (tmpCrypt.CryptType == false)
                        {
                            IsEncrypt.IsChecked = true;
                        }
                        else
                        {
                            IsDecrypt.IsChecked = true;
                        }

                        crypt.Password = tmpCrypt.Password;
                        crypt.FullPath = tmpCrypt.MessagePath;

                        return;
                    }
                }

                crypt.FullPath = dialog.FileName;
                Path.Text = crypt.FullPath;
            }
        }

        private void Passwd_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Passwd.Text == null)
            {
                return;
            }

            if (Passwd.Text.Length == 15)
            {
                crypt.Password = ulong.Parse(Passwd.Text);
                return;
            }
            else if (Passwd.Text.Length > 15)
            {
                Passwd.Text = Convert.ToString(crypt.Password);
                return;
            }

            if (!ulong.TryParse(Passwd.Text, out ulong result))
            {
                Passwd.Text = null;
                return;
            }

            crypt.Password = ulong.Parse(Passwd.Text);
        }

        private void IsEncrypt_Checked(object sender, RoutedEventArgs e)
        {
            if (IsEncrypt.IsChecked == true)
            {
                crypt.CryptType = true;
            }
        }

        private void IsDecrypt_Checked(object sender, RoutedEventArgs e)
        {
            if (IsDecrypt.IsChecked == true)
            {
                crypt.CryptType = false;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (thread == null)
            {
                MessageBox.Show("Thread is not alive.");
                return;
            }

            if (!thread.IsAlive)
            {
                MessageBox.Show("Thread is not alive.");
                return;
            }

            if (thread.IsAlive)
            {
                thread.Abort();
                MessageBox.Show("Abort");
                Path.Text = null;
                Progress.Maximum = 1;
                Progress.Value = 0;
                IsDecrypt.IsChecked = false;
                IsEncrypt.IsChecked = false;
                Passwd.Text = null;
            }
        }

        private void Path_TextChanged(object sender, TextChangedEventArgs e)
        {
            crypt.FullPath = Path.Text;
        }
    }
}
