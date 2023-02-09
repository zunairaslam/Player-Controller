using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepAudio : MonoBehaviour
{
    AudioSource footStep;
    



    // Start is called before the first frame update
    void Start()
    {
        footStep= transform.parent.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        footStep.Play();
    }
}
