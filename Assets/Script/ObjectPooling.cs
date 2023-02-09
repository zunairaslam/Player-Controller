using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    public List<GameObject> pooledCube;
    public GameObject cubeToPool;
    public int amountTopool;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        AddObjectToPool();
    }

    void AddObjectToPool()
    {
        pooledCube = new List<GameObject>();
        for (int i = 0; i < amountTopool; i++)
        {
            GameObject cube = (GameObject)Instantiate(cubeToPool);
            cube.SetActive(false);
            pooledCube.Add(cube);
        }
    }

    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < pooledCube.Count; i++)
        {
            
            if (!pooledCube[i].activeInHierarchy)
            {
                return pooledCube[i];
            }
        }
          
        return null;
    }
    
}
