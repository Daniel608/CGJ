using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLVL : MonoBehaviour
{
    public int nextlvl;
    public GameObject text;
    public KeyCode interact;
    private void Start()
    {
        text.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.SetActive(true);
            if ((Input.GetKeyDown(interact)))
            {
                SceneManager.LoadScene(nextlvl);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}
