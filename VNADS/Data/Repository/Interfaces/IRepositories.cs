using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Data.Repository.Base;

namespace Data.Repository.Interfaces
{
    public interface IUserLoginHistoryRepository : IEntityBaseRepository<UserLoginHistory> { }
    public interface IUserRoleRepository : IEntityBaseRepository<UserRole> { }
    public interface IUserProfileRepository : IEntityBaseRepository<UserProfile> { }
    public interface IRoleRepository : IEntityBaseRepository<Role> { }
    public interface IImageRepository : IEntityBaseRepository<Image> { }
    public interface IAdsFormRepository : IEntityBaseRepository<AdsForm> { }
    public interface IAdsTypeRepository : IEntityBaseRepository<AdsType> { }
    public interface IApplicationLanguageRepository : IEntityBaseRepository<ApplicationLanguage> { }
    public interface IPostRepository : IEntityBaseRepository<Post> { }
    public interface IPostImageRepository : IEntityBaseRepository<PostImage> { }
    public interface IPostTypeRepository : IEntityBaseRepository<PostType> { }
}
