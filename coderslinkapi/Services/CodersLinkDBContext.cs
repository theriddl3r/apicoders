using coderslinkapi.Data;
using Microsoft.EntityFrameworkCore;
namespace coderslinkapi.Services
{
public class CodersLinkDBContext : DbContext
{
    //define a basic dbcontext
     public CodersLinkDBContext()
        {
        }
    public CodersLinkDBContext(DbContextOptions<CodersLinkDBContext> options)
        : base(options) { }

    public DbSet<Register> Register { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>(entity =>
            {
              entity.HasKey(e => e.Email)
                    .HasName("mail_pkey");
                 

            
            });

        }
         
}
}