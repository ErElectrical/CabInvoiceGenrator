using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenrator
{
    /// <summary>
    /// Ride class is responsible for set data for a Particular ride
    /// </summary>
    public  class Ride 
    {

        //field Varible
        public double distance;
        public int time;

        /// <summary>
        /// Paramatrised constructor insitalise the field Varible
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Ride(double distance,int time )
        {
            this.distance = distance;
            this.time= time;
        }

    }
}
