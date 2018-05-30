using WebAPI.Models;
using WebAPI.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.BLL
{
    public static class clsLogin
    {
        public static clsEnum.fLogin CheckLogin(this UnitOfWork instance, string username, string password)
        {
            xAccount account = instance.GetRepository<xAccount>().GetItems().FirstOrDefault(x => x.Username.ToLower().Equals(username.ToLower()) && x.Password.ToLower().Equals(password.ToLower()));

            if (account != null)
            {
                if (account.IsEnable)
                    return clsEnum.fLogin.Success;
                else
                    return clsEnum.fLogin.Disable;
            }
            else
            {
                return clsEnum.fLogin.NotFound;
            }
        }

        public static bool CheckExist(this UnitOfWork instance, string username)
        {
            xAccount account = instance.GetRepository<xAccount>().GetItems().FirstOrDefault(x => x.Username.ToLower().Equals(username.ToLower()));

            if (account != null)
                return true;
            return false;
        }
    }
}