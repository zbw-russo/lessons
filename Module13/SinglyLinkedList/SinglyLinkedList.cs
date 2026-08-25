namespace ZbW.ProgrammingFoundation.Lessons.Module13.SinglyLinkedList
{
    /// <summary>
    /// Einfach verkettete Liste (Singly Linked List).
    /// Jeder Knoten zeigt nur auf seinen Nachfolger.
    /// </summary>
    public class SinglyLinkedList
    {
        // TODO: Private Felder für den ersten und letzten Knoten (start, end)

        // TODO: Aufgabe 1 – Property Count (nur von aussen lesbar)

        #region Aufgabe 1: Add-Methode
        /// <summary>
        /// Fügt ein neues Element am Ende der Liste an.
        /// </summary>
        /// <param name="data">Der zu speichernde Wert.</param>
        public void Add(object data)
        {
            // TODO: Neuen Node erstellen
            // TODO: Falls die Liste leer ist (start == null): start und end auf den neuen Node setzen
            // TODO: Andernfalls: end.Link auf den neuen Node setzen, dann end aktualisieren
            // TODO: Count erhöhen
            throw new NotImplementedException();
        }
        #endregion

        #region Aufgabe 2: Contains-Methode
        /// <summary>
        /// Prüft, ob ein Element in der Liste vorhanden ist.
        /// </summary>
        /// <param name="data">Der gesuchte Wert.</param>
        /// <returns>true wenn gefunden, sonst false.</returns>
        public bool Contains(object data)
        {
            // TODO: Hilfsmethode Find() aufrufen und prüfen ob das Ergebnis != null ist
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sucht einen Knoten anhand seines Wertes und gibt ihn zurück.
        /// </summary>
        private Node Find(object data)
        {
            // TODO: Ab start durch die Liste iterieren (node = node.Link)
            // TODO: Bei jedem Schritt node.Data.Equals(data) prüfen
            // TODO: Gefundenen Knoten zurückgeben, null wenn nicht gefunden
            throw new NotImplementedException();
        }
        #endregion

        #region Aufgabe 3: Remove-Methode
        /// <summary>
        /// Entfernt das erste Element mit dem angegebenen Wert aus der Liste.
        /// </summary>
        /// <param name="data">Der zu entfernende Wert.</param>
        /// <returns>true wenn entfernt, false wenn nicht gefunden.</returns>
        public bool Remove(object data)
        {
            // TODO: Mit Find() prüfen ob das Element existiert (sonst false zurückgeben)
            // TODO: Mit FindPrevious() den Vorgänger-Knoten ermitteln
            // TODO: Falls Vorgänger vorhanden: previous.Link auf node.Link setzen,
            //       end anpassen falls node == end
            // TODO: Falls kein Vorgänger (erster Knoten): start auf node.Link setzen,
            //       end = null falls Liste danach leer ist
            // TODO: Count verringern, true zurückgeben
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gibt den Knoten zurück, der unmittelbar vor dem Knoten mit dem angegebenen Wert steht.
        /// </summary>
        private Node FindPrevious(object data)
        {
            // TODO: Ab start mit zwei Variablen (previous = null, node = start) iterieren
            // TODO: Wenn node.Data.Equals(data): previous zurückgeben
            // TODO: previous = node; node = node.Link weiterschalten
            throw new NotImplementedException();
        }
        #endregion

        #region Aufgabe 4: FindByIndex-Methode
        /// <summary>
        /// Gibt den Wert am angegebenen Index zurück.
        /// </summary>
        /// <param name="index">Nullbasierter Index.</param>
        /// <exception cref="IndexOutOfRangeException">Index ist ausserhalb des gültigen Bereichs.</exception>
        public object FindByIndex(int index)
        {
            // TODO: FindByIndexInternal() aufrufen und .Data zurückgeben
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gibt den Knoten am angegebenen Index zurück.
        /// </summary>
        private Node FindByIndexInternal(int index)
        {
            // TODO: IndexOutOfRangeException werfen wenn index < 0 oder index >= Count
            // TODO: Ab start mit einer Schleife bis zum Index laufen (node = node.Link)
            // TODO: Gefundenen Knoten zurückgeben
            throw new NotImplementedException();
        }
        #endregion

        #region Aufgabe 5: Indexer
        /// <summary>
        /// Ermöglicht den Zugriff per Index: list[0], list[1] = "neu"
        /// </summary>
        public object this[int index]
        {
          // TODO: get – FindByIndexInternal aufrufen und .Data zurückgeben
            // TODO: set – FindByIndexInternal aufrufen und .Data = value setzen
            get
            {
              throw new NotImplementedException();
            }
          set
          {
            throw new NotImplementedException();
          }
        }

        #endregion
    }
}
