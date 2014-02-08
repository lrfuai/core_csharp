using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;

namespace LRFLibrary.Functional.Image.Data
{
    public interface IKnowledgeSource
    {
        int getSizeX();
        int getSizeY();

        IList<IKnowledgeEntity> getEntities();
        IList<Image<Gray, byte>> getImagesOf(IKnowledgeEntity entity);

        void addEntityImage(IKnowledgeEntity entity, Image<Gray, byte> image);
        void removeEntityImage(IKnowledgeEntity entity, Image<Gray, byte> image);
        void clear();
    }
}