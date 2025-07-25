using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledObject {
    public string tag;
    public GameObject prefab;
    public int size;
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    public List<PooledObject> objectsToPool;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (PooledObject item in objectsToPool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < item.size; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(item.tag, objectPool);
        }
    }

    // void Start() {
    //     poolDictionary = new Dictionary<string, Queue<GameObject>>();

    //     foreach (PooledObject item in objectsToPool) {
    //         Queue<GameObject> objectPool = new Queue<GameObject>();

    //         for (int i = 0; i < item.size; i++) {
    //             GameObject obj = Instantiate(item.prefab);
    //             obj.SetActive(false);
    //             objectPool.Enqueue(obj);
    //         }

    //         poolDictionary.Add(item.tag, objectPool);
    //     }
    // }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
    public void ResetAllPooledObjects()//reset all pooled objects at gameover
    {
        foreach (var pool in poolDictionary.Values) {
        foreach (GameObject obj in pool) {
            obj.SetActive(false);
        }
    }
}
}

