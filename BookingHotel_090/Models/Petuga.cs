using System;
using System.Collections.Generic;

#nullable disable

namespace BookingHotel_090.Models
{
    public partial class Petuga
    {
        public Petuga()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdPetugas { get; set; }
        public string NamaPetugas { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
