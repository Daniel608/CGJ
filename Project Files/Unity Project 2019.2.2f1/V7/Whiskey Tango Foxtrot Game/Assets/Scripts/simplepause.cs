using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class simplepause : MonoBehaviour
{
    public bool isenabled;
    public GameObject pausePanel;

    void Start()
    {
        isenabled = false;
        pausePanel.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isenabled)
            {
                pausePanel.SetActive(false);
                isenabled = false;
            } else
            {
                pausePanel.SetActive(true);
                isenabled = true;
            }
        }
    }
}
