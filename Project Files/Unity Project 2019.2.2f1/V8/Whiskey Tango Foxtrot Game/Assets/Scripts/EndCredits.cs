using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndCredit());
    }

    IEnumerator EndCredit ()
    {
        yield return new WaitForSeconds(40);
        SceneManager.LoadScene("First Menu");
        yield return null;
    }
}
