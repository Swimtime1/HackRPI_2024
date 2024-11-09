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
    
    /* // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */

    // Called when the Start Menu is closed
    public void StartSpawn()
    {
        InvokeRepeating("SpawnRandomSign", startDelay, spawnInterval);
    }

    // Instantiates a new sign
    private void SpawnRandomSign()
    {}
}
