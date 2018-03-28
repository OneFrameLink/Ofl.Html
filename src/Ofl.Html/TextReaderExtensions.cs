using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace Ofl.Html
{
    public static class TextReaderExtensions
    {
        public static Task<IHtmlDocument> ToHtmlDocumentAsync(this TextReader reader, CancellationToken cancellationToken)
        {
            // Call the overload with the default.
            return reader.ToHtmlDocumentAsync(Configuration.Default, cancellationToken);
        }

        public static async Task<IHtmlDocument> ToHtmlDocumentAsync(this TextReader reader, IConfiguration configuration, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            // Create a parser.
            var parser = new HtmlParser(configuration);

            // Read to a string.
            string source = await reader.ReadToEndAsync().ConfigureAwait(false);

            // Parse.
            return await parser.ParseAsync(source, cancellationToken).ConfigureAwait(false);
        }
    }
}
