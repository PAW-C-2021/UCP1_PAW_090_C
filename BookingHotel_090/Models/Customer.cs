using System;
using System.Collections.Generic;

#nullable disable

namespace BookingHotel_090.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string JenisKelamin { get; set; }
        public string NoHp { get; set; }
        public int? Umur { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
