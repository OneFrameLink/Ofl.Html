using System;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace Ofl.Html
{
    public static class StringExtensions
    {
        public static IHtmlDocument ToHtmlDocument(this string str) => 
            str.ToHtmlDocument(default);

        public static IHtmlDocument ToHtmlDocument(this string str, HtmlParserOptions parserOptions)
        {
            // Validate parameters.
            if (str == null) throw new ArgumentNullException(nameof(str));

            // Create a parser.
            var parser = new HtmlParser(parserOptions);

            // Parse.
            return parser.ParseDocument(str);
        }
    }
}
