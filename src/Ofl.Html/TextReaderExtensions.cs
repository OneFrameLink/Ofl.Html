using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace Ofl.Html
{
    public static class TextReaderExtensions
    {
        public static Task<IHtmlDocument> ToHtmlDocumentAsync(this TextReader reader, CancellationToken cancellationToken)
        {
            // Call the overload with the default.
            return reader.ToHtmlDocumentAsync(default, cancellationToken);
        }

        public static async Task<IHtmlDocument> ToHtmlDocumentAsync(this TextReader reader, HtmlParserOptions parserOptions, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (reader == null) throw new ArgumentNullException(nameof(reader));

            // Create a parser.
            var parser = new HtmlParser(parserOptions);

            // Read to a string.
            string source = await reader.ReadToEndAsync().ConfigureAwait(false);

            // Parse.
            return await parser.ParseDocumentAsync(source, cancellationToken).ConfigureAwait(false);
        }
    }
}
