namespace ZbW.ProgrammingFoundation.Lessons.Module13.Stack
{
    /// <summary>
    /// Stack (LIFO – Last In, First Out) implementiert mit einem internen Array.
    /// Das Array verdoppelt sich automatisch, wenn die Kapazität erschöpft ist.
    /// </summary>
    public class StackArray
    {
        // TODO: Privates Array items (Typ: object[])

        // TODO: Property Count (nur von aussen lesbar)

        /// <summary>Erstellt einen neuen Stack mit optionaler Startkapazität.</summary>
        public StackArray(int initialCapacity = 10)
        {
            // TODO: items = new object[initialCapacity > 0 ? initialCapacity : 10]
            throw new NotImplementedException();
        }

        /// <summary>
        /// Legt ein Element oben auf den Stack.
        /// </summary>
        public void Push(object item)
        {
            // TODO: Grow() aufrufen falls kein Platz mehr
            // TODO: items[Count] = item; Count++
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gibt das oberste Element zurück, ohne es zu entfernen.
        /// </summary>
        /// <exception cref="InvalidOperationException">Stack ist leer.</exception>
        public object Peek()
        {
            // TODO: Exception werfen wenn Count == 0
            // TODO: items[Count - 1] zurückgeben
            throw new NotImplementedException();
        }

        /// <summary>
        /// Entfernt das oberste Element und gibt es zurück.
        /// </summary>
        /// <exception cref="InvalidOperationException">Stack ist leer.</exception>
        public object Pop()
        {
            // TODO: Exception werfen wenn Count == 0
            // TODO: Element merken, Slot auf null setzen, Count--, Element zurückgeben
            throw new NotImplementedException();
        }

        /// <summary>Leert den Stack vollständig.</summary>
        public void Clear()
        {
            // TODO: items neu initialisieren, Count = 0
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verdoppelt die Array-Kapazität wenn kein Platz mehr vorhanden ist.
        /// </summary>
        private void Grow()
        {
            // TODO: Falls items.Length >= Count + 1 → nichts tun
            // TODO: Array.Resize(ref items, items.Length * 2)
            throw new NotImplementedException();
        }
    }
}
