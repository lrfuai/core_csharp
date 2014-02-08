using System;
using Microsoft.Speech.Recognition;

namespace LRFLibrary.Functional.Speech.Recognition
{

    public interface IGrammarGroup
    {
        void add(Grammar grammar);
        void remove(Grammar grammar);
        void update(Grammar grammar);
        void clearAll();
    }
}