using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] int spawnObsAmount = 10;


    //private List<GameObject> objectPool = new List<GameObject>();

    MyList<GameObject> objectPool = new MyList<GameObject>(10);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (obstaclePrefab == null)
        {
            Debug.Log("Obs prefab didnt connected");
            return;
        }

        for (int i = 0; i < spawnObsAmount; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab);
            objectPool.Add(obstacle);
            obstacle.SetActive(false);

        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }
        return null;
    }

    public void DeActiveAllObstacles()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            objectPool[i].SetActive(false);
        }
    }
}
