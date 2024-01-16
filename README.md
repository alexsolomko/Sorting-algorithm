## Bubble Sort

**Komplexität:**
- Im besten Fall: O(n) - Das Array ist bereits sortiert.
- Im schlechtesten Fall: O(n^2) - Unsortiertes Array.
- Im Durchschnittsfall: O(n^2).

**Beschreibung:**
Der Algorithmus durchläuft das Array mehrmals und vergleicht dabei jedes Paar aufeinanderfolgender Elemente. Wenn sie in der falschen Reihenfolge stehen, werden sie vertauscht.

**Implementierung:**
```csharp
static void BubbleSort(int[] _arr)
{
    int n = _arr.Length;
    bool swapped;

    for (int i = 0; i < n - 1; i++)
    {
        swapped = false;

        for (int j = 0; j < n - i - 1; j++)
        {
            if (_arr[j] > _arr[j + 1])
            {
                Swap(_arr, j, j + 1);
                swapped = true;
            }
        }

        // Wenn im Inneren keine beiden Elemente vertauscht wurden, ist das Array bereits sortiert
        if (!swapped)
            break;
    }
}
```

## Selection Sort

**Komplexität:**
- Im besten Fall: O(n^2) - Unsortiertes Array.
- Im schlechtesten Fall: O(n^2) - Unsortiertes Array.
- Im Durchschnittsfall: O(n^2).

**Beschreibung:**
Der Algorithmus unterteilt das Array in zwei Teile: sortiert und unsortiert. In jedem Schritt wird das Minimum im unsortierten Teil ausgewählt und mit dem ersten Element im unsortierten Teil vertauscht.

**Implementierung:**
```csharp
static void SelectionSort(int[] _arr)
{
    for (int i = 0; i < _arr.Length - 1; i++)
    {
        int minIndex = i;

        for (int j = i + 1; j < _arr.Length; j++)
        {
            if (_arr[j] < _arr[minIndex])
            {
                minIndex = j;
            }
        }

        Swap(_arr, i, minIndex);
    }
}
```

## Insertion Sort

**Komplexität:**
- Im besten Fall: O(n) - Das Array ist bereits sortiert.
- Im schlechtesten Fall: O(n^2) - Unsortiertes Array.
- Im Durchschnittsfall: O(n^2).

**Beschreibung:**
Der Algorithmus konstruiert den sortierten Teil des Arrays, indem er in jedem Schritt ein Element aus dem unsortierten Teil hinzufügt.

**Implementierung:**
```csharp
static void InsertionSort(int[] _arr)
{
    for (int i = 1; i < _arr.Length; i++)
    {
        int key = _arr[i];
        int j = i - 1;

        while (j >= 0 && _arr[j] > key)
        {
            _arr[j + 1] = _arr[j];
            j--;
        }

        _arr[j + 1] = key;
    }
}
```
