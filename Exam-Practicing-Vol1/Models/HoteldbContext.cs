using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Exam_Practicing_Vol1.Models
{
    public partial class HoteldbContext : DbContext
    {
        public HoteldbContext()
            : base("name=HoteldbContext")
        {
        }

        public DbSet<GuestModel> GuestsTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
