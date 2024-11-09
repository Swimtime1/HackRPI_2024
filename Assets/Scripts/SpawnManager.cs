using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Variables

    [Header("Prefabs")]
    [SerializeField] private GameObject[] signPrefabs;

    [Header("Time")]
    [SerializeField] private float startDelay;
    [SerializeField] private float spawnInterval;

    [Header("Location")]
    [SerializeField] private Vector2 spawnPos;

    #endregion Variables

    // Called when the Start Menu is closed
    public void StartSpawn()
    {
        InvokeRepeating("SpawnRandomSign", startDelay, spawnInterval);
    }

    // Instantiates a new sign
    private void SpawnRandomSign()
    {
        // Prevents spawning while the game isn't active
        if(!GameManager.gameActive) { return; }

        // Removes all previous signs
        foreach(Transform child in transform) { Destroy(child.gameObject); }
        
        int index = Random.Range(0, signPrefabs.Length);
        GameObject toSpawn = signPrefabs[index];
        Instantiate(toSpawn, spawnPos, toSpawn.transform.rotation, gameObject.transform);
    }
}
