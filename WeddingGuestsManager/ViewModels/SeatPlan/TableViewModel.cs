namespace WeddingGuestsManager.ViewModels.SeatPlan
{
    public class TableViewModel : ViewModelBase
    {
        private int _tableNumber;
        private int _canvasX;
        private int _canvasY;
        private static int _numberOfTablesInARow = 8;
        private static int _topTableLeftX = 100;
        private static int _topTableLeftY = 150;
        public int TableHeight { get => 50; }
        public int TableWidth { get => 100; }
       
        public int CanvasX
        {
            get => _canvasX;
            set
            {
                _canvasX = value;
                OnPropertyChanged();
            }
        }
        public int CanvasY
        {
            get => _canvasY;
            set
            {
                _canvasY = value;
                OnPropertyChanged();
            }
        }

        public TableViewModel(int tableNumber)
        {
            _tableNumber = tableNumber;
            CanvasX = tableNumber > _numberOfTablesInARow ? _topTableLeftX + ((tableNumber - _numberOfTablesInARow - 1) * TableWidth) : _topTableLeftX + ((tableNumber - 1) * TableWidth);
            CanvasY = tableNumber > _numberOfTablesInARow ? _topTableLeftY + TableHeight : _topTableLeftY;
        }
    }
}
