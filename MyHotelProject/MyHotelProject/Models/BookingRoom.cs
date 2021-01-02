using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelProject.Models
{
    [Serializable]
    public class BookingRoom
    {
        public RoomTypeBook RoomTypeBook { set; get; }
        public DateTime CheckinDate { set; get; }
        public DateTime CheckoutDate { set; get; }
        public int Adult { set; get; }
        public int Children { set; get; }
        public int Quantity { set; get; }
    }
}