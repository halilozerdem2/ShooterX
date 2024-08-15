using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    
    [SerializeField] private List<GameObject> pooledDefaultBullets;
    [SerializeField] private List<GameObject> pooledM4A1Bullets;
    
    [SerializeField] private GameObject M4A1Bullet;
    [SerializeField] private GameObject defaultBullet;
   
    [SerializeField] private int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        CreatePoolObjects();

    }

    public void CreatePoolObjects()
    {
        pooledM4A1Bullets = new List<GameObject>();
        GameObject bullet;
        for (int i = 0; i < amountToPool; i++)
        {
            bullet = Instantiate(M4A1Bullet);
            bullet.SetActive(false);
            pooledM4A1Bullets.Add(bullet);
        }
        
        pooledDefaultBullets = new List<GameObject>();
        GameObject aBullet;
        for (int i = 0; i < amountToPool; i++)
        {
            aBullet = Instantiate(defaultBullet);
            aBullet.SetActive(false);
            pooledDefaultBullets.Add(aBullet);
        }

    }

    public GameObject GetPooledM4A1Bullet()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledM4A1Bullets[i].activeInHierarchy)
            {
                return pooledM4A1Bullets[i];
            }
        }
        return null;
    }
    public GameObject GetDefaultBullets()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledM4A1Bullets[i].activeInHierarchy)
            {
                return pooledM4A1Bullets[i];
            }
        }
        return null;
    }

}
