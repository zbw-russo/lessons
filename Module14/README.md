# Modul 14 – Queue und Hashtable

Dieses Modul behandelt zwei lineare Datenstrukturen: die Queue (FIFO) in zwei Implementierungsvarianten
sowie eine einfache Hashtabelle mit Hash-Funktion und Kollisionsbehandlung.

## Lernziele

- Das FIFO-Prinzip erklären und von LIFO (Stack) abgrenzen.
- Die Operationen Enqueue, Dequeue und Peek beschreiben.
- Eine Queue als Array implementieren (mit automatischem Wachstum).
- Eine Queue als verkettete Liste implementieren.
- Erklären was eine Hashtabelle ist (assoziatives Array mit Key/Value Paaren).
- Eine additive Hash-Funktion implementieren.
- Kollisionen mit linearem Probing auflösen.

## Aufgaben

### Queue

Stubs befinden sich in `Queue/` – Lösungen in `Queue/Loesung/`.

Beide Klassen müssen dieselbe Schnittstelle (Enqueue, Dequeue, Peek, Clear, Count) bereitstellen.

| Klasse            | Unterstruktur | Besonderheit                                                           |
|-------------------|---------------|------------------------------------------------------------------------|
| `QueueArray`      | `object[]`    | _head / _tail Indizes; `Grow()` kompaktiert oder verdoppelt Kapazität. |
| `QueueLinkedList` | eigene Node   | _head = FRONT, _tail = BACK; Enqueue/Dequeue beide O(1).               |

```csharp
public void   Enqueue(object item)   // Element am Ende einfügen (tail)
public object Dequeue()              // Vorderstes Element entfernen und zurückgeben (head)
public object Peek()                 // Vorderstes Element anzeigen ohne zu entfernen
public void   Clear()                // Queue leeren
public int    Count                  // Anzahl Elemente
```

### Hashtable

Stub befindet sich in `Hashtable/` – Lösung in `Hashtable/Loesung/`.

| Klasse            | Besonderheit                                                          |
|-------------------|-----------------------------------------------------------------------|
| `SimpleHashtable` | Festes Array; additive Hash-Funktion; lineares Probing bei Kollision. |

```csharp
public void   Add(string key, object value)   // Eintrag hinzufügen oder überschreiben
public object Get(string key)                  // Wert per Key abrufen
public bool   Contains(string key)             // Prüfen ob Key vorhanden
public int    Count                            // Anzahl Einträge
```

**Hash-Funktion (additiv):** Summe der ASCII-Werte aller Zeichen, Modulo Array-Länge.

```
"abc" → 97 + 98 + 99 = 294 → 294 % 10 = 4
```

**Lineares Probing:** Ist ein Slot belegt (Kollision), wird der nächste Slot geprüft:
`index = (index + 1) % capacity`

## Hinweise

- Alle Stub-Klassen enthalten `// TODO`-Kommentare mit schrittweisen Anleitungen.
- `Dequeue()` / `Peek()` müssen bei leerer Queue eine `InvalidOperationException` werfen.
- `Get()` wirft eine `KeyNotFoundException` wenn der Key nicht vorhanden ist.
- Bei `QueueArray`: zuerst `Enqueue` und `Dequeue` implementieren, dann `Grow()` mit
  `initialCapacity = 2` testen.
- Bei `QueueLinkedList`: nach dem letzten `Dequeue()` muss `_tail` auf `null` gesetzt werden.
- Bei `SimpleHashtable`: beim Probing den Startindex merken – sonst entsteht eine Endlosschleife
  wenn die Tabelle voll ist.
