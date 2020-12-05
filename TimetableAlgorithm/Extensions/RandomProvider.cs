using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TimetableAlgorithm
{
    internal static class RandomProvider
    {
        public static int GetRndValue(uint from, uint to)
        {
            uint val = 0;
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                val = from + (uint)BitConverter.ToInt32(rno, 0) % to;
            }
            return (int)val;
        }
    }
}
