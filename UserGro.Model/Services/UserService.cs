using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using UserGro.Model.Interfaces;
using UserGro.Model.Repositories;
using UserGro.Model.ViewModels;

namespace UserGro.Model.Services
{
    public class UserService
    {
        private IRepository<User> _repo;

        public UserService()
        {
            _repo = new UserRepository();
        }

        //for testing
        public UserService(IRepository<User> repo)
        {
            _repo = repo;
        }

        public IUser GetUserByUserName(string userName)
        {
            return _repo.GetOneByName(userName);
        }
        public IUserViewModel GetProfileAsUser(string userName, IUser requestingUser)
        {
            //get the user by user name
            var user = GetUserByUserName(userName); 

            //if the user is not friends with the request user 
            if (!user.Friends.Contains(requestingUser))
            {
                //get their name and return everything else blank
                var vm = new UserViewModel();
                vm.Name = user.Name;
                vm.UserName = user.UserName;
                return vm;
            }

            return user.ToViewModel();
        }

        public static IUserViewModel GetEmptyViewModel()
        {
            return new UserViewModel {Email = "", Name = "", UserName = ""};
        }

    }
}
