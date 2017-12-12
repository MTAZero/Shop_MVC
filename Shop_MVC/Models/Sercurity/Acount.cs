using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_MVC.Models.Sercurity
{
    public class Acount
    {
        /// <summary>
        ///  Đăng nhập bằng email
        /// </summary>
        public int ID;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}