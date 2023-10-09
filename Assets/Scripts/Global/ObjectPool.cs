using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public string tag;
        public UnityEngine.GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<UnityEngine.GameObject>> poolDictionary;

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<UnityEngine.GameObject>>();
        foreach (var pool in pools)
        {
            Queue<UnityEngine.GameObject> objectPool = new Queue<UnityEngine.GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                UnityEngine.GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.prefab.name, objectPool);
        }
    }

    public UnityEngine.GameObject SpawnFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        UnityEngine.GameObject obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);

        return obj;
    }
}