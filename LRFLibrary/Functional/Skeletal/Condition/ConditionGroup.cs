using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Kinect;

namespace LRFLibrary.Functional.Skeletal.Condition
{
    public class ConditionGroup : ISkeltalCondition
    {
        IList<ISkeltalCondition> conditions = new List<ISkeltalCondition>();

        public void add(ISkeltalCondition condition)
        {
            conditions.Add(condition);
        }

        bool ISkeltalCondition.apply(Microsoft.Kinect.Skeleton skel)
        {
            bool result = conditions.Count() > 0;
            foreach(ISkeltalCondition condition in conditions)
            {
                result = result && condition.apply(skel);
            }
            return result;
        }
    }
}
