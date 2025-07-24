using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public string[] spawnTags = { "Red", "Green", "Blue" };
    public Transform[] spawnPoints;

    [SerializeField]
    private float spawnRate = 2f;

    void Start() {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine() {
        while (GameManager.Instance != null && !GameManager.Instance.gameOver) //GameOver Check
        {
            string randomTag = spawnTags[Random.Range(0, spawnTags.Length)];
            Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];

            ObjectPooler.Instance.SpawnFromPool(randomTag, randomSpawn.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}

