using Demo.Meetup.CustomMembership.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Demo.Meetup.CustomMembership
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles=new string[1];
            roles[0]=DBAccess.GetRoleForUser(username).Trim();
            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            //throw new NotImplementedException();
            if (DBAccess.GetRoleForUser(username).ToLower() == roleName.ToLower())
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public static int RoleForUser(string username, string roleName)
        {

            if (roleName.ToLower() == "super")
            {
                return 3;
            }
            else if (roleName.ToLower() == "admin")
            {
                return 2;
            }
            else if (roleName.ToLower() == "staff")
            {
                return 1;
            }
            else return 0;
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}