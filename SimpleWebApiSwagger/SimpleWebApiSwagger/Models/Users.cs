using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebApiSwagger.Models
{
    /// <summary>
    /// User Model
    /// </summary>
    public class User
    {
        /// <summary>
        /// Username
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Full Name
        /// </summary>
        public string Fullname { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Register Date
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}