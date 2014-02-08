using System;

namespace LRFLibrary.Functional.Speech.Recognition
{
    class UpdateGrammarRequest
    {
        public GrammarRequestType Type { get; private set; }
        public GrammarGroup Group { get; private set; }

        public UpdateGrammarRequest(GrammarRequestType type, GrammarGroup group)
        {
            this.Type = type;
            this.Group = group;
        }
    }
}
