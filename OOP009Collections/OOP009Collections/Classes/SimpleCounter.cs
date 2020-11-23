using System.Collections;
using System.Collections.Generic;

class SimpleCounter : IEnumerator<int>
{
    public int Current { get; set; } = 0;

    object IEnumerator.Current => Current;

    public void Dispose() { }

    public bool MoveNext()
    {
        Current++;
        return true;
    }

    public void Reset()
    {
        Current = 0;
    }
}

