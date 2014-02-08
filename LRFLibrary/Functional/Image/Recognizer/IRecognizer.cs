using Emgu.CV;
using Emgu.CV.Structure;

namespace LRFLibrary.Functional.Image.Recognizer
{
    using Image.Data;

    public interface IRecognizer
    {
        void load (IKnowledgeSource source);

        IKnowledgeEntity recognize(Image<Rgb, byte> image);
    }
}
