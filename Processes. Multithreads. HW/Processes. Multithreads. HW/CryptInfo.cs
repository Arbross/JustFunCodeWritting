using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processes.Multithreads.HW
{
    public class CryptInfo
    {
        // Ctor - default
        public CryptInfo() {}

        // Ctor - fill type
        public CryptInfo(string message, ulong key)
        {
            Message = message;
            Key = key;
        }

        // File text to encrypt and decrypt
        public string Message { get; set; }

        // Key to convert text
        public ulong? Key { get; set; }
    }
}
