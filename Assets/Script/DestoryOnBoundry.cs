using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnBoundry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // ReturnObjectToPool();
    }
    
    
       private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Boundry")
            {
                gameObject.SetActive(false);
            }
            
        }
    
    
}
