using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

/* USAGE
 *
 * MAKE WHATEVER KINDA UI YOU WANT
 *
 * BE SURE TO NAME UI TEXT GAME OBJECT "Tips"
 *
 * ATTACH THIS SCRIPT TO AN EMPTY GAME OBJECT
 */

public class Tips : MonoBehaviour
{
    public List<string> tips = new List<string>();
    public float nextTipTime = 10f;

    private Text tipText;

    private void Awake()
    {
        tipText = GameObject.Find("Tips").GetComponent<Text>();

        tipText.text = tips[Random.Range(0, tips.Count - 1)];
        StartCoroutine(ShowTip());
    }

    IEnumerator ShowTip()
    {
        yield return new WaitForSeconds(nextTipTime);

        tipText.text = tips[Random.Range(0, tips.Count - 1)];

        StartCoroutine(ShowTip());
    }
}
