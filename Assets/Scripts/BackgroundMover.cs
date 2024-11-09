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
        // Resets the position to the far right if the far left was reached
        if(transform.position.x <= endPos.x) { transform.Translate(startPos); }

        // Moves this GameObject to the left
        else { transform.Translate(startPos); }
    }
}
