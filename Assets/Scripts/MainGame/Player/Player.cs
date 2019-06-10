using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private bool isDead = false;

   // private Action<object> OnGameOverHandler;

    [SerializeField]
    private PlayerMovement playerMovement;

	// Use this for initialization
	void Start ()
    {
        // OnGameOverHandler = _ => OnGameOverHandle();
        this.RegisterListener(EventID.OnGameStart, _ => OnGameStartHandle());
        this.RegisterListener(EventID.OnGameOver, _ => OnGameOverHandle());
	}

    private void OnGameStartHandle()
    {
        if (!isDead)
        {
            float side = Input.GetAxisRaw("Horizontal");

            playerMovement.GoForward();

            playerMovement.Rotate();
            //playerMovement.Rotate(side);
        }
    }

    private void OnGameOverHandle()
    {
        isDead = true;
        Destroy(gameObject);
        Debug.Log("GameOver");
    }

    // Update is called once per frame
    private void Update ()
    {
        OnGameStartHandle();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Missile")
        {
            this.PostEvent(EventID.OnGameOver);
        }
    }
}
