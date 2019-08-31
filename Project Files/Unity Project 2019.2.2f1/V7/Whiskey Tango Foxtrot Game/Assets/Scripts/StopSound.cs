using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sound.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
