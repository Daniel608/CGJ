using UnityEngine;

/*
 *
 * USAGE
 * If there's a class Test.cs
 * Replace Monobehaviour by Singleton<Test>
 * If you want to access Test's data from another class you can do it globally Test.Instance.variablename
 * If you want to write an awake function for test override it
 * This script will become global
 * 
 */

//T is the class we'll convert to singleton
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //The instance of our class
    public static T Instance { get; protected set; }

    //It's protected so it you want to write awake code in the class just override it
    protected virtual void Awake()
    {
        //If instance doesn't exist
        if (Instance == null)
        {
            //Set the instance
            Instance = GetComponent<T>();
            //Make it not destroy in scene change
            DontDestroyOnLoad(gameObject);
        } else
        {
            //Destroy any additional crap
            Destroy(gameObject);
        }
    }
}
