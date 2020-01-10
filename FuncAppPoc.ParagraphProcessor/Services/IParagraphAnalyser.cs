using FuncAppPoc.Domain.Model;

namespace FuncAppPoc.ParagraphProcessor.Services
{
    public interface IParagraphAnalyser
    {
        ParaAnalysisResult Analyse(string sample);
    }
}