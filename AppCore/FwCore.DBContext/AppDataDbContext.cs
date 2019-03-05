using FwCore.DBContext.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace FwCore.DBContext
{
    public class AppDataDbContext : DbContext
    {
        public AppDataDbContext(DbContextOptions<AppDataDbContext> Options) : base(Options) { }

        // All DbSet...
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Granter> Granters { get; set; }
        public DbSet<Document> Documents { get; set; }
        
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanInstallment> LoanInstallments { get; set; }
        
       
       
        public DbSet<VerificationSource> VerificationSources { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }


    }

}
