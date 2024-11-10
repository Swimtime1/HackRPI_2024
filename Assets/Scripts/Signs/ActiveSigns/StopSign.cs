using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour
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
        // Assigns point for stopping at the Stop Sign
        if(Car.inRange && !GameManager.gameActive && !GameManager.gamePaused && !pointGiven)
        {
            string str = "Spectacular!";
            gm.DisplayMessage(str);
            pointGiven = true;
            gm.UpdateScore();
            Destroy(gameObject);
        }

        // Player didn't stop
        if(!pointGiven && (zoomOutSign.transform.position.x <= Car.xPos))
        {
            string str = "Uh-oh! You blew a \"Stop Sign\"!";
            gm.DisplayMessage(str);
            gm.OpenEnd();
            Destroy(gameObject);
        }
    }
}
