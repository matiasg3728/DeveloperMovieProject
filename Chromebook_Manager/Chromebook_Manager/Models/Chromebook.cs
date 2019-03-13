using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chromebook_Manager.Models
{
    public class Chromebook
    {
        public int ChromebookId { get; set; }
        public int CommunityId { get; set; }
        /*
        This order ID will be relevent going forward with all new chromebook orders. The idea is that once we have all the current 
        chrombooks input into this site we will begin adding in chromebooks through orders. When a client orders a new chromebook an order
        will be created for every chromebook within their order (Client orders 3 CBs we make 3 order rows). Once the chromebooks arive in office
        the CB ID is entered into the Order and then the system creates a new chromebook row with the ID.
        */
        public int OrderID { get; set; }


        /*
         * The idea for the status code is it will represent if the CB is refurbished or not, the type of Chromebook, and where the chromebook
         * is. EX: R-101p-IH
         * 
         * (Refurbished or New)-(Chromebook Type)-(In house, Broken, On-site)
         * 
         * Im not sure if this is a good way to do it or if I should just have a bunch of collumns. I will try this then speak with Hozi for some
         * insight into what he thinks when I have a good working example
        */
        public string StatusCode { get; set; }
        public DateTime EnrollmentDate { get; set; }

       


    }
}
