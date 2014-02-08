using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;


namespace LRFLibrary.Functional.Image.Detector
{
    public class PatternDetector
    {
        HaarCascade haarCascade;

        public PatternDetector(string haarCascadeXmlFile)
        {
            haarCascade = new HaarCascade(haarCascadeXmlFile);
        }

        public List<MCvAvgComp> search(Image<Rgb, byte> image)
        {
            return this.search(image, new Size(20,20), new Size(1000,1000));
        }

        public List<MCvAvgComp> search(Image<Rgb, byte> image, Size minSize, Size maxSize)
        {
            List<MCvAvgComp> list = new List<MCvAvgComp>();
            MCvAvgComp[] facesDetected = haarCascade.Detect(
                image.Convert<Gray, byte>(),
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                minSize,
                maxSize
            );
            foreach (MCvAvgComp f in facesDetected) {
                list.Add(f);
            }
            return list;
        }
    }
}
