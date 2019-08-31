using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeOut : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(DoFade());
    }
    IEnumerator DoFade ()
    {
        yield return new WaitForSeconds(4);
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha>0)
        {
            canvasGroup.alpha -= Time.deltaTime / 5;
            yield return null;
        }
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Credits");
        canvasGroup.interactable = false;
        yield return null;
    }

}
