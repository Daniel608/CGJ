using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class Door : MonoBehaviour
{
    public string sceneToLoad;

    private bool canGo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canGo |= collision.CompareTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && canGo) SceneManager.LoadScene(sceneToLoad);
    }
}
