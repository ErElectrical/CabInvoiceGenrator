using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenrator
{
    public class RideRepository
    {
        //Dictionary to store Userid and Rides list
        Dictionary<string, List<Ride>> Userrides = null;


        /// <summary>
        /// non parametrised constructor for initialise Dictionary
        /// </summary>
        public RideRepository()
        {
            this.Userrides=new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Method to add Ride list to specifies userid
        /// as according to our requirement user can have multiple rides also
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="rides"></param>
        public void AddRides(string userid,Ride[] rides)
        {
            bool ridelist = this.Userrides.ContainsKey(userid);
            try
            {
                if(!ridelist)
                {
                    List<Ride> list=new List<Ride>();
                    list.AddRange(rides);
                    this.Userrides.Add(userid, list);
                }
            }
            catch(CabInvoiceCustomException)
            {
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Null_Ride, "Ride Can not be Null");
            }
        }


        /// <summary>
        /// Function to get information from a specified userid to array
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceCustomException"></exception>
        public Ride[] GetRides(string userid)
        {
            try
            {
                return this.Userrides[userid].ToArray();
            }
            catch(Exception)
            {
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.Invalid_User_Id, "Invalid UserId");
            }
        }
    }
}
