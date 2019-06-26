using Data.Context;
using Data.Entities;
using Data.Repository.Base;
using Data.Repository.Interfaces;

namespace Data.Repository.Implementation
{
    public class UserLoginHistoryRepository : EntityBaseRepository<UserLoginHistory>, IUserLoginHistoryRepository
    {
        public UserLoginHistoryRepository(CoffeeRenoContext context) : base(context)
        {
        }
    }
    public class UserProfileRepository : EntityBaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(CoffeeRenoContext context) : base(context)
        {
        }
    }
    public class UserRoleRepository : EntityBaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(CoffeeRenoContext context) : base(context)
        {
        }
    }
    public class RoleRepository : EntityBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(CoffeeRenoContext context) : base(context)
        {
        }
    }

    public class ImageRepository : EntityBaseRepository<Image>, IImageRepository
    {
        public ImageRepository(CoffeeRenoContext context) : base(context)
        {
        }
    }

    public class AdsFormRepository : EntityBaseRepository<AdsForm>, IAdsFormRepository
    {
        public AdsFormRepository(CoffeeRenoContext context) : base(context)
        {
        }
    }

    public class ApplicationLanguageRepository : EntityBaseRepository<ApplicationLanguage>, IApplicationLanguageRepository
    {
        public ApplicationLanguageRepository(CoffeeRenoContext context) : base(context)
        {
        }
    }

    public class AdsTypeRepository : EntityBaseRepository<AdsType>, IAdsTypeRepository
    {
        public AdsTypeRepository(CoffeeRenoContext context) : base(context)
        {
        }
    }

    public class PostRepository : EntityBaseRepository<Post>, IPostRepository
    {
        public PostRepository(CoffeeRenoContext context) : base(context)
        {
        }
    }

    public class PostImageRepository : EntityBaseRepository<PostImage>, IPostImageRepository
    {
        public PostImageRepository(CoffeeRenoContext context) : base(context)
        {
        }
    }

    public class PostTypeRepository : EntityBaseRepository<PostType>, IPostTypeRepository
    {
        public PostTypeRepository(CoffeeRenoContext context) : base(context)
        {
        }
    }
}
