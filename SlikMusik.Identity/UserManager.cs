using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace SlikMusik.Identity
{
    public class UserManager : UserManager<User>
    {
        private UserManager(IUserStore<User> store)
            : base(store)
        {
        }

        public static UserManager Create(
            IdentityFactoryOptions<UserManager> options,
            IOwinContext context)
        {
            var db = context.Get<IdentityDbContext>();
            var manager = new UserManager(new UserStore<User>(db));

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };

            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            return manager;
        }
    }
}