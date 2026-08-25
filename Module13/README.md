# Modul 13 – Verkettete Listen und Stack

Dieses Modul behandelt grundlegende dynamische Datenstrukturen: einfach und doppelt verkettete Listen
sowie den Stack (LIFO-Prinzip) in zwei Varianten (Array-basiert und Liste-basiert).

## Lernziele

- Das Konzept von Knoten (Node) und Zeigern (Links) verstehen und erklären können.
- Eine einfach verkettete Liste von Grund auf implementieren (Add, Contains, Remove, FindByIndex, Indexer).
- Eine doppelt verkettete Liste implementieren und den Unterschied zu einfach verketteten Listen erklären
  (PrevLink ermöglicht bidirektionale Navigation und effizienteres Löschen).
- Den Stack als abstrakte Datenstruktur verstehen: Push, Pop, Peek, LIFO-Reihenfolge.
- Zwei Implementierungsstrategien eines Stacks vergleichen:
    - Array-basiert (StackArray): zusammenhängender Speicher, automatisches Wachstum via Grow().
    - Liste-basiert (StackLinkedList): dynamisch verkettete Knoten, Push/Pop in O(1).
- Edge Cases sicher behandeln: leere Liste/Stack, erstes/letztes/einziges Element entfernen,
  IndexOutOfRangeException und InvalidOperationException gezielt einsetzen.

## Aufgaben

### SinglyLinkedList (einfach verkettete Liste)

Stubs befinden sich in `SinglyLinkedList/` – Lösungen in `SinglyLinkedList/Loesung/`.

| Aufgabe | Methode(n)                                   | Beschreibung                                                                     |
|---------|----------------------------------------------|----------------------------------------------------------------------------------|
| 1       | `Add(object data)`                           | Neuen Knoten am Ende anhängen; `Count` erhöhen.                                  |
| 2       | `Contains(object data)` + `Find()`           | Liste traversieren und Knoten per `Equals` suchen.                               |
| 3       | `Remove(object data)` + `FindPrevious()`     | Vorgänger-Knoten ermitteln und Link umbiegen; Edge Cases: Anfang/Ende/einzeln.   |
| 4       | `FindByIndex(int)` + `FindByIndexInternal()` | Per Index auf Knoten zugreifen; `IndexOutOfRangeException` bei ungültigem Index. |
| 5       | Indexer `this[int index]`                    | Lesend und schreibend per `[]`-Syntax auf Elemente zugreifen.                    |

### DoublyLinkedList (doppelt verkettete Liste)

Stubs in `DoublyLinkedList/` – Lösungen in `DoublyLinkedList/Loesung/`.

Gleiche Grundoperationen wie SinglyLinkedList, zusätzlich:

- `InsertAfter(object previousData, object data)` – Knoten gezielt nach einem bestimmten Element
  einfügen; alle vier Zeiger (Link und PrevLink beider betroffener Knoten) korrekt setzen.
- `Clear()` – Liste vollständig leeren.

### Stack

Stubs in `Stack/` – Lösungen in `Stack/Loesung/`.

Beide Klassen müssen dieselbe Schnittstelle (Push, Pop, Peek, Count) bereitstellen.

| Klasse            | Unterstruktur | Besonderheit                                             |
|-------------------|---------------|----------------------------------------------------------|
| `StackArray`      | `object[]`    | Internes Array; `Grow()` verdoppelt Kapazität wenn voll. |
| `StackLinkedList` | eigene Node   | start = TOP (letztes Push); Push und Pop beide O(1).     |

## Demo-Anwendungen

Jede Datenstruktur hat eine WinForms-Demo-App mit grafischer Visualisierung:

- `SinglyLinkedListDemo/` – Nodes als Boxen mit Richtungspfeilen, blau markierter Treffer.
- `DoublyLinkedListDemo/` – Bidirektionale Pfeile (blau = Link, orange = PrevLink).
- `StackDemo/` – Vertikale Darstellung; TOP-Element blau hervorgehoben; Umschalten zwischen
  StackArray und StackLinkedList zur Laufzeit möglich.

## Hinweise

- Alle Stub-Klassen enthalten `// TODO`-Kommentare mit schrittweisen Anleitungen.
- Für jede Datenstruktur gilt: erst die einfachste Operation (Add) implementieren und testen,
  dann schrittweise die komplexeren (Remove, InsertAfter).
- Die `OperationResult`-Klasse (im selben Ordner) kapselt Rückgaben der Demo-Logik – sie muss
  nicht implementiert werden.
