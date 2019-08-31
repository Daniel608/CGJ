using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SwordAnim : MonoBehaviour
{
    Animator anim;
    KeyCode key;

    bool timeractive;
    byte timer = 50;

    private void Start()
    {
        anim = GetComponent<Animator>();
        key = GameHandler.Instance.atkKey;
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            timeractive = true;
            anim.Play("Attack");
        }

        if (timeractive)
        {
            timer--;
            if (timer == 0)
            {
                anim.Play("New State");
                timer = 50;
                timeractive = false;
            }
        }
    }
}
