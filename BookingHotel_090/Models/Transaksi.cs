using System;
using System.Collections.Generic;

#nullable disable

namespace BookingHotel_090.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int IdCustomer { get; set; }
        public int IdPetugas { get; set; }
        public int IdRoom { get; set; }
        public string TotalTransaksi { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Petuga IdPetugasNavigation { get; set; }
        public virtual Room IdRoomNavigation { get; set; }
    }
}
