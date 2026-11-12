using Lab5.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public static class DocumentFactory
    {
        public static IDocument CreateDocument(
            string type,
            string title)
        {
            return type.ToLowerInvariant() switch
            {
                "book" => new Book(title),
                "magazine" => new Magazine(title),
                "newspaper" => new Newspaper(title),
                _ => throw new ArgumentException(
                    "Invalid document type"
                )
            };
        }
    }
}
