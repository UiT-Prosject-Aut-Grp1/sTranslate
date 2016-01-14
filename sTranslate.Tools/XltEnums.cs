using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sTranslate.Tools
{
    public class EnumsXlt
    {
        public enum PropertyTypes
        {
            Id = 1,
            Text,
            ToolTip,
            Page
        }
        public static PropertyTypes ToPropertyType(string value)
        {
            return (PropertyTypes)Enums.GetEnumState(typeof(PropertyTypes), value);
        }

        public enum Criterias 
        {
            None = 0,
            Exact,
            StartWith,
            EndWith,
            Contains
        }
        public static Criterias ToCriteria(string value)
        {
            return (Criterias)Enums.GetEnumState(typeof(Criterias), value);
        }

        /// <summary>
        /// This is only to use as helper to get type checked result.
        /// Ex: This will return exact "HtmlAnchor" and you avoids typing careless mistakes.  
        /// Ex: string str = Contexts.HtmlAnchor.ToString();   
        /// </summary>
        public enum Contexts
        {
            HtmlAnchor = 1,
            String,
            Title
        }
        public static Contexts ToContext(string value)
        {
            return (Contexts)Enums.GetEnumState(typeof(Contexts), value);
        }
    }
}
