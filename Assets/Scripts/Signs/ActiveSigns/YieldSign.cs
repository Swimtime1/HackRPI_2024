using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YieldSign : MonoBehaviour
{
    #region Variables

    [Header("Other Objects")]
    [SerializeField] private GameObject truck;
    [SerializeField] private GameManager gm;
    
    [Header("Misc.")]
    [SerializeField] private bool yielded;
    [SerializeField] private int isCar;

    #endregion Variables
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.DisplayMessage("");
        
        // allows randomness of oncoming cars existing
        isCar = Random.Range(0, 2);
        if(isCar == 1) { Destroy(truck); }

        yielded = false;
    }

    // Update is called once per frame
    void Update()
    {
        // the car yielded if they stopped while in range
        if(Car.inRange && !GameManager.gameActive && !GameManager.gamePaused) 
        { yielded = true; }

        // Determines if the player yielded in time
        if(truck && (truck.transform.position.x < Car.xPos))
        {
            string str;
            
            if(yielded)
            {
                str = "Nice Job!";
                gm.UpdateScore();
            }
            else
            {
                str = "Uh-oh! Remember, at a yield sign the other car has the right of way! Stop for them!";
                gm.OpenEnd();
                Destroy(gameObject);
            }

            gm.DisplayMessage(str);
        }
    }
}
