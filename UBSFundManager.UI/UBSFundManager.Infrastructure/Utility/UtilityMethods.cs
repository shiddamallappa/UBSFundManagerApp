using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBSFundManager.Infrastructure.Utility
{
   public static class UtilityMethods
    {
       public static int GetDefaultLoggedUserIdFromConfig()
       {
           int userid = 0;
           var value = System.Configuration.ConfigurationSettings.AppSettings["DefaultLoggedInUserId"].ToString();
           int.TryParse(value,out userid);
           return userid;
       }
    }
}
