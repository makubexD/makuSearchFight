using System.Configuration;

namespace SearchFight.Configuration
{
    public class SearcherCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

        protected override string ElementName => Attributes.Seacher;

        protected override bool IsElementName(string elementName)
        {
            var isName = false;
            if (!string.IsNullOrEmpty(elementName))
                isName = elementName.Equals(Attributes.Seacher);
            return isName;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SearcherElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SearcherElement)element).Name;
        }

        private struct Attributes
        {
            public const string Seacher = "searcher";
        }
    }
}
