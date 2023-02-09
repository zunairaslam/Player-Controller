using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Pool;

public class InstantiatePosition : MonoBehaviour
{
    public Transform position;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        GameObject cube = ObjectPooling.instance.GetObjectFromPool();
        if (cube != null)
        {
            cube.transform.position = position.transform.position;
            cube.transform.rotation = position.transform.rotation;
            cube.SetActive(true);
        }
    }
}
