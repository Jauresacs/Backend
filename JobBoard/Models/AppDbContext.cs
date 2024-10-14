using Microsoft.EntityFrameworkCore;
using JobBoard.Models;

namespace JobBoard.Models
{
    public class JobBoardContext : DbContext
    {
        public JobBoardContext(DbContextOptions<JobBoardContext> options)
          : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Recruteur> Recruteurs { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<Candidature> Candidatures { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skills> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Data Seed: Entreprises
            modelBuilder.Entity<Entreprise>().HasData(
                new Entreprise { Id = 1, Name = "TechCorp", Description = "Tech solutions company", SiteWeb = "https://techcorp.com", Adresse = "123 Tech Street" },
                new Entreprise { Id = 2, Name = "HealthPlus", Description = "Healthcare services provider", SiteWeb = "https://healthplus.com", Adresse = "456 Health Avenue" },
                new Entreprise { Id = 3, Name = "FinSolutions", Description = "Financial consulting firm", SiteWeb = "https://finsolutions.com", Adresse = "789 Finance Blvd" },
                new Entreprise { Id = 4, Name = "EduLearn", Description = "Educational platform", SiteWeb = "https://edulearn.com", Adresse = "101 Learning Way" },
                new Entreprise { Id = 5, Name = "GreenEnergy", Description = "Renewable energy provider", SiteWeb = "https://greenenergy.com", Adresse = "202 Solar Street" }
            );

            // Data Seed: Users (Recruteurs)
            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Nom = "Alice Johnson", Role = "Recruteur", Email = "alice@techcorp.com", PasswordHash = "hashedpassword1", DateInscription = DateTime.Now },
            new User { Id = 2, Nom = "Bob Smith", Role = "Recruteur", Email = "bob@healthplus.com", PasswordHash = "hashedpassword2", DateInscription = DateTime.Now },
            new User { Id = 3, Nom = "Carol White", Role = "Recruteur", Email = "carol@finsolutions.com", PasswordHash = "hashedpassword3", DateInscription = DateTime.Now },
            new User { Id = 4, Nom = "David Brown", Role = "Recruteur", Email = "david@edulearn.com", PasswordHash = "hashedpassword4", DateInscription = DateTime.Now },
            new User { Id = 5, Nom = "Emma Green", Role = "Recruteur", Email = "emma@greenenergy.com", PasswordHash = "hashedpassword5", DateInscription = DateTime.Now }
            );

            // Data Seed: Recruteurs
            modelBuilder.Entity<Recruteur>().HasData(
            new Recruteur { Id = 1, UserId = 1, EntrepriseId = 1, Role = "HR Manager" },
            new Recruteur { Id = 2, UserId = 2, EntrepriseId = 2, Role = "HR Specialist" },
            new Recruteur { Id = 3, UserId = 3, EntrepriseId = 3, Role = "HR Director" },
            new Recruteur { Id = 4, UserId = 4, EntrepriseId = 4, Role = "HR Consultant" },
            new Recruteur { Id = 5, UserId = 5, EntrepriseId = 5, Role = "HR Executive" }
            );

            // Data Seed: Jobs
            modelBuilder.Entity<Job>().HasData(
                // Jobs for Alice (Recruteur 1)
                new Job { Id = 1, Title = "Software Developer", Description = "Develop software applications", CompanyName = "TechCorp", JobType = "Full-Time", Location = "Remote", Salary = 60000, PostedDate = DateTime.Now, RecruteurId = 1, Status = "Active", Category = "Technology" },
                new Job { Id = 2, Title = "UI/UX Designer", Description = "Design user interfaces", CompanyName = "TechCorp", JobType = "Full-Time", Location = "San Francisco", Salary = 55000, PostedDate = DateTime.Now, RecruteurId = 1, Status = "Active", Category = "Design" },

                // Jobs for Bob (Recruteur 2)
                new Job { Id = 3, Title = "Data Analyst", Description = "Analyze healthcare data", CompanyName = "HealthPlus", JobType = "Part-Time", Location = "New York", Salary = 40000, PostedDate = DateTime.Now, RecruteurId = 2, Status = "Active", Category = "Healthcare" },
                new Job { Id = 4, Title = "Healthcare Consultant", Description = "Provide healthcare consulting services", CompanyName = "HealthPlus", JobType = "Contract", Location = "New York", Salary = 65000, PostedDate = DateTime.Now, RecruteurId = 2, Status = "Active", Category = "Consulting" },

                // Jobs for Carol (Recruteur 3)
                new Job { Id = 5, Title = "Financial Analyst", Description = "Analyze financial data", CompanyName = "FinSolutions", JobType = "Full-Time", Location = "Chicago", Salary = 70000, PostedDate = DateTime.Now, RecruteurId = 3, Status = "Active", Category = "Finance" },
                new Job { Id = 6, Title = "Accountant", Description = "Manage financial records", CompanyName = "FinSolutions", JobType = "Full-Time", Location = "New York", Salary = 60000, PostedDate = DateTime.Now, RecruteurId = 3, Status = "Active", Category = "Finance" },

                // Jobs for David (Recruteur 4)
                new Job { Id = 7, Title = "Instructional Designer", Description = "Design educational content", CompanyName = "EduLearn", JobType = "Contract", Location = "Remote", Salary = 50000, PostedDate = DateTime.Now, RecruteurId = 4, Status = "Active", Category = "Education" },
                new Job { Id = 8, Title = "Education Consultant", Description = "Consulting for educational platforms", CompanyName = "EduLearn", JobType = "Full-Time", Location = "Remote", Salary = 60000, PostedDate = DateTime.Now, RecruteurId = 4, Status = "Active", Category = "Consulting" },

                // Jobs for Emma (Recruteur 5)
                new Job { Id = 9, Title = "Renewable Energy Engineer", Description = "Design renewable energy systems", CompanyName = "GreenEnergy", JobType = "Full-Time", Location = "Los Angeles", Salary = 75000, PostedDate = DateTime.Now, RecruteurId = 5, Status = "Active", Category = "Energy" },
                new Job { Id = 10, Title = "Environmental Scientist", Description = "Study environmental impacts", CompanyName = "GreenEnergy", JobType = "Full-Time", Location = "Denver", Salary = 65000, PostedDate = DateTime.Now, RecruteurId = 5, Status = "Active", Category = "Science" },

                // Additional Jobs for other recruteurs (distribute more jobs)
                new Job { Id = 11, Title = "Marketing Specialist", Description = "Plan and execute marketing campaigns", CompanyName = "TechCorp", JobType = "Full-Time", Location = "Remote", Salary = 50000, PostedDate = DateTime.Now, RecruteurId = 1, Status = "Active", Category = "Marketing" },
                new Job { Id = 12, Title = "Project Manager", Description = "Manage IT projects", CompanyName = "TechCorp", JobType = "Contract", Location = "Remote", Salary = 70000, PostedDate = DateTime.Now, RecruteurId = 1, Status = "Active", Category = "Management" },
                new Job { Id = 13, Title = "Sales Representative", Description = "Sell healthcare services", CompanyName = "HealthPlus", JobType = "Full-Time", Location = "Chicago", Salary = 45000, PostedDate = DateTime.Now, RecruteurId = 2, Status = "Active", Category = "Sales" },
                new Job { Id = 14, Title = "Network Engineer", Description = "Maintain network infrastructure", CompanyName = "TechCorp", JobType = "Full-Time", Location = "Dallas", Salary = 65000, PostedDate = DateTime.Now, RecruteurId = 1, Status = "Active", Category = "Technology" },
                new Job { Id = 15, Title = "Content Writer", Description = "Write content for websites and blogs", CompanyName = "TechCorp", JobType = "Contract", Location = "Remote", Salary = 40000, PostedDate = DateTime.Now, RecruteurId = 1, Status = "Active", Category = "Content Writing" }
            );


            // Relation un-à-un entre User et Candidat
            modelBuilder.Entity<User>()
                .HasOne(u => u.Candidat)
                .WithOne(c => c.User)
                .HasForeignKey<Candidat>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Education>()
                .HasOne(e => e.Candidat)
                .WithMany(c => c.Educations)
                .HasForeignKey(e => e.CandidatId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation un-à-un entre User et Recruteur
            modelBuilder.Entity<User>()
                .HasOne(u => u.Recruteur)
                .WithOne(r => r.User)
                .HasForeignKey<Recruteur>(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation un-à-plusieurs : Entreprise -> Recruteurs
            modelBuilder.Entity<Recruteur>()
                .HasOne(r => r.Entreprise)
                .WithMany(e => e.Recruteurs)
                .HasForeignKey(r => r.EntrepriseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relation un-à-plusieurs : Candidat -> Experiences
            modelBuilder.Entity<Experience>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation un-à-plusieurs : Candidat -> Candidatures
            modelBuilder.Entity<Candidature>()
                .HasOne<Candidat>()
                .WithMany(c => c.Candidatures)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation un-à-plusieurs : Recruteur -> Jobs
            modelBuilder.Entity<Job>()
                .HasOne<Recruteur>()
                .WithMany(r => r.Jobs)
                .HasForeignKey(j => j.RecruteurId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation un-à-plusieurs : Skills -> User (Candidat)
            modelBuilder.Entity<Skills>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation un-à-plusieurs : Candidature -> Job
            modelBuilder.Entity<Candidature>()
                .HasOne<Job>()
                .WithMany()
                .HasForeignKey(c => c.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}