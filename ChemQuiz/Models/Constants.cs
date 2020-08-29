using System;
using System.Collections.Generic;
using System.Text;

namespace ChemQuiz.Models
{
    public static class Constants
    {
        static readonly string tenantName = "FabricioDocemaB2C";
        static readonly string tenantId = "FabricioDocemaB2C.onmicrosoft.com";
        static readonly string clientId = "dc5f8496-a025-46ea-ae59-1e72c8556225";
        static readonly string policySignin = "B2C_1_signin";
        static readonly string policyPassword = "B2C_1_reset";
        static readonly string iosKeychainSecurityGroup = "com.xamarin.adb2cauthorization";

        public static User LoggedUser = null;

        static readonly string[] scopes = { 
            "https://FabricioDocemaB2C.onmicrosoft.com/chemquiz/read.demo",
            "https://FabricioDocemaB2C.onmicrosoft.com/chemquiz/user_impersonation",
            "https://FabricioDocemaB2C.onmicrosoft.com/chemquiz/read"
        };

        static readonly string authorityBase = $"https://{tenantName}.b2clogin.com/tfp/{tenantId}/";
        public static string ClientId
        {
            get
            {
                return clientId;
            }
        }
        public static string AuthoritySignin
        {
            get
            {
                return $"{authorityBase}{policySignin}";
            }
        }
        public static string AuthorityPasswordReset
        {
            get
            {
                return $"{authorityBase}{policyPassword}";
            }
        }
        public static string[] Scopes
        {
            get
            {
                return scopes;
            }
        }
        public static string IosKeychainSecurityGroups
        {
            get
            {
                return iosKeychainSecurityGroup;
            }
        }
    }
}
