using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenrator
{
    public class CabInvoiceCustomException:Exception
    {
        /// <summary>
        /// Enum for Exception Type for Cab Invoice Application
        /// </summary>
        public enum ExceptionType
        {
            Invalid_Ride_Type,
            Invalid_Distance,
            Invalid_Rides,
            Invalid_User_Id
        }

        ExceptionType type;

        /// <summary>
        /// constructor of class 
        /// initialise the type of enum customException
        /// </summary>
        /// <param name="type"></param>
        /// <param name="msg"></param>
        public CabInvoiceCustomException(ExceptionType type,string msg):base(msg)
        {
            this.type = type;
        }

    }
}
