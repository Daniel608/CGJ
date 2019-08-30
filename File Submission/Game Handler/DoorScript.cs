using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public bool isMultiple;
    // If we're using multiple doors or just one
    bool activated;

    GameObject button;
    public GameObject door, text;
    public GameObject[] doors;

    private void Start()
    {
        button = gameObject;
        door.SetActive(false);
        text.SetActive(false);
        if (isMultiple)
        {
            foreach (GameObject dor in doors)
            {
                dor.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (activated)
        {
            door.SetActive(true);

            if (isMultiple)
            {
                foreach (GameObject dor in doors)
                {
                    dor.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.SetActive(true);
            Debug.Log("Entered the trigger");
            if (Input.GetKey("e"))
            {
                activated = true;
                door.SetActive(true);
                text.SetActive(false);
                if (isMultiple)
                {
                    foreach (GameObject dor in doors)
                    {
                        dor.SetActive(true);
                    }
                }
                button.SetActive(false);
            }
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }
}
