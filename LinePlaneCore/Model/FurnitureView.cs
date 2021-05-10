using System.Windows.Media.Imaging;

namespace LinePlaneCore.Model
{
    internal class FurnitureView
    {
        protected int _amount = 0;
        internal int amount { get => _amount; set => _amount = value; }

        //internal BitmapImage FurniyureImage { get; set; }
        internal string nameFurniture { get; set; }
        internal string furnitureURI { get; set; }

        private int _price = 0;
        internal int price { get => _price; set=>_price=_amount*value; }
    }
}
