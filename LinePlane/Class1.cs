using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlane
{
    class Wall
    {
        private decimal _x_start_point;
        private decimal _y_start_point;

        private decimal _x_end_point;
        private decimal _y_end_point;

        #region seters/geters
        public decimal x_start
        {
            get { return _x_start_point; }
            set { _x_start_point = value; }
        }

        public decimal y_start
        {
            get { return _y_start_point; }
            set { _y_start_point = value; }
        }

        public decimal x_end
        {
            get { return _x_end_point; }
            set { _x_end_point = value; }
        }

        public decimal y_end
        {
            get { return _y_end_point; }
            set { _y_end_point = value; }
        }

        #endregion


    }
}
