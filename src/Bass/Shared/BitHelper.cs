// Adopted from http://www.codeproject.com/Articles/12919/C-Bitwise-Helper-Class

namespace ManagedBass
{
    /// <summary>
    /// Helps perform certain operations on primative types that deal with bits
    /// </summary>
    public static class BitHelper
    {
        /// <summary>
        /// The return value is the high-order double word of the specified value.
        /// </summary>
        public static int HiDword(this long DWord) => (int)((DWord >> 32) & 0xFFFFFFFF);

        /// <summary>
        /// The return value is the low-order word of the specified value.
        /// </summary>
        public static int LoDword(this long DWord) => (int)DWord;

        /// <summary>
        /// The return value is the high-order word of the specified value.
        /// </summary>
        public static short HiWord(this int DWord) => (short)((DWord >> 16) & 0xFFFF);

        /// <summary>
        /// The return value is the low-order word of the specified value.
        /// </summary>
        public static short LoWord(this int DWord) => (short)DWord;

        /// <summary>
        /// The return value is the high-order byte of the specified value.
        /// </summary>
        public static byte HiByte(this short Word) => (byte)((Word >> 8) & 0xFF);

        /// <summary>
        /// The return value is the low-order byte of the specified value.
        /// </summary>
        public static byte LoByte(this short Word) => (byte)Word;

        /// <summary>
        /// Make an short from 2-bytes.
        /// </summary>
        public static short MakeWord(byte Low, byte High) => (short)(Low | (ushort)(High << 8));

        /// <summary>
        /// Make an integer putting <paramref name="Low"/> in low 2-bytes and <paramref name="High"/> in high 2-bytes.
        /// </summary>
        public static int MakeLong(short Low, short High) => (int)((ushort)Low | (uint)(High << 16));
    }
}
