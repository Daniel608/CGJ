using UnityEngine;
using System.Collections;

/* USAGE
 *
 * MAKE A TEXT CALLED "Power Text"
 *
 * CHANGE THE JUMP BOOST AND SPEED BOOST AND TIME TO SEE IT
 * 
 */
public class PowerUp : MonoBehaviour
{
    public float jumpBoost, speedBoost, timeForBoost = 10f;

    private GameObject powerText;
    private bool poweredUp;
    private float previousJump, previousSpeed;

    private void Awake()
    {
        powerText = GameObject.Find("Power Text");

        powerText.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Vector2.Distance(transform.position,
            GameHandler.Instance.player.transform.position) <= 2f && !poweredUp)
        {
            Movement movement = GameHandler.Instance.player.GetComponent<Movement>();
            previousJump = movement.jump;
            previousSpeed = movement.speed;
            movement.jump += jumpBoost;
            movement.speed += speedBoost;
            powerText.SetActive(true);
            StartCoroutine(Disappear(movement));
            poweredUp = true;
        }
    }

    IEnumerator Disappear(Movement movement)
    {
        yield return new WaitForSeconds(timeForBoost);
        powerText.SetActive(false);
        movement.speed = previousSpeed;
        movement.jump = previousJump;
        Destroy(gameObject);
    }
}
