﻿using System.Configuration;

namespace SearchFight.Configuration
{
    public class HeaderElement : ConfigurationElement
    {
        [ConfigurationProperty(Attributes.Key, IsKey = true, IsRequired = true)]
        public string Key => (string)this[Attributes.Key];

        [ConfigurationProperty(Attributes.Value, IsRequired = true)]
        public string Value => (string)this[Attributes.Value];
        
        private struct Attributes
        {
            public const string Key = "key";
            public const string Value = "value";
        }
    }
}
