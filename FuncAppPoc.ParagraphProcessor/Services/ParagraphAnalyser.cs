using FuncAppPoc.Domain.Model;
using FuncAppPoc.Guards;
using Microsoft.Extensions.Logging;
using System;

namespace FuncAppPoc.ParagraphProcessor.Services
{
    public class ParagraphAnalyser : IParagraphAnalyser
    {
        private char[] _sentenceSeparators = new char[] { '!', '.', '?' };
        private char[] _wordSeparators = new char[] { ' ', ',', ';' };

        private readonly ILogger<ParagraphAnalyser> _logger;

        /// <summary>
        /// Create new instance of Analyser
        /// </summary>
        /// <param name="logger">Event Logger</param>
        public ParagraphAnalyser(ILogger<ParagraphAnalyser> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Analyse Paragraph Sample
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public ParaAnalysisResult Analyse(string sample)
        {
            Guard.AgainstNullOrWhitespace(sample, nameof(sample));

            ParaAnalysisResult result = new ParaAnalysisResult
            {
                MaxWordCount = 0                
            };

            var paragraph = sample.Trim();

            var sentences = paragraph.Split(_sentenceSeparators, StringSplitOptions.RemoveEmptyEntries);

            if (sentences.Length > 0)
            {
                _logger.LogInformation($"{sentences.Length} sentences Found!");

                foreach (string sentence in sentences)
                {
                    var words = sentence.Trim().Split(_wordSeparators, StringSplitOptions.RemoveEmptyEntries);

                    if (words.Length > result.MaxWordCount)
                    {
                        result.MaxWordCount = words.Length;
                        result.LongestSentence = sentence.Trim();
                    }
                }
            }
            else
            {
                _logger.LogInformation("No Sentences Found!");
            }

            if (result.MaxWordCount > 0)
            {
                result.Success = true;
                _logger.LogInformation($"Longest sentence contains {result.MaxWordCount} words!");
            }

            return result;
        }
    }
}