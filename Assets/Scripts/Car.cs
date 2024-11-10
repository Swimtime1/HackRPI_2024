using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    #region Variables

    public static bool inRange;
    public static bool tooClose;

    public static float xPos;

    #endregion Variables
    
    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        tooClose = false;
        xPos = this.transform.position.x;
    }

    // Called when the collider first overlaps another collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if(inRange) { tooClose = true; }
        else { inRange = true; }
    }

    // Called when the collider first overlaps another collider
    void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
        tooClose = false;
    }
}
