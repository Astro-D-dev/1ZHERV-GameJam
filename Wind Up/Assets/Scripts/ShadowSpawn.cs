using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpawn : MonoBehaviour
{
    public float revealTime = 3f;
    private float timer = 0f;
    private bool beingLit = false;

    public float spawnRadius = 2f;
    public float spawnCheckInterval = 1f;
    public float spawnChance = 0.07f;
    private float spawnTimer = 0f;

    public GameObject endingScreen;

    void Update()
    {
        if (beingLit)
        {
            timer += Time.deltaTime;
            if (timer >= revealTime)
                ForceDeactivate(true);
        }
        else
        {
            timer = 0f;
        }
        beingLit = false;

        if (!gameObject.activeSelf)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnCheckInterval)
            {
                spawnTimer = 0f;
                if (Random.value < spawnChance)
                    SpawnShadow();
            }
        }
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

        gameObject.SetActive(false);
        timer = 0f;
    }

    public void SpawnShadow()
    {
        Camera cam = Camera.main;
        Vector2 offset = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPos = cam.transform.position + new Vector3(offset.x, offset.y, 0f);
        gameObject.transform.position = spawnPos;
        gameObject.SetActive(true);
    }
}
