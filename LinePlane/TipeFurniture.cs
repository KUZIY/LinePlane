using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlane
{ 
class TipeFurniture

{
    public int Id { get; set; }

        private string _TipeFurniture;
        public int _IdFurniture;

    public string TipeofFurniture
        {
        get { return _TipeFurniture; }
        set { _TipeFurniture = value; }
    }

    public int IdFurniture
        {
        get { return _IdFurniture; }
        set { _IdFurniture = value; }
    }

    public TipeFurniture() { }

        public TipeFurniture(string TipeFurniture, int IdFurniture)
        {
            _TipeFurniture = TipeFurniture;
            _IdFurniture = IdFurniture;
        }

}
}
