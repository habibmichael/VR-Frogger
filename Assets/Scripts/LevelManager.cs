using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void loadNextLevel ()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

}
