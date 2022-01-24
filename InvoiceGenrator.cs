using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenrator
{
    public class InvoiceGenrator
    {

        //varible

        public enum RideType { Normal, Premium }


        RideType ridetype;

        private RideRepository riderepository;

        //constant
        private readonly double Minimum_Cost_Per_Km;
        private readonly int Cost_Per_Time;
        private readonly double Minimum_Fare;


        /// <summary>
        /// Paramaterised Constructor To initilaise RideType
        /// </summary>
        /// <param name="ridetype"></param>
        public InvoiceGenrator(RideType ridetype)
        {
            this.ridetype = ridetype;
            this.riderepository = new RideRepository();
            try
            {
                //if RideType is normal and Premimum set rate respectively
                if(ridetype.Equals(RideType.Normal))
                {
                    this.Minimum_Fare = 5;
                    this.Cost_Per_Time = 1;
                    this.Minimum_Cost_Per_Km = 10;
                }
                else if(ridetype.Equals(RideType.Premium))
                {
                    this.Minimum_Fare = 20;
                    this.Cost_Per_Time = 2;
                    this.Minimum_Cost_Per_Km = 15;
                }
            }
            catch(CabInvoiceCustomException)
            {

                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Invalid_Ride_Type, "Invalid Ride Type");
            }
        }
        /// <summary>
        /// Method is responsible for calculate fare per ride
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance,int time )
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * Minimum_Cost_Per_Km + time * Cost_Per_Time;

            }
            catch(CabInvoiceCustomException)
            {
                if(ridetype.Equals(null))
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Invalid_Ride_Type, "Invalid Ride Type");
                }
                if(distance <= 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Invalid_Distance, "Invalid distance entered");
                }
                if(time < 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Invalid_Time, "Invalid Time Entered");
                }
            }
            return Math.Max(totalFare, Minimum_Fare);
        }


    }
}
