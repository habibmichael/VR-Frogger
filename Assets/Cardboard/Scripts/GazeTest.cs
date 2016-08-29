using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GazeTest : MonoBehaviour {

    private CardboardHead gazeTestHead;
    public Text gazeText;
	// Use this for initialization
	void Start () {
        Cardboard.SDK.OnTrigger += PullTrigger;
        gazeTestHead = FindObjectOfType<CardboardHead>();
	}

    private void PullTrigger ()
    {
        print("Trigger pulled");
    }

    // Update is called once per frame
    void Update () {

        gazeText.text = gazeTestHead.Gaze.ToString();
	}
}
