using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPool Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool p in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < p.size; i++)
            {
                GameObject g = Instantiate(p.pref);
                g.SetActive(false);
                objectPool.Enqueue(g);
            }
            poolDictionary.Add(p.tag, objectPool);
        }
    }
    void Start () {

    }
    public GameObject GetFromPool(string tag, Vector3 position,Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            print(string.Format("Doesn't contain this tag: {0}", tag));
            return null;
        }
        GameObject g = poolDictionary[tag].Dequeue();
        g.SetActive(true);
        g.transform.position = position;
        g.transform.rotation = rotation;
        //should i use it this way?
       // poolDictionary[tag].Enqueue(g);
        if (g.GetComponent<IOnObjectSpawn>() != null)
            g.GetComponent<IOnObjectSpawn>().Spawnded();
        return g;
    }
    public void BackInBlack(string tag, GameObject g)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            print(string.Format("Doesn't contain this tag: {0}", tag));
            return;
        }
        g.SetActive(false);
        poolDictionary[tag].Enqueue(g);
    }
}
