using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver {
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<TValue> values = new List<TValue>();
    [SerializeField] private string newKey;
    public void OnBeforeSerialize() {
    }

    public void OnAfterDeserialize() {
        for (int i = 0; i < keys.Length; i++) {
            _dictionary.Add(keys[i], values[i]);
        }
    }

    public IEnumerator<KeyValuePair<K, T>> GetEnumerator() {
        return ((IEnumerable<KeyValuePair<K, T>>)_dictionary).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return ((IEnumerable)_dictionary).GetEnumerator();
    }
}
