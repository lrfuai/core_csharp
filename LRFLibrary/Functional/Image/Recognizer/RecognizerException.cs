using System;

namespace LRFLibrary.Functional.Image.Recognizer
{
    class RecognizerException : Exception { }

    class RecognizerNotFoundException : RecognizerException { }

    class RecognizerEmptyKnowledgeException : RecognizerException { }
}
