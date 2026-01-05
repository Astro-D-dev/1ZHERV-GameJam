using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpawn : MonoBehaviour
{
    public GameObject shadow;
    public float revealTime = 3f;
    private float timer = 0f;
    private bool beingLit = false;

    public GameObject endingScreen;

    public float minSpawnInterval = 20f;
    public float maxSpawnInterval = 30f;
    private float nextSpawnTime = 0f;

    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        if (beingLit)
        {
            timer += Time.deltaTime;
            
            if (timer >= revealTime)
            {
                ForceDeactivate(true);
            }
        }
        else
        {
            timer = 0f;
        }

        if (!shadow.activeSelf && Time.time >= nextSpawnTime)
        {
            SpawnShadow();
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void LateUpdate()
    {
        beingLit = false;
    }

    public void LitByFlashlight()
    {
        beingLit = true;
    }

    public void ForceDeactivate(bool reachedTime = false)
    {
        if (reachedTime && endingScreen != null)
        {
            endingScreen.SetActive(!endingScreen.activeSelf);
        }

        shadow.SetActive(false);
        timer = 0f;
    }

    public void SpawnShadow()
    {
        Camera cam = Camera.main;
        float xOffset = Random.Range(-1f, 1f);
        Vector3 spawnPos = new Vector3(cam.transform.position.x + xOffset, shadow.transform.position.y, 0f);
        shadow.transform.position = spawnPos;
        shadow.SetActive(true);
    }
}