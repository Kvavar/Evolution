using Client.Ui.Model;
using Client.Agents;

namespace Client.Ui.ViewModel
{
    class LivingAreaViewModel
    {
        private LivingAreaModel _livingAreaModel;
        private readonly LivingAreaAgent _livingAreaAgent;

        public LivingAreaViewModel(LivingAreaAgent livingAreaAgent)
        {
            _livingAreaAgent = livingAreaAgent;
        }

        private void RecalculateArea()
        {
            foreach(bool cell in _livingAreaModel.Cells)
            {

            }
        }
    }
}
