using System.Windows.Media.Imaging;

namespace LinePlaneCore.Model
{
    internal class FurnitureView
    {
        protected int _Amount = 0;
        public int Amount { get => _Amount; set => _Amount = value; }

        //internal BitmapImage FurniyureImage { get; set; }
        public string NameFurniture { get; set; }
        public string FurnitureURI { get; set; }

        private int _Price = 0;
        public int Price { get => _Price; set=> _Price = _Amount * value; }
    }
}
