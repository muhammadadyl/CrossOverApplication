﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace CrossOverApplication.Core.Domain.Entities.Identity
{
     public class ApplicationAuthenticationDescription
    {
        private const string CaptionPropertyKey = "Caption";
        private const string AuthenticationTypePropertyKey = "AuthenticationType";

        public ApplicationAuthenticationDescription()
        {
            Properties = new Dictionary<string, object>(StringComparer.Ordinal);
        }

        public ApplicationAuthenticationDescription(IDictionary<string, object> properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException("properties");
            }
            Properties = properties;
        }

        public IDictionary<string, object> Properties { get; private set; }

        public string AuthenticationScheme
        {
            get { return GetString(AuthenticationTypePropertyKey); }
            set { Properties[AuthenticationTypePropertyKey] = value; }
        }

        public string DisplayName
        {
            get { return GetString(CaptionPropertyKey); }
            set { Properties[CaptionPropertyKey] = value; }
        }

        private string GetString(string name)
        {
            object value;
            if (Properties.TryGetValue(name, out value))
            {
                return Convert.ToString(value, CultureInfo.InvariantCulture);
            }
            return null;
        }
    }
}
