using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private CardboardHead gazeTestHead;
    public Text gazeText;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        
        //add handler for trigger events
        Cardboard.SDK.OnTrigger += PullTrigger;

        gazeTestHead = FindObjectOfType<CardboardHead>();
        rb = GetComponent<Rigidbody>();
	}

    private void PullTrigger ()
    {
        //Allows character to jump with each trigger pull
        rb.AddForce(gazeTestHead.Gaze.direction*1000);
    }

    // Update is called once per frame
    void Update () {

        gazeText.text = gazeTestHead.Gaze.ToString();
	}
}
