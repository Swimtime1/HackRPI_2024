using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    #region Variables

    [Header("Positions")]
    [SerializeField] private Vector2 gameStartPos;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 endPos;

    [Space(10)]
    [SerializeField] private float speed;

    [Header("Other GameObjects")]
    [SerializeField] private SpawnManager spawnManager;

    #endregion Variables
    
    // Start is called before the first frame update
    void Start()
    {
        // set the current location to gameStartPos
        transform.position = gameStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Prevents background from moving while the game isn't active
        if(!GameManager.gameActive) { return; }
        
        // Resets the position to the far right if the far left was reached
        if(transform.position.x <= endPos.x) 
        { 
            transform.position = startPos;

            // if this is the zoomedoutsign, spawns a new sign
            if(gameObject.name == "ZoomedOutSign") { spawnManager.SpawnRandomSign(); }
        }

        // Moves this GameObject to the left
        else { transform.Translate(Vector3.left * speed * Time.deltaTime); }
    }
}
