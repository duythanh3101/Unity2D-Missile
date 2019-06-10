using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float rotateSpeed = 400f;
    [SerializeField]
    private Transform leftSide, rightSide;

    private Rigidbody2D playerRb2D;

    private void Start()
    {
        playerRb2D = GetComponent<Rigidbody2D>();
    }

    public void GoForward()
    {
        playerRb2D.velocity = transform.up * moveSpeed;
    }

    public void Rotate(float side)
    {
        Vector2 direction = new Vector2(0, 0);

        if (side != 0)
        {
            if (side < 0)
                direction = (Vector2)leftSide.position - playerRb2D.position;
            if (side > 0)
                direction = (Vector2)rightSide.position - playerRb2D.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            playerRb2D.angularVelocity = -rotateAmount * rotateSpeed;
        }
        else
        {
            playerRb2D.angularVelocity = 0;
        }
    }

    public void Rotate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
}