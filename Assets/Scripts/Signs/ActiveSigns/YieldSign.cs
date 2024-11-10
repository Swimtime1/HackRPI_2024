using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YieldSign : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject truck;
    [SerializeField] private bool yielded;
    private int isCar;

    #endregion Variables
    
    // Start is called before the first frame update
    void Start()
    {
        // allows randomness of oncoming cars existing
        isCar = Random.Range(0, 1);
        if(isCar == 1) { Destroy(truck); }

        yielded = false;
    }

    // Update is called once per frame
    void Update()
    {
        // the car yielded if they stopped while in range
        if(Car.inRange && !GameManager.gameActive) { yielded = true; }

        // Determines if the player yielded in time
        if(truck && (truck.transform.position.x < Car.xPos))
        {
            if(yielded)
            {
                Debug.Log("Successfully Yielded");
            }
            else { Debug.Log("Failed to yield"); }
        }
    }
}
