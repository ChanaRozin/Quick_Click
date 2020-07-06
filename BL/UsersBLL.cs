using System;
using DTO;
using DAL;
using System.Linq;
namespace BL
{
    public class UsersBLL
    {
        public static bool Register(DTO.DtoUser user)
        {
            return UserDAL.Register(Converts.UserConvert.FromDtoToDal(user));

        }

       
        public static DtoUser Login(string usercode, string password)
        {
            User user = UserDAL.Login(usercode, password);
            if(user!=null)
            return Converts.UserConvert.FromDalToDto(user);
            return null;
        }
        
            public static bool DeletePlayer(int userId)
        {
            return UserDAL.DeletePlayer(userId);

        }
        public static string getNameUser(int id)
        {
            return UserDAL.getNameUser(id);
        }
    }
}
