using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore
{
    class Furniture

    {
        public int Id { get; set; }

        private string _Picture, _Link;
        private int _Price;
        private double _Length, _Width;

        public string Picture
        {
            get { return _Picture; }
            set { _Picture = value; }
        }

        public string Link
        {
            get { return _Link; }
            set { _Link = value; }
        }

        public int Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public double Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        public double Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        public Furniture() { }

        public Furniture(string Picture, string Link, int Price, double Lenth, double Width)
        {
            _Picture = Picture;
            _Link = Link;
            _Price = Price;
            _Length = Lenth;
            _Width = Width;
        }

    }
}