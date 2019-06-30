using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository.Interfaces;
using Services.Interfaces;
using Services.ViewModels;

namespace Services.Services
{
    public class AccountManagerService : IAccountManagerService
    {
        //private readonly IUserProfileRepository _userProfileRepository;
        //public AccountManagerService(IUserProfileRepository userProfileRepository)
        //{
        //    _userProfileRepository = userProfileRepository;
        //}

        //public Task<(bool, UserProfile)> ValidateUserCredentialsAsync(string username, string password)
        //{
        //    var users = _userProfileRepository.GetAllNoneDeleted()
        //        .Where(x => x.UserName == username && x.Password == password);
        //    var isValid = users.Any();
        //    var result = (isValid, isValid ? users.FirstOrDefault() : null);
        //    return Task.FromResult(result);
        //}

        //public SignedModel SinginAccount(UserSigninModel signinModel)
        //{
        //    try
        //    {
        //        var userAccount = _userProfileRepository.GetSingleNoneDeleted(x => x.UserName == signinModel.UserName);
        //        if (null == userAccount)
        //        {
        //            var user = new UserProfile
        //            {
        //                UserName = signinModel.UserName,
        //                Active = true,
        //                CreatedBy = 1,
        //                CreatedDate = DateTime.Now,
        //                DisplayName = signinModel.DisplayName,
        //                Email = signinModel.Email,
        //            };
        //            _userProfileRepository.Add(user);
        //            _userProfileRepository.Commit();
        //            return new SignedModel();
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    return null;
        //}
    }
}
