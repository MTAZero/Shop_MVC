using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Shop_MVC.Models.Sercurity
{
    public class CustomPrincipal : IPrincipal
    {
        private Acount Account;
        public CustomPrincipal(Acount account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.Email);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            bool kq = roles.Any(r => this.Account.Role == r);
            return kq;
        }
    }
}