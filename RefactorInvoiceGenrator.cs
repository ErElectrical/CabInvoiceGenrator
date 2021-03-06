using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenrator
{
    public class RefactorInvoiceGenrator
    {
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
        public RefactorInvoiceGenrator(RideType ridetype)
        {
            this.ridetype = ridetype;
            this.riderepository = new RideRepository();
            try
            {
                //if RideType is normal and Premimum set rate respectively
                if (ridetype.Equals(RideType.Normal))
                {
                    this.Minimum_Fare = 5;
                    this.Cost_Per_Time = 1;
                    this.Minimum_Cost_Per_Km = 10;
                }
                else if (ridetype.Equals(RideType.Premium))
                {
                    this.Minimum_Fare = 20;
                    this.Cost_Per_Time = 2;
                    this.Minimum_Cost_Per_Km = 15;
                }
            }
            catch (CabInvoiceCustomException)
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
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * Minimum_Cost_Per_Km + time * Cost_Per_Time;

            }
            catch (CabInvoiceCustomException)
            {
                if (ridetype.Equals(null))
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Invalid_Ride_Type, "Invalid Ride Type");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Invalid_Distance, "Invalid distance entered");
                }
                if (time < 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Invalid_Time, "Invalid Time Entered");
                }
            }
            return Math.Max(totalFare, Minimum_Fare);
        }

        /// <summary>
        /// Function calculate fare for each ride 
        /// return type of the function is InvoiceSummary type 
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceCustomException"></exception>
        public InvoiceSummary calculateFare(Ride[] rides)
        {
            double totalfare = 0;
            try
            {
                foreach(Ride ride in rides)
                {
                    totalfare = this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch(CabInvoiceCustomException)
            {
                if(rides == null)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Null_Ride, "Ride Can not be null");

                }
            }
            return new InvoiceSummary(rides.Length, totalfare);
        }

        /// <summary>
        /// Method is responsible for add multiple rides to the ride repository 
        /// riderepository contains a dictionary in which we store data according to userid
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="rides"></param>
        /// <exception cref="CabInvoiceCustomException"></exception>
        public void AddRides(string userid,Ride[] rides)
        {
            try
            {
                riderepository.AddRides(userid, rides);
            }
            catch(CabInvoiceCustomException)
            {
                if(rides == null)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Null_Ride, "Ride can not be null");
                }
            }
        }

        /// <summary>
        /// Method to getInvoiceSummary based on userid
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceCustomException"></exception>

        public InvoiceSummary GetInvoiceSummary(string userid)
        {
            try
            {
                return this.calculateFare(riderepository.GetRides(userid));
            }
            catch(CabInvoiceCustomException)
            {
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Invalid_User_Id, "correct user id is not entered");
            }
        }

    }
}
