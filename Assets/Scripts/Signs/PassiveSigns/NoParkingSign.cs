using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoParkingSign : MonoBehaviour
{
    #region Variables

    [Header("Other Objects")]
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject pauseMenu;

    #endregion Variables
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        pauseMenu = GameObject.Find("Pause Menu");

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
        }
    }
}
