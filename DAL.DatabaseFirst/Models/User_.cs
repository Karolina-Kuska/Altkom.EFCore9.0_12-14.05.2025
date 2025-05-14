using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.DatabaseFirst.Models
{
    public partial class User
    {

        public void SetUserType(UserType userType)
        {
            UserType = userType.ToString();
        }

        public UserType GetUserType()
        {
            return (UserType)Enum.Parse(typeof(UserType), UserType);
        }

        public string GetInfo()
        {
            return $"User: {Username}, Type: {UserType}";
        }
    }
}
