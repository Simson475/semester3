using System;

namespace CodeWars_Test
{
    ///
    internal class ArrayToNumberConverter
    {
        /// <summary>
        /// Converts an array of binary to its number representation
        /// </summary>
        /// <param name="BinaryArray"></param>
        /// <returns> 
        /// The value that was represented in binary
        /// </returns>
        public static int binaryArrayToNumber(int[] BinaryArray)
        {

            int binaryValue = 0;
            int positionValue = 1;
            for (int i = BinaryArray.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(BinaryArray[i]);
                if (BinaryArray[i] == 1) binaryValue += positionValue;
                positionValue *= 2;
            }
            return binaryValue;
        }
    }

}
