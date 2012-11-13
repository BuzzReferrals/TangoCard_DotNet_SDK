using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using TangoCard.Sdk.Service;

namespace TangoCard.Sdk.Request.Version2
{
    [DataContract]
    public abstract class Version2Request : BaseRequest
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Constructor</summary>
        /// <param name="enumTangoCardServiceApi">The enum tango card service api.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Version2Request(
            TangoCardServiceApiEnum enumTangoCardServiceApi,
            string username, 
            string password
        ) : base(enumTangoCardServiceApi)
        {
            // -----------------------------------------------------------------
            // validate inputs
            // -----------------------------------------------------------------

            // username
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(paramName: "username" );
            }

            // password
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(paramName: "password" );
            }

            this.Username = username;
            this.Password = password;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the username. </summary>
        ///
        /// <value> The username. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [DataMember(Name = "username", IsRequired = true)]
        public string Username { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the password. </summary>
        ///
        /// <value> The password. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember(Name = "password", IsRequired = true)]
        public string Password { get; set; }

        public override string RequestController
        {
            get { return "Version2"; }
        }
    }
}
