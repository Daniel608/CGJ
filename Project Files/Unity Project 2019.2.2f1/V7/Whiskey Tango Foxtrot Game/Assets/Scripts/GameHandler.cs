﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

[System.Serializable]
public class Stats
{
    public float maxHealth;
    public float health;
    public float damage;
}

//The base class for game progression
public class GameHandler : Singleton<GameHandler>
{
    public string lvl1;
    public string lvl2;
    public string lvl3;
    public Stats playerStats;
    public GameObject player;
    public string mainMenuSceneName;
    public KeyCode atkKey;
    public GameObject sword;
    Animator attack_anim;
    private Image healthBar;
    private int playerCooldown;

    bool timeractive;
    byte timer = 50;

    protected override void Awake()
    {
        base.Awake();
    }

    private void FixedUpdate()
    {
        if (playerCooldown > 0) playerCooldown--;
    }

    private void Update()
    {
        try
        {
            healthBar = GameObject.Find("HP").GetComponent<Image>();
            attack_anim = attack_anim ?? sword.GetComponent<Animator>();
        } catch (Exception e)
        {
            Debug.Log(e);
        }

        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerStats.health / playerStats.maxHealth,
                Time.deltaTime * 2f);

            if (healthBar.fillAmount <= Mathf.Exp(-4))
            {
                playerStats.health = playerStats.maxHealth;
                SceneManager.LoadScene(mainMenuSceneName);
                StartCoroutine(SetPlayer());
            }
        }

        IEnumerator SetPlayer()
        {
            yield return new WaitForSeconds(0.1f);
            player = GameObject.FindWithTag("Player");
        }

        if (timeractive == true)
        {
            timer--;
            if (timer == 0)
            {
                timeractive = false;
                timer = 50;
                //attack_anim.Play("New State");
            }
        }

        if (SceneManager.GetActiveScene().name == mainMenuSceneName)
        {
            if (GameObject.Find("Single") != null)
            {
                GameObject.Find("Single").GetComponent<Button>().onClick.AddListener(Play);
            }
            else if (GameObject.Find("PROBABLY") != null)
            {
                GameObject.Find("PROBABLY").GetComponent<Button>().onClick.AddListener(Exit);
            }
        }

        if (Input.GetKeyDown(atkKey) && SceneManager.GetActiveScene().name != mainMenuSceneName && playerCooldown == 0)
        {
            player = GameObject.FindWithTag("Player");

            Enemy[] enemies = FindObjectsOfType<Enemy>();

            //attack_anim.Play("Attack");
            timeractive = true;

            foreach(Enemy e in enemies)
            {
                if (Vector2.Distance(player.transform.position, e.gameObject.transform.position) < 2f)
                {
                    e.stats.health -= playerStats.damage;
                    playerCooldown = 60;
                }
            }
        }
    }

    public void Play ()
    {
        SceneManager.LoadScene(lvl1);
    }

    public void Credits ()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public bool GroundedCheck(Vector2 pos, LayerMask platforms)
    {
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down, 1f, platforms);
        return hit.collider != null;
    }
}