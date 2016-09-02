using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private CardboardHead head;
    private Rigidbody rb;

    public float jumpSpeed;
    public float jumpAngleInDegrees;

    //game state
    private GameState state;

    //prevents flying effect
    private bool onGround;

    //fixes collision jump bug
    private float lastJumpRequestTime;

	// Use this for initialization
	void Start () {

        state = GameObject.FindObjectOfType<GameState>();
        
        //add handler for trigger events
        Cardboard.SDK.OnTrigger += PullTrigger;

        head = FindObjectOfType<CardboardHead>();
        rb = GetComponent<Rigidbody>();
	}

    

    private void PullTrigger ()
    {
        
        
            requestJump();
        

    }

    private void Jump ()
    {
        if (!state.isGameOver)
        {

            float jumpAngleInRadians = jumpAngleInDegrees * Mathf.Deg2Rad;
            Vector3 jumpVector = Vector3.RotateTowards(lookDirection(), Vector3.up, jumpAngleInRadians, 0);
            rb.velocity = jumpVector * jumpSpeed;
        }
    }

   public  Vector3 lookDirection ()
    {
        return Vector3.ProjectOnPlane(head.Gaze.direction, Vector3.up);
    }

    private void requestJump ()
    {
        lastJumpRequestTime = Time.time;
        rb.WakeUp();
    }

    void OnCollisionStay(Collision Collision )
    {
        float delta = Time.time - lastJumpRequestTime;
        if (delta < 0.05)
        {
            Jump();
            lastJumpRequestTime = 0.0f;
        }
    }
}
