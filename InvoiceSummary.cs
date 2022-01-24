using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenrator
{
    public class InvoiceSummary
    {
        private int numberOfRides;
        private double TotalFare;
        private double avergeFare;

        public InvoiceSummary(int numberOfRides,double TotalFare)
        {
            this.numberOfRides = numberOfRides;
            this.TotalFare = TotalFare;
            this.avergeFare = this.TotalFare / this.numberOfRides;
        }

        /// <summary>
        /// Override equals method 
        /// equals method check for expected and getting data is same or not
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if(! (obj is InvoiceSummary)) return false;

            InvoiceSummary inputObject=(InvoiceSummary)obj;
            return this.numberOfRides == inputObject.numberOfRides && this.TotalFare == inputObject.TotalFare && this.avergeFare == inputObject.avergeFare;

        }

        public override int GetHashCode()
        {
            //A hash code is a numeric value which is used to insert and identify an object
            //in a hash-based collection.
            //The GetHashCode method provides this hash code for algorithms
            //that need quick checks of object equality.
            //Syntax: public virtual int GetHashCode ();
            //hash based Collection is nothing but dictionary
            return this.numberOfRides.GetHashCode() ^ this.TotalFare.GetHashCode() ^ this.avergeFare.GetHashCode();

        }
    }
}
