namespace ZbW.ProgrammingFoundation.Lessons.Module13.DoublyLinkedList
{
    /// <summary>
    /// Doppelt verkettete Liste (Doubly Linked List).
    /// Jeder Knoten kennt seinen Nachfolger (Link) und Vorgänger (PrevLink).
    /// Das ermöglicht effizientes Einfügen und Löschen in beide Richtungen.
    /// </summary>
    public class DoublyLinkedList
    {
        // TODO: Private Felder für den ersten und letzten Knoten (start, end)

        // TODO: Property Count (nur von aussen lesbar)

        /// <summary>
        /// Fügt ein neues Element am Ende der Liste an.
        /// </summary>
        public void Add(object data)
        {
            // TODO: Neuen Node erstellen
            // TODO: Liste leer: start = end = neuer Node
            // TODO: Sonst: end.Link auf neuen Node, neuer Node.PrevLink auf end, end aktualisieren
            // TODO: Count erhöhen
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fügt ein neues Element direkt nach dem Element mit dem Wert <paramref name="previousData"/> ein.
        /// </summary>
        /// <returns>true wenn eingefügt, false wenn previousData nicht gefunden.</returns>
        public bool InsertAfter(object previousData, object data)
        {
            // TODO: previousData mit Find() suchen (null → false zurückgeben)
            // TODO: Neuen Node erstellen
            // TODO: newNode.Link = prev.Link; newNode.PrevLink = prev
            // TODO: prev.Link = newNode
            // TODO: Falls newNode.Link != null: newNode.Link.PrevLink = newNode, sonst end = newNode
            // TODO: Count erhöhen, true zurückgeben
            throw new NotImplementedException();
        }

        /// <summary>Prüft ob ein Element in der Liste vorhanden ist.</summary>
        public bool Contains(object data)
        {
            // TODO: Find() aufrufen und != null prüfen
            throw new NotImplementedException();
        }

        private Node Find(object data)
        {
            // TODO: Ab start iterieren und mit .Equals() vergleichen
            throw new NotImplementedException();
        }

        /// <summary>
        /// Entfernt das erste Element mit dem angegebenen Wert.
        /// Korrigiert dabei alle betroffenen Zeiger (PrevLink und Link) in beide Richtungen.
        /// </summary>
        public bool Remove(object data)
        {
            // TODO: Find() aufrufen (null → false)
            // TODO: Falls node == start: start = node.Link
            // TODO: Falls node == end:   end  = node.PrevLink
            // TODO: Falls node.PrevLink != null: node.PrevLink.Link = node.Link
            // TODO: Falls node.Link     != null: node.Link.PrevLink = node.PrevLink
            // TODO: Count--, true zurückgeben
            throw new NotImplementedException();
        }

        /// <summary>Gibt den Wert am angegebenen Index zurück.</summary>
        public object FindByIndex(int index)
        {
            // TODO: FindByIndexInternal aufrufen und .Data zurückgeben
            throw new NotImplementedException();
        }

        private Node FindByIndexInternal(int index)
        {
            // TODO: IndexOutOfRangeException falls index ungültig
            // TODO: Ab start bis zum Index iterieren
            throw new NotImplementedException();
        }

        /// <summary>Ermöglicht Index-Zugriff: list[i] und list[i] = value</summary>
        public object this[int index]
        {
          get
          {
            throw new NotImplementedException();
          }
          set
          {
            throw new NotImplementedException();
          }
        }

        /// <summary>Leert die Liste vollständig.</summary>
        public void Clear()
        {
            // TODO: start = end = null; Count = 0
            throw new NotImplementedException();
        }
    }
}
