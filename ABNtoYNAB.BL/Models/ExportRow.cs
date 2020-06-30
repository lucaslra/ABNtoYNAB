using System;
using System.Text.RegularExpressions;
using CsvHelper.Configuration.Attributes;

namespace ABNtoYNAB.BL.Models
{
    public class ExportRow
    {
        [Index(3)]
        public decimal Amount { get; set; }

        [Index(0)]
        public DateTime Date { get; set; }

        [Index(2), Name("Memo")]
        public string ExportMemo
        {
            get => Memo switch
            {
                string Maandpremie when Maandpremie.StartsWith("Maandpremie") => "Home Insurance",
                _ => string.Empty
            };
        }

        [Ignore]
        public string Memo { get; set; }

        [Index(1)]
        public string Payee
        {
            get
            {
                string result = Memo switch
                {
                    string BEA when BEA.StartsWith("BEA") => ParseBea(BEA),
                    string SEPA when SEPA.StartsWith("SEPA") => ParseSepa(SEPA),
                    string TRTP when TRTP.StartsWith("/TRTP") => ParseTRTP(TRTP),
                    string Maandpremie when Maandpremie.StartsWith("Maandpremie") => ParseMaandpremie(),
                    string ABNAMRO when ABNAMRO.StartsWith("ABN AMRO Bank") => ParseABN(),
                    _ => "<Missing>"
                };
                return result;
            }
        }

        private string ParseABN() => "ABN AMRO";

        private string ParseBea(string entry)
        {
            var result = Regex.Match(entry, @"/\d{2}.\d{2} (?<Name>.*?),PAS", RegexOptions.IgnoreCase);

            return result.Groups["Name"].Value.Trim();
        }

        private string ParseMaandpremie() => "ABN AMRO";

        private string ParseSepa(string entry)
        {
            var result = Regex.Match(entry, @"Naam: (?<Name>.*?)\s{2,}?", RegexOptions.IgnoreCase);

            return result.Groups["Name"].Value.Trim();
        }

        private string ParseTRTP(string entry)
        {
            var result = Regex.Match(entry, "/NAME/(?<Name>.*?)/", RegexOptions.IgnoreCase);

            return result.Groups["Name"].Value.Trim();
        }
    }
}
