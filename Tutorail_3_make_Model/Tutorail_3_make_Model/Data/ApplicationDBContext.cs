using Microsoft.EntityFrameworkCore;
using Tutorail_3_make_Model.Models;

namespace Tutorail_3_make_Model.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        // -------- แทน Model Web นำไปสร้างฐานข้อมูลทั้ชื่อ Web ---------
        public DbSet<Web> Webs { get; set; }
    }
}

