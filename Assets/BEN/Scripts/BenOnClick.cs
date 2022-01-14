using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenOnClick : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource biteSound;
    public class AudioScript : MonoBehaviour
    {
        AudioSource audioSource;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            biteSound.Play();
        }
    }
}
