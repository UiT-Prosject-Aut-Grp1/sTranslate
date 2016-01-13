using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sCore.Service.Model;

namespace sCore.Translation
{
    /// <summary>
    /// Translate :
    ///     This class contains functionality for translation from one language to another.
    ///     The translation definitions are read from the Translate table.
    ///     The default source language code (FromLang) is 'en' for English.  
    /// </summary>
    public class XltTool
    {
        private static List<Service.Model.Translation> _translateColl = null; 
        public static string FromLanguageCode = "en";

        /// <summary>
        /// Get all translation entities into collection
        /// </summary>
        /// <param name="reRead">ReRead from database</param>
        /// <returns>Translation collection</returns>
        public static List<Service.Model.Translation> GetTranslations(bool reRead = false)
        {
            if (_translateColl == null || reRead == true)
            {
                using (var ctx = new ServiceEntities())
                {
                    _translateColl = (from xl in ctx.Translation select xl).ToList();
                    if (_translateColl == null)
                        _translateColl = new List<Service.Model.Translation>();
                    return _translateColl;
                }
            }
            return _translateColl;
        }

        /// <summary>
        /// 
        ///     GetToText methode returen the translated string, if defined int the Translate table. 
        ///     If the fromText is not found, the value of fromText is returned unchanged.
        ///     Multiple definitions for the same source string can be registered, and in case, 
        ///     the property and context fields must be used to separate them.    
        /// 
        /// </summary>
        /// <param name="fromText"> The string to be translated </param>
        /// <param name="context"> The context the definition is aimed for. </param>
        /// <param name="propType"> The row type. This is to be used to pinpoint the search string if multiple definitions exists </param>
        /// <returns> The translated string contained in the ToText field </returns>
        public static string GetToText(EnumsXlt.Criterias criteria, string fromText, EnumsXlt.PropertyTypes property, string context, string toLanguageCode = "no")
        {
            if (fromText.Trim() == "")
                return "";

            List<Service.Model.Translation> coll = new List<Service.Model.Translation>();
            using (var ctx = new ServiceEntities())
            {
                if (string.IsNullOrEmpty(toLanguageCode)) 
                    toLanguageCode = "no";

                // Do search by criteria
                coll = (from xl in ctx.Translation
                        where xl.Criteria.ToLower() == criteria.ToString().ToLower() &&
                              xl.FromLang == FromLanguageCode && 
                              xl.FromText == fromText && 
                              xl.Property.ToLower() == property.ToString().ToLower() &&
                              xl.Context.ToLower() == context.ToLower() &&
                              xl.ToLang == toLanguageCode
                        select xl).ToList();

                return (coll != null && coll.Count > 0) ? coll.First().ToText : fromText;  
            }
        }

        /// <summary>
        /// 
        ///     ToText methode returen the translated string, if defined int the Translate table. 
        ///     If the fromText is not found, the value of fromText is returned unchanged.
        ///     Multiple definitions for the same source string can be registered, and in case, 
        ///     the context and rowtype fields must be used to separate them.    
        /// 
        /// </summary>
        /// <param name="fromText"> The string to be translated </param>
        /// <param name="context"> The context the definition is aimed for. </param>
        /// <param name="propType"> The row type. This is to be used to pinpoint the search string if multiple definitions exists </param>
        /// <returns> The translated string contained in the ToText field </returns>
        public static string ToText(EnumsXlt.Criterias criteria, string fromText, EnumsXlt.PropertyTypes property, string context, string toLanguageCode = "no")
        {
            if (fromText.Trim() == "")
                return ""; 

            GetTranslations();

            if (string.IsNullOrEmpty(toLanguageCode))
                toLanguageCode = "no";

            // Serach collection
            foreach (Service.Model.Translation xl in _translateColl)
            {
                if (xl.Criteria.ToLower() == criteria.ToString().ToLower() &&
                    xl.FromLang == FromLanguageCode &&
                    xl.FromText == fromText &&
                    xl.Property.ToLower() == property.ToString().ToLower() &&
                    xl.Context.ToLower() == context.ToLower() &&
                    xl.ToLang == toLanguageCode)
                    return xl.ToText; 
            }
            return fromText; 
        }

        public static string ToText(string fromText, EnumsXlt.PropertyTypes property, string context, string toLanguageCode = "no")
        {
            if (fromText.Trim() == "")
                return "";
            string toText = fromText;
            List<Service.Model.Translation> coll;
            coll = XltTool.GetXltByKeys(property, context, EnumsXlt.Criterias.None);
            foreach (Service.Model.Translation tr in coll)
            {
                switch (tr.Criteria.ToString().ToLower())
                {
                    case "startwith":
                        if (toText.ToLower().StartsWith(tr.FromText.ToLower()))
                            toText = toText.Replace(tr.FromText, tr.ToText);
                        break;
                    case "endwith":
                        if (toText.ToLower().EndsWith(tr.FromText.ToLower()))
                            toText = toText.Replace(tr.FromText, tr.ToText);
                        break;
                    case "exact":
                        if (toText.ToLower() == tr.FromText.ToLower())
                            toText = toText.Replace(tr.FromText, tr.ToText);
                        break;
                    case "contains":
                        if (toText.ToLower().Contains(tr.FromText.ToLower()))
                            toText = toText.Replace(tr.FromText, tr.ToText);
                        break;
                    case "none":
                        if (tr.FromText == "*")
                            toText = tr.ToText;
                        else
                            if (toText.ToLower().Contains(tr.FromText.ToLower()))
                                toText = toText.Replace(tr.FromText, tr.ToText);
                        break;
                    default:
                        // No translation
                        break;
                }
            }

            return toText;
        }

        /// <summary>
        /// Get Translation entity collection by keys 
        /// </summary>
        /// <param name="propertyType"></param>
        /// <param name="context"></param>
        /// <param name="toLanguageCode"></param>
        /// <returns></returns>
        public static List<Service.Model.Translation> GetTranslationByKeys(EnumsXlt.Criterias criteria, EnumsXlt.PropertyTypes property, string context = null, string toLanguageCode = "no")
        {
            List<Service.Model.Translation> coll = new List<Service.Model.Translation>();
            using (var ctx = new ServiceEntities())
            {
                if (string.IsNullOrEmpty(toLanguageCode))
                    toLanguageCode = "no";


                coll = (from xl in ctx.Translation
                        where xl.FromLang == FromLanguageCode && xl.ToLang == toLanguageCode && 
                              xl.Criteria.ToLower() == criteria.ToString().ToLower() &&  
                              xl.Property.ToLower() == property.ToString().ToLower() && 
                              (context == null || (context != null && xl.Context.ToLower() == context.ToLower()))
                        select xl).ToList();

                return (coll != null) ? coll : new List<Service.Model.Translation>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="propertyType"></param>
        /// <param name="context"></param>
        /// <param name="toLanguageCode"></param>
        /// <returns></returns>
        public static List<Service.Model.Translation> GetXltByKeys(EnumsXlt.PropertyTypes property, string context, EnumsXlt.Criterias criteria = EnumsXlt.Criterias.None, string toLanguageCode = "no")
        {
            List<Service.Model.Translation> newColl = new List<Service.Model.Translation>();
            if (context == null)
                return newColl; 

            GetTranslations(); 
            using (var ctx = new ServiceEntities())
            {
                if (string.IsNullOrEmpty(toLanguageCode))
                    toLanguageCode = "no";

                // Serach matching entities
                foreach (Service.Model.Translation xl in _translateColl)
                {
                    if (((criteria == EnumsXlt.Criterias.None) || (criteria != EnumsXlt.Criterias.None && xl.Criteria.ToLower() == criteria.ToString().ToLower())) &&
                        xl.FromLang == FromLanguageCode &&
                        xl.Property.ToLower() == property.ToString().ToLower() &&
                        xl.Context.ToLower() == context.ToLower() &&
                        xl.ToLang == toLanguageCode)
                    {
                        newColl.Add(xl);
                    }
                }
            }
            return newColl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public static bool IsCriteriaMet(string text, Service.Model.Translation tr)
        {
            // string[] arr = Tool.RxReplace(c.Text, "(<.*?>)|([\n]+)|(&nbsp;)", "").Split(new string[] { "\r", ":", "  " }, StringSplitOptions.RemoveEmptyEntries);
            switch (EnumsXlt.ToCriteria(tr.Criteria))
            {
                case EnumsXlt.Criterias.Exact:
                    if (text.IndexOf(">" + tr.FromText) >= 0 && text.IndexOf(tr.FromText + "<") >= 0)
                        return true;
                    break;
                case EnumsXlt.Criterias.StartWith:
                    if (text.IndexOf(">" + tr.FromText) >= 0)
                        return true;
                    break;
                case EnumsXlt.Criterias.EndWith:
                    if (text.IndexOf(tr.FromText + "<") >= 0)
                        return true;
                    break;
                case EnumsXlt.Criterias.Contains:
                    if (text.IndexOf(tr.FromText) >= 0)
                        return true;
                    break;
            }
            return false;
        }

    }
}
