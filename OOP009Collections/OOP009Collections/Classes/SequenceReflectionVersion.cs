using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class SequenceReflectionVersion : IEnumerable<int>
{
    public SequenceReflectionVersion(IEnumerator<int> enumerator)
    {
        CurrentEnumerator = enumerator;
    }

    public IEnumerator<int> CurrentEnumerator { get; set; }

    public IEnumerator<int> GetEnumerator()
    {
        return (IEnumerator<int>)CurrentEnumerator.GetType().GetConstructor(Type.EmptyTypes).Invoke(null);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

