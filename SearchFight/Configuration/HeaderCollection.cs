using System.Configuration;

namespace SearchFight.Configuration
{
    public class HeaderCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

        protected override string ElementName => Attributes.Header;

        protected override bool IsElementName(string elementName)
        {
            var isName = false;
            if (!string.IsNullOrEmpty(elementName))
                isName = elementName.Equals(Attributes.Header);
            return isName;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new HeaderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((HeaderElement)element).Key;
        }

        private struct Attributes
        {
            public const string Header = "header";
        }
    }
}
