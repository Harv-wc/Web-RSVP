using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_7D.Models
{

    public class Repository : DbContext
    {
        public DbSet<GuestResponse> GuestResponses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opts)
        {
            opts.UseSqlServer("server=(localdb)\\MSSQLLocalDB; Database=RSVPDatabase; Trusted_Connection=true;");
        }
        
    }
    /*
     public static class Repository
    {
        public static List<GuestResponse> responses = new List<GuestResponse>();

        public static IEnumerable<GuestResponse> Responses
        {
            get
            {
                return responses;
            }
        }

        public static void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
     */
}
