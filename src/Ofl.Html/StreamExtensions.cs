using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace Ofl.Html
{
    public static class StreamExtensions
    {
        public static Task<IHtmlDocument> ToHtmlDocumentAsync(this Stream stream, CancellationToken cancellationToken)
        {
            // Call the overload with the default.
            return stream.ToHtmlDocumentAsync(default, cancellationToken);
        }

        public static Task<IHtmlDocument> ToHtmlDocumentAsync(this Stream stream, HtmlParserOptions parserOptions, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            // Create the 

            // Create a parser.
            var parser = new HtmlParser(parserOptions);

            // Parse.
            return parser.ParseDocumentAsync(stream, cancellationToken);
        }
    }
}
