using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class BeamImageEventArgs: EventArgs
    {
        Bitmap image;
        DateTime timeGenerated;


        public Bitmap BeamImage 
        {
            get { return image; }
            set 
            { 
                image = value;
                timeGenerated = DateTime.Now;
            }
            
        }
        public DateTime TimeGenerated 
        {
            get { return timeGenerated; }
        }

    }
}
