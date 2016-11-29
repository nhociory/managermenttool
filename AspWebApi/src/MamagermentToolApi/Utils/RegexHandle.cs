using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MamagermentToolApi.Utils
{
    /// <summary>
    /// Any method of regex handle
    /// </summary>
    public class RegexHandle
    {
        /// <summary>
        /// Get any Match
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        public static MatchCollection Matches(string pattern, string document)
        {
            MatchCollection collectionItem;
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
            collectionItem = regex.Matches(document);
            return collectionItem;
        }
        /// <summary>
        /// Get only Match
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Match Match(string pattern, string document)
        {
            Match collectionItem;
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
            collectionItem = regex.Match(document);
            return collectionItem;
        }
    }
}
