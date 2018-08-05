namespace Client.Ui.Model
{
    internal class LivingAreaModel
    {
        public LivingAreaModel(bool[,] cells)
        {
            Cells = cells;
        }

        public bool[,] Cells { get; }
    }
}
