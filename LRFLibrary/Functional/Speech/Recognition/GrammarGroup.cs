using System;
using System.Collections.Generic;

using Microsoft.Speech.Recognition;

namespace LRFLibrary.Functional.Speech.Recognition
{

    public class GrammarGroup : IGrammarGroup
    {
        public string Name { get; private set; }
        public List<Grammar> Grammars { get; private set; }

        public GrammarGroup (string name)
        {
            this.Name = name;
            this.Grammars = new List<Grammar>();
        }

        public void add(Grammar grammar)
        {
            this.Grammars.Add(grammar);
        }

        public void remove(Grammar grammar)
        {
            this.Grammars.Remove(grammar);
        }

        public void update(Grammar grammar)
        {
            this.remove(grammar);
            this.add(grammar);
        }

        public void clearAll()
        {
            this.Grammars.Clear();
        }
    }
}
