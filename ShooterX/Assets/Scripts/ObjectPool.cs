using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    
    [SerializeField] private List<GameObject> pooledBulletObjects;
    [SerializeField] private GameObject objectTooPool;
    [SerializeField] private int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        pooledBulletObjects = new List<GameObject>();
        GameObject bullet;
        for (int i = 0; i < amountToPool; i++)
        {
            bullet=Instantiate(objectTooPool);
            bullet.SetActive(false);
            pooledBulletObjects.Add(bullet);
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledBulletObjects[i].activeInHierarchy)
            {
                return pooledBulletObjects[i];
            }
        }
        return null;
    }

}
