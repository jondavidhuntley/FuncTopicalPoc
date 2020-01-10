using System;

namespace FuncAppPoc.Domain.Model
{
    public class ParaAnalysisResult
    {
        public ParaAnalysisResult()
        {
            Created = DateTime.Now;
        }

        public string LongestSentence { get; set; }

        public int MaxWordCount { get; set; }        

        public bool Success { get; set; }

        public string Diagnostic { get; set;
        }
        public DateTime Created { get; set; }
    }
}