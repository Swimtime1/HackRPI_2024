using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoParkingSign : MonoBehaviour
{
    #region Variables

    [Header("Other Objects")]
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject zoomOutSign;

    [Space(20)]
    [SerializeField] private bool pointGiven = false;

    #endregion Variables
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        zoomOutSign = GameObject.Find("ZoomedOutSign");

        gm.DisplayMessage("");
    }

    // Update is called once per frame
    void Update()
    {
        // the car yielded if they stopped while in range
        if(Car.inRange && !GameManager.gameActive && !GameManager.gamePaused)
        {
            string str = "Uh-oh! Don't park near a \"No Parking\" sign!";
            gm.DisplayMessage(str);
            gm.OpenEnd();
            Destroy(gameObject);
        }

        // Assigns point for not parking in a No Parking Zone
        if(!pointGiven && (zoomOutSign.transform.position.x <= Car.xPos))
        {
            string str = "Awesome!";
            gm.DisplayMessage(str);
            pointGiven = true;
            gm.UpdateScore();
        }
    }
}
