using System;
using System.Collections.Generic;

#nullable disable

namespace BookingHotel_090.Models
{
    public partial class Room
    {
        public Room()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdRoom { get; set; }
        public string TypeRoom { get; set; }
        public string NamaRoom { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
