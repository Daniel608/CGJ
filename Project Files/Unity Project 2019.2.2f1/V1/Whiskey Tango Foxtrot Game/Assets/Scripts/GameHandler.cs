using UnityEngine;
using UnityEngine.SceneManagement;

//The base class for game progression
public class GameHandler : Singleton<GameHandler>
{
    //The speed
    public float speed;

    //Check if it can move
    public bool canMove = true;

    #region TitleScreen

    //The first scene's name
    public string LevelSceneName;

    /// <summary>
    /// Plays the game
    /// </summary>
    public void Play()
    {
        //Load the first scene
        SceneManager.LoadScene(LevelSceneName);
    }

    /// <summary>
    /// Exits the game
    /// </summary>
    public void Exit()
    {
        //Quit the game
        Application.Quit();
    }

    #endregion
}