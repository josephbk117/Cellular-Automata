namespace CellularAutomata
{
    class Row
    {
        public byte[] CA;

        public Row(byte[] content)
        {
            CA = new byte[content.Length];
            CA = content;
        }
    }
}
