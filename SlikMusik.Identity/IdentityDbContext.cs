using System.Data.Entity;

namespace SlikMusik.Identity
{
    public class IdentityDbContext : Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<User>
    {
        private IdentityDbContext() : base("IdentityDb")
        {
        }

        static IdentityDbContext()
        {
            Database.SetInitializer(new IdentityDbInit());
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }

        private class IdentityDbInit
            : DropCreateDatabaseIfModelChanges<IdentityDbContext>
        {
            protected override void Seed(IdentityDbContext context)
            {
                PerformInitialSetup(context);
                base.Seed(context);
            }

            public void PerformInitialSetup(IdentityDbContext context)
            {
                // initial configuration will go here
            }
        }
    }
}