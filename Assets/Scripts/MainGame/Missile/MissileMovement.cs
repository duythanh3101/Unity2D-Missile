using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateSpeed = 200f;
    [SerializeField] private GameObject sparks;
    [SerializeField] private GameObject ExplosionEffect;
    [SerializeField, Range(0f, 0.1f)]
    private float sparksTime = 0.05f;

    private Rigidbody2D MissileRigid;
    private bool isPlayerDead = false;

    private void Start ()
    {
       // this.PostEvent(EventID.OnGameStart);
        MissileRigid = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	private void Update ()
    {
        if (!isPlayerDead)
        {
            RotateAndMoveFoward();

            StartCoroutine(SpraySparks());
        }
       
    }

    private void RotateAndMoveFoward()
    {
        if (MissileRigid == null && target == null)
            return;

        Vector2 direction = (Vector2)target.position - MissileRigid.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        MissileRigid.angularVelocity = -rotateAmount * rotateSpeed;

        MissileRigid.velocity = transform.up * speed;
    }

    private IEnumerator SpraySparks()
    {
        if(gameObject)
        {
            yield return new WaitForSeconds(sparksTime);
            GameObject newSpark = Instantiate(sparks, gameObject.transform.position, sparks.transform.rotation, this.transform);
            Destroy(newSpark, 4f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Missile")
        {           
            GameObject explosion = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            isPlayerDead = true;
            this.PostEvent(EventID.OnGameOver);
            Destroy(gameObject);
        }
    }
}
