﻿using System;
using System.Web.Security;


namespace ALPPI.Models {
    public class Roles : RoleProvider{
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames){
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName){
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole){
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch){
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles(){
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username){
            if (username.Contains("@ADM")) {
                string[] sroles = { "ADMINISTRADOR" };
                return sroles;
            } else if (!username.Contains("@") && !username.Equals("")) {
                string[] sroles = { "ALUNO" };
                return sroles;
            }else if(username.Contains("@")) {
                string[] sroles = { "PROFESSOR" };
                return sroles;
            }
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName){
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName){
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames){
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName){
            throw new NotImplementedException();
        }
    }
}