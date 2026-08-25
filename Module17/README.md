# Modul 17: Heaps, Prioritätswarteschlangen und Huffman-Kodierung

## Übersicht

Dieses Modul behandelt fortgeschrittene Datenstrukturen wie Heaps und deren praktische Anwendungen. Studenten lernen die
Implementierung von Min- und Max-Heaps, Prioritätswarteschlangen für Flughafen-Landungsreihenfolgen und
Huffman-Kodierung für Datenkompression.

## Lernziele

- Verstehen und Implementieren von Heap-Datenstrukturen
- Anwendung von Heaps als Prioritätswarteschlangen
- Implementierung des Huffman-Algorithmus für Datenkompression
- Vergleich und IComparable-Interface für benutzerdefinierte Sortierung
- Praktische Anwendungen von Baumstrukturen

## Aufgaben und Musterlösungen

Die Aufgaben-Dateien (`MinHeap.cs`, `MaxHeap.cs`, `LandingOrder.cs`, `Frequency.cs`, `HuffmanTree.cs`) sind
TODO-Stubs zum selber Implementieren. Sie werfen `NotImplementedException`, bis die markierten Stellen gelöst sind.
Die vollständigen Musterlösungen liegen jeweils im Unterordner `Loesung/` (eigener Namespace `…Loesung`):

- `MinMaxHeap/Loesung/MinHeap.cs`, `MinMaxHeap/Loesung/MaxHeap.cs`
- `Flughafen/Loesung/LandingOrder.cs`
- `Huffman/Loesung/Frequency.cs`, `Huffman/Loesung/HuffmanTree.cs`

Im Starter erscheint jede Übung doppelt – als Aufgabe (Stub) und als lauffähige Lösung:

| Übung      | Aufgabe (Stub)            | Lösung (lauffähig)                  |
|------------|---------------------------|-------------------------------------|
| MinMaxHeap | `MinMaxHeapForm`          | `MinMaxHeapLoesungForm`             |
| Flughafen  | `FlughafenForm`           | `FlughafenLoesungForm`              |
| Huffman    | `HuffmanForm`             | `HuffmanLoesungForm`                |

Die Aufgaben-Forms verwenden die Stubs und zeigen einen TODO-Hinweis, solange eine Methode noch nicht
implementiert ist; die Lösungs-Forms (Eintrag „… (Lösung)") laufen direkt mit dem fertigen Code aus den
`Loesung/`-Ordnern.

## Aufgaben und Dateien

### 1. Flughafen-Landungsreihenfolge (`Flughafen/`)

Simulation eines Flughafens mit Prioritätswarteschlange für Landungen basierend auf Treibstoffmenge.

#### `Airplane.cs`

- Repräsentiert ein Flugzeug mit Abflughafen und Treibstoffmenge
- Implementiert `IComparable` für Vergleiche nach Treibstoffmenge
- **Eigenschaften**:
    - `DepartureAirport`: Abflughafen als String
    - `QuantityOfPetrol`: Verbleibende Treibstoffmenge in Litern
- **Prioritätslogik**: Flugzeuge mit weniger Treibstoff haben höhere Priorität
- **CompareTo**: Vergleicht Treibstoffmengen für Heap-Sortierung

#### `LandingOrder.cs` (Implementierung erforderlich)

- **TODO-Aufgabe**: Implementierung einer Prioritätswarteschlange
- `AddAirplane(Airplane airplane)`: Flugzeug zur Warteschlange hinzufügen
- `GetNextAirplane()`: Nächstes Flugzeug (mit am wenigsten Treibstoff) abrufen
- **Anwendung**: MinHeap für Treibstoff-basierte Priorisierung

### 2. Min/Max-Heap Implementierungen (`MinMaxHeap/`)

Grundlegende Heap-Datenstrukturen mit Array-basierter Speicherung.

#### `MinHeap.cs` (Implementierung erforderlich)

- **Min-Heap**: Kleinster Wert ist immer an der Wurzel
- **Eigenschaften**:
    - `Empty`: Überprüfung auf leeren Heap
    - `Size`: Anzahl Elemente im Heap
- **Methoden** (TODO):
    - `Add(object item)`: Element hinzufügen mit Heapify-Up
    - `Peek()`: Kleinster Wert abrufen ohne Entfernung
    - `Pop()`: Kleinster Wert entfernen und zurückgeben mit Heapify-Down
    - `PrintHeap()`: Konsolen-Ausgabe des Heaps (bereits implementiert)
- **Hilfsmethoden** (TODO):
    - `GetLeftIndex(int idx)`: Index des linken Kindes berechnen
    - `GetParentIndex(int idx)`: Index des Eltern-Elements berechnen
    - `GetRightIndex(int idx)`: Index des rechten Kindes berechnen

#### `MaxHeap.cs` (Implementierung erforderlich)

- **Max-Heap**: Grösster Wert ist immer an der Wurzel
- Identische Struktur wie MinHeap, aber umgekehrte Priorität
- Alle Methoden analog zu MinHeap, aber mit Max-Heap-Eigenschaft

**Heap-Eigenschaften**:

- **Array-Darstellung**: Eltern bei Index `i`, Kinder bei `2*i+1` und `2*i+2`
- **Zeitkomplexität**: Insert/Delete O(log n), Peek O(1)
- **Heap-Eigenschaft**: Min-Heap: Eltern <= Kinder, Max-Heap: Eltern >= Kinder

### 3. Huffman-Kodierung (`Huffman/`)

Implementierung des Huffman-Algorithmus für verlustfreie Datenkompression.

#### `Entry.cs`

- Datenstruktur für Huffman-Tree-Knoten
- **Eigenschaften**:
    - `Key`: Häufigkeit oder Priorität als Integer
    - `Value`: Zeichen (char?) oder null für interne Knoten

#### `Node.cs`

- Baum-Knoten für Huffman-Tree
- Implementiert `IComparable` für Prioritätswarteschlange
- **Eigenschaften**:
    - `Value`: Entry-Objekt mit Häufigkeit und Zeichen
    - `LeftChild`, `RightChild`: Kinder-Knoten (read-only)
- **Konstruktoren**: Für Blatt-Knoten und interne Knoten

#### `Frequency.cs` (Implementierung erforderlich)

- **TODO-Aufgabe**: Häufigkeitsanalyse von Texten
- `CountFrequency(string text)`: Zählt Zeichenhäufigkeiten
- **Rückgabe**: Liste von Entry-Objekten mit Zeichen und deren Häufigkeiten

#### `HuffmanTree.cs` (Implementierung erforderlich)

- **TODO-Aufgaben**: Huffman-Baum-Konstruktion und Bit-Code-Generierung
- **Konstruktor**: `HuffmanTree(ICollection<Entry> frequencies)`
    - Baut Huffman-Baum aus Häufigkeitstabelle
    - Verwendet Min-Heap für optimale Baum-Konstruktion
- `AssignBits(Node n, char[] bits, int nBits)`: Rekursive Bit-Code-Zuweisung
    - Traversiert Baum und bestimmt Huffman-Codes
    - Links = '0', Rechts = '1'

**Huffman-Algorithmus**:

1. Häufigkeiten aller Zeichen zählen
2. Min-Heap mit Zeichen nach Häufigkeit erstellen
3. Zwei kleinste Knoten kombinieren bis nur einer übrig
4. Bit-Codes durch Baum-Traversierung zuweisen

## Unit Tests

Die entsprechenden Unit Tests finden Sie im Ordner:
`ZbW.ProgrammingFoundation.Challenges.Tests/Modul17/`

- `AirplaneTests.cs`: Tests für Airplane-Klasse und IComparable

## Verwendung

### Airplane und Priorität:

```csharp
Airplane plane1 = new Airplane("Zürich", 150); // 150L Treibstoff
Airplane plane2 = new Airplane("Basel", 50);   // 50L Treibstoff

// plane2 hat höhere Priorität (weniger Treibstoff)
int comparison = plane1.CompareTo(plane2); // > 0 (plane1 hat mehr)
```

### Heap-Operationen (nach Implementierung):

```csharp
MinHeap heap = new MinHeap();
heap.Add(10);
heap.Add(5);
heap.Add(15);

int min = (int)heap.Peek(); // 5 (ohne Entfernung)
int removed = (int)heap.Pop(); // 5 (mit Entfernung)
```

### Huffman-Kodierung (nach Implementierung):

```csharp
Frequency freq = new Frequency();
List<Entry> frequencies = freq.CountFrequency("hello world");

HuffmanTree tree = new HuffmanTree(frequencies);
// Bit-Codes für effiziente Kompression generieren
```

## Wichtige Konzepte

### Heap-Eigenschaften

- **Min-Heap**: Jeder Eltern-Knoten <= seine Kinder
- **Max-Heap**: Jeder Eltern-Knoten >= seine Kinder
- **Array-Indizierung**: Parent(i) = (i-1)/2, Left(i) = 2*i+1, Right(i) = 2*i+2
- **Heapify**: Wiederherstellung der Heap-Eigenschaft nach Operationen

### Prioritätswarteschlangen

- **Anwendung**: Aufgaben-Scheduling, Dijkstra-Algorithmus, Event-Simulation
- **Performance**: O(log n) für Insert/Delete, O(1) für Peek

### Huffman-Kodierung

- **Prinzip**: Häufige Zeichen erhalten kurze Codes, seltene längere
- **Präfix-Eigenschaft**: Kein Code ist Präfix eines anderen
- **Kompressionsrate**: Abhängig von Häufigkeitsverteilung der Zeichen

## Implementierungs-Hinweise

### Heap-Methoden

- **Add**: Element am Ende hinzufügen, dann "heapify up"
- **Pop**: Wurzel mit letztem Element tauschen, entfernen, dann "heapify down"
- **Heapify Up**: Nach oben percolieren bis Heap-Eigenschaft erfüllt
- **Heapify Down**: Nach unten percolieren mit kleinerem/grösserem Kind

### Huffman-Implementierung

1. **Häufigkeiten zählen**: Dictionary oder ähnliche Struktur
2. **Priority Queue**: Min-Heap für Knoten nach Häufigkeit
3. **Baum-Konstruktion**: Iterativ zwei kleinste Knoten kombinieren
4. **Code-Generierung**: Rekursive Tiefensuche mit Bit-String-Aufbau

## Weiterführende Themen

- Binomial-Heaps und Fibonacci-Heaps für bessere Performance
- Adaptive Huffman-Kodierung für Stream-Daten
- Priority Queue in Graphalgorithmen (Dijkstra, Prim)
- Heap-Sort als Sortieralgorithmus