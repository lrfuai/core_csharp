using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;

namespace LRFLibrary.Functional.Image.Recognizer
{
    using Image.Data;
    
    public class FaceRecognizer : IRecognizer
    {
        IKnowledgeSource source;
        EigenObjectRecognizer recognizer;
        HaarCascade faceDetector = new HaarCascade("C:/Emgu/emgucv-windows-universal-gpu 2.4.9.1847/opencv/data/haarcascade/haarcascade_frontalface_default.xml");

        public FaceRecognizer()
        {
        }

        public FaceRecognizer(IKnowledgeSource source)
        {
            this.load(source);
        }

        public IKnowledgeEntity recognize(Image<Rgb, byte> image)
        {
            if (recognizer == null) {
                throw new RecognizerEmptyKnowledgeException();
            }
            EigenObjectRecognizer.RecognitionResult result = recognizer.Recognize(image.Convert<Gray, byte>());
            foreach (IKnowledgeEntity entity in source.getEntities()) {
                if (entity.getId().Equals(result.Label)) {
                    return entity;
                }
	        }
            throw new RecognizerNotFoundException();
        }

        public void load(IKnowledgeSource source)
        {
            this.source = source;

            List<Image<Gray, byte>> entityImages = new List<Image<Gray, byte>>();
            List<string> entityIds = new List<string>();

            foreach (IKnowledgeEntity entity in source.getEntities()) {
                foreach (Image<Gray, byte> image in source.getImagesOf(entity)) {
                    entityIds.Add(entity.getId());
                    entityImages.Add(image);
                }
            }
            
            //TermCriteria for face recognition with numbers of trained images like maxIteration
            MCvTermCriteria termCrit = new MCvTermCriteria(entityIds.Count, 0.001);

            //Eigen face recognizer
            recognizer = new EigenObjectRecognizer(
                entityImages.ToArray(),
                entityIds.ToArray(),
                3000,
                ref termCrit
            );
        }
    }
}
