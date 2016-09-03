using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    private Player player;
    public float UIDistance=5f;
    public float UIHeight = 2f;
    private LevelState state;
    private Canvas canvas;

	// Use this for initialization
	void Start () {
       canvas =   gameObject.GetComponent<Canvas>();
        canvas.enabled = false;
        player = GameObject.FindObjectOfType<Player>();
        state = GameObject.FindObjectOfType<LevelState>();
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

        //If game over set up heads up display
        if (state.isGameOver)
        {
            trackPlayerhead();
            canvas.enabled = true;

        }
	}
    void trackPlayerhead ()
    {
        transform.rotation = Quaternion.LookRotation(player.lookDirection());
        transform.position = player.transform.position;
        transform.position += player.lookDirection() * UIDistance;
        transform.position += Vector3.up * UIHeight;
    }
}
