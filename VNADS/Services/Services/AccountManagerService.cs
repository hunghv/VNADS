﻿using System;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository.Implementation;
using Services.Interfaces;
using Services.ViewModels;

namespace Services.Services
{
    public class AccountManagerService:IAccountManagerService
    {
        private readonly UserProfileRepository _userProfileRepository;
        public AccountManagerService(UserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public SignedModel SinginAccount(UserSigninModel signinModel)
        {
            try
            {
                var userAccount = _userProfileRepository.GetSingleNoneDeleted(x => x.UserName == signinModel.UserName);
                if (null == userAccount)
                {
                    var user = new UserProfile
                    {
                        UserName = signinModel.UserName,
                        Active = true,
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        DisplayName = signinModel.DisplayName,
                        Email = signinModel.Email,
                    };
                    _userProfileRepository.Add(user);
                    _userProfileRepository.Commit();
                    return new SignedModel();
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return null;
        }

        public Task<(bool, UserProfile)> ValidateUserCredentialsAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
