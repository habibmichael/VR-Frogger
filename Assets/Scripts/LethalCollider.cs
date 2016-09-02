using UnityEngine;
using System.Collections;

public class LethalCollider : MonoBehaviour {

	void OnCollisionEnter(Collision collision )
    {
        GameState state = FindObjectOfType<GameState>();
        Player player = FindObjectOfType<Player>();
        if (collision.collider == player.GetComponent<CapsuleCollider>())
        {
            state.isGameOver = true;
        }

        
    }
}
