using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GospDiplom.DAL.Entities;
//using Microsoft.AspNet.Identity.Owin;
using GospDiplom.DAL.Repositories;
//using Microsoft.Owin;

namespace GospDiplom.DAL.Identity
{
    //Это стандартные для ASP.NET Identity классы по управлению ролями и пользователями. По сути эти классы выполняют роль репозиториев.

    //public ApplicationRoleManager(RoleStore<ApplicationRole> store)
    //            : base(store)
    //{ }
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore</*Identity*/ApplicationRole> store)
            : base(store)
        { }
        //public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
        //                                        IOwinContext context)
        //{
        //    return new ApplicationRoleManager(new
        //            RoleStore<IdentityRole>(context.Get<EFDbContext>()));
        //}
    }


}
