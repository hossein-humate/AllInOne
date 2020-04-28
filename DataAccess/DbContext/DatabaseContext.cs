using Microsoft.EntityFrameworkCore;
using Model.Entity.AllInOne;
using Model.Entity.Application;
using Model.Entity.BaseInfo;
using Model.Entity.Blog;
using Model.Entity.ClientApi;
using Model.Entity.Finance;
using Model.Entity.Identity;

namespace DataAccess.DbContext
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //"Password=1;Persist Security Info=True;User ID=sa;Initial Catalog=WorkShop;Data Source=."
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions)
            : base(dbContextOptions)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public static DatabaseContext Create(string connection)
        {
            return new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>()
                .UseLazyLoadingProxies(false)
                .UseSqlServer(connection).Options);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies(false)
        //        .UseSqlServer(
        //            "Password=1;Persist Security Info=True;User ID=sa;Initial Catalog=AllInOne;Data Source=.;MultipleActiveResultSets=True");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User Relations
            modelBuilder.Entity<User>()
                   .HasMany(u => u.Addresses)
                   .WithOne(a => a.User)
                   .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Emails)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Phones)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserSoftwares)
                .WithOne(us => us.User)
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Person)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.PersonId);

            #endregion

            #region Person Relations
            modelBuilder.Entity<Person>()
                .HasMany(u => u.Users)
                .WithOne(u => u.Person)
                .HasForeignKey(u => u.PersonId);
            #endregion

            #region Software Relations
            modelBuilder.Entity<Software>()
                .HasMany(u => u.UserSoftwares)
                .WithOne(us => us.Software)
                .HasForeignKey(us => us.SoftwareId);
            #endregion

            #region MasterDetail Relations
            modelBuilder.Entity<MasterDetail>()
                .HasOne(m => m.Master)
                .WithMany(d => d.Details)
                .HasForeignKey(d => d.MasterId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Account Relations
            modelBuilder.Entity<Account>()
                .HasOne(m => m.User)
                .WithMany(d => d.Accounts)
                .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<Account>()
                .HasOne(m => m.Bank)
                .WithMany(d => d.Accounts)
                .HasForeignKey(d => d.BankId);
            #endregion

            #region Trnasaction Relations
            modelBuilder.Entity<Transaction>()
                .HasOne(m => m.Account)
                .WithMany(d => d.Transactions)
                .HasForeignKey(d => d.AccountId);

            modelBuilder.Entity<Transaction>()
                .HasOne(m => m.DealType)
                .WithMany(d => d.Transactions)
                .HasForeignKey(d => d.DealTypeId);
            #endregion

            #region Article Relations
            modelBuilder.Entity<Article>()
                .HasOne(m => m.ArticleGroup)
                .WithMany(d => d.Articles)
                .HasForeignKey(d => d.ArticleGroupId);

            modelBuilder.Entity<Article>()
                .HasMany(m => m.ArticleImages)
                .WithOne(d => d.Article)
                .HasForeignKey(d => d.ArticleId);
            #endregion

            #region ArticleGroup Relations
            modelBuilder.Entity<ArticleGroup>()
                .HasOne(m => m.Parent)
                .WithMany(d => d.Childrens)
                .HasForeignKey(d => d.ParentId);
            modelBuilder.Entity<ArticleGroup>()
                .HasMany(m => m.Articles)
                .WithOne(d => d.ArticleGroup)
                .HasForeignKey(d => d.ArticleGroupId);
            #endregion

            #region Document Relations
            modelBuilder.Entity<Document>()
                .HasOne(m => m.Parent)
                .WithMany(d => d.Childrens)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Document>()
                .HasMany(p => p.DocumentImages)
                .WithOne(rp => rp.Document)
                .HasForeignKey(rp => rp.DocumentId);
            #endregion

            #region Permission Relations
            modelBuilder.Entity<Permission>()
                .HasOne(m => m.Parent)
                .WithMany(d => d.Childrens)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Permission>()
                .HasMany(p => p.RolePermissions)
                .WithOne(rp => rp.Permission)
                .HasForeignKey(rp => rp.PermissionId);
            #endregion

            #region Role Relations
            modelBuilder.Entity<Role>()
                .HasMany(p => p.RolePermissions)
                .WithOne(rp => rp.Role)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<Role>()
                .HasMany(p => p.UserRoles)
                .WithOne(rp => rp.Role)
                .HasForeignKey(rp => rp.RoleId);
            #endregion

            #region RolePermission Relations
            modelBuilder.Entity<RolePermission>()
                .HasOne(p => p.Role)
                .WithMany(r=>r.RolePermissions)
                .HasForeignKey(p=>p.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(p => p.Permission)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(p => p.PermissionId);
            #endregion

            #region UserRole Relations
            modelBuilder.Entity<UserRole>()
                .HasOne(p => p.Role)
                .WithMany(r=>r.UserRoles)
                .HasForeignKey(ur=>ur.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(p => p.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            #endregion

            base.OnModelCreating(modelBuilder: modelBuilder);
        }

        #region Application DataSets

        protected DbSet<Database> Databases { get; set; }
        protected DbSet<Software> Softwares { get; set; }

        #endregion

        #region Identity DataSets

        protected DbSet<Person> Persons { get; set; }
        protected DbSet<User> Users { get; set; }
        protected DbSet<Permission> Permissions { get; set; }
        protected DbSet<Role> Roles { get; set; }
        protected DbSet<RolePermission> RolePermissions { get; set; }
        protected DbSet<UserPermission> UserPermissions { get; set; }
        protected DbSet<UserRole> UserRoles { get; set; }
        protected DbSet<Address> Addresses { get; set; }
        protected DbSet<Email> Emails { get; set; }
        protected DbSet<Phone> Phones { get; set; }
        protected DbSet<SocialNetwork> SocialNetworks { get; set; }
        protected DbSet<UserSoftware> UserSoftwares { get; set; }
        protected DbSet<Visitor> Visitors { get; set; }

        #endregion

        #region AllInOne DataSets

        protected DbSet<WorkSheet> WorkSheets { get; set; }
        protected DbSet<Project> Projects { get; set; }
        protected DbSet<Contract> Contracts { get; set; }
        protected DbSet<Developer> Developers { get; set; }
        protected DbSet<Payment> Payments { get; set; }
        protected DbSet<Customer> Customers { get; set; }
        protected DbSet<ToDo> ToDos { get; set; }
        protected DbSet<TaskChecklist> TaskChecklists { get; set; }
        protected DbSet<AssignedTask> AssignedTasks { get; set; }

        #endregion

        #region Base Infromation DataSets

        protected DbSet<MasterDetail> MasterDetails { get; set; }

        #endregion

        #region ClientApi DataSets

        protected DbSet<Request> Requests { get; set; }

        #endregion

        #region Finance DataSets
        protected DbSet<Account> Accounts { get; set; }
        protected DbSet<Transaction> Transactions { get; set; }
        #endregion

        #region Blog DataSets
        protected DbSet<Article> Articles { get; set; }
        protected DbSet<ArticleGroup> ArticleGroups { get; set; }
        protected DbSet<ArticleImage> ArticleImages { get; set; }
        protected DbSet<Document> Documents { get; set; }
        protected DbSet<DocumentImage> DocumentImages { get; set; }
        #endregion
    }
}