using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    private int highScore;

	void Awake ()
    {
        DontDestroyOnLoad(gameObject);
    }

 public void updateHighScore(int score )
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }

    public int getHighScore () { return highScore; }


}
