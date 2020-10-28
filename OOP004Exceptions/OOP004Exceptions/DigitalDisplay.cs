namespace OOP004Exceptions
{
    class DigitalDisplay
    {
        private int[] DisplayNumbers { get; set; } = new int[4];
        public int GetDigit(int i)
        {
            if (i > 4) throw new NoSuchDigitException();
            else return DisplayNumbers[i - 1];
        }
        public void SetDigit(int i, int v)
        {
            if (i > 4) throw new NoSuchDigitException();
            else if (v < 0 || v > 9) throw new IllegalDigitException();
            else DisplayNumbers[i - 1] = v;
        }

    }
}

