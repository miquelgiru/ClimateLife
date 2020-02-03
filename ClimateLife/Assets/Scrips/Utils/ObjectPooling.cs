using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Instance
    public static ObjectPooling Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    public List<Pool> Pools;

    // Start is called before the first frame update
    void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; ++i)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.tag, objectPool);
        }
    }

   public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rot)
    {

        if (!PoolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " does not exist");
            return null;
        }

        GameObject toSpawn = PoolDictionary[tag].Dequeue();

        toSpawn.SetActive(true);
        toSpawn.transform.position = pos;
        toSpawn.transform.rotation = rot;

        PoolDictionary[tag].Enqueue(toSpawn);

        return toSpawn;
    }
}
