using System;
using System.Security.Cryptography;

namespace SDB.Core
{
    /// <summary>Aleatoriedade segura. No jogo final, o servidor é quem sorteia (ver ADR-0004); isto serve o modo offline de desenvolvimento.</summary>
    public static class CryptoRng
    {
        public static double NextDouble()
        {
            Span<byte> b = stackalloc byte[8];
            RandomNumberGenerator.Fill(b);
            ulong v = BitConverter.ToUInt64(b) >> 11;
            return v / (double)(1UL << 53);
        }
    }
}
