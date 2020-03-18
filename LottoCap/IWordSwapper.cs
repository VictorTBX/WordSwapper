using LottoCap.Models;

namespace LottoCap
{
    public interface IWordSwapper
    {
        WordSwapperModelResponse TransformWords(WordSwapperModelRequest modelResponse);
    }
}