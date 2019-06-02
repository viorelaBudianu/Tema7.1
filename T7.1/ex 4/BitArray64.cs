using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

//Define a class BitArray64 to hold 64 bit values inside an ulong value.

//Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=

namespace ex_4
{
    public class BitArray64:IEnumerable<ulong>
    {
        private ulong bits;

        public BitArray64()
        {
        }

        public ulong Bits
        {
            get { return this.bits; }

            set
            {
                this.bits = value;
            }
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= 64)
                {
                    throw new ArgumentOutOfRangeException("The index is out of range [0-63]");
                }
                return (byte)((this.bits >> index) & 1);
            }
            set
            {
                if (index < 0 || index >= 64)
                {
                    throw new ArgumentOutOfRangeException("The index is out of range [0-63]");
                }
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("It should be 1 or 0");
                }
                if (((int)(this.bits >> index) & 1) != value)
                {
                    this.bits ^= (1ul << index);
                }
            }
        }

        public override bool Equals(object obj)
        {
            var otherBitArray = obj as BitArray64;
            return this.bits.Equals(otherBitArray.bits);
        }


        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }
        public IEnumerator<ulong> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator<ulong> IEnumerable<ulong>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.bits.GetHashCode();
        }

        // Print the binary number
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int index = 0; index < 64; index++)
            {
                result.Insert(0, ((this.bits >> index) & 1));
            }

            return result.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
