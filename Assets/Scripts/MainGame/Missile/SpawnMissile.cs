using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissile : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private GameObject[] missiles;

    [SerializeField]
    private Transform MissileParent;

    private float currentTime;

    [SerializeField]
    private float nextSpawnTime = 10f;
    private float allowSpawnTime;

    [SerializeField]
    private int maxSpawnedMissile = 5;

    private bool isPlayerDead;
    // Use this for initialization
    void Start()
    {
        currentTime = 0f;
        allowSpawnTime = 5f;
        isPlayerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        if (!isPlayerDead)
        {
            currentTime += Time.deltaTime;
            if (currentTime > allowSpawnTime && MissileParent.childCount < maxSpawnedMissile)
            {
                StartCoroutine(Spawn());

                allowSpawnTime = currentTime + nextSpawnTime;
            }
        }
        else
        {
            isPlayerDead = true;
            this.PostEvent(EventID.OnGameOver);
        }
       
    }

    private Vector3 RandomSpawnPosition()
    {
        float heightLimit = Camera.main.orthographicSize * 2;
        float widthLimit = heightLimit * Screen.width / Screen.height;

        return target.position + new Vector3(Random.Range(-widthLimit, widthLimit), heightLimit, 0f);
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);

        Vector3 spawnMissilePosition = RandomSpawnPosition();

        GameObject newMissile = Instantiate(missiles[Random.Range(0, missiles.Length)], spawnMissilePosition, Quaternion.Euler(0f, 0f, 180f), MissileParent);
    }
}
