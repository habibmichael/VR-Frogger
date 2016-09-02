using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

public void resetGame ()
    {
        SceneManager.LoadScene("Main");
    }

public void back2MainMenu ()
    {
        SceneManager.LoadScene("SplashScreen");
    }
}
