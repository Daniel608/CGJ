using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
    public Stats playerStats;
    public GameObject player;
    public string mainMenuSceneName;
    public KeyCode atkKey;

    private Image healthBar;
    private int playerCooldown;

    protected override void Awake()
    {
        base.Awake();

        Init();
    }

    private void Init()
    {
        healthBar = GameObject.Find("HP").GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        if (playerCooldown > 0) playerCooldown--;
    }

    private void Update()
    {
        player = player ?? GameObject.FindWithTag("Player");

        if(healthBar == null)
        {
            Init();
        }

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerStats.health / playerStats.maxHealth,
            Time.deltaTime * 2f);

        if (healthBar.fillAmount <= Mathf.Exp(-4))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            playerStats.health = playerStats.maxHealth;
            StartCoroutine(SetPlayer());
        }

        if(Input.GetKeyDown(atkKey) && SceneManager.GetActiveScene().name != mainMenuSceneName && playerCooldown == 0)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();

            foreach(Enemy e in enemies)
            {
                if (Vector2.Distance(player.transform.position, e.gameObject.transform.position) < 2f)
                {
                    e.stats.health -= playerStats.damage;
                    playerCooldown = 60;
                }

                player.GetComponent<Movement>().animator.SetTrigger("Attack");
            }
        }
    }

    IEnumerator SetPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        player = GameObject.FindWithTag("Player");
    }

    public bool GroundedCheck(Vector2 pos, LayerMask platforms)
    {
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down, 0.6f, platforms);
        return hit.collider != null;
    }
}