using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    #region Variables

    [Header("Other Objects")]
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject zoomOutSign;
    [SerializeField] private Animation anim;
    [SerializeField] private SpriteRenderer stopSign;

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
        // Pauses animation when the game is paused
        if(GameManager.gamePaused) 
        {
            foreach (AnimationState state in anim)
            { state.speed = 0; }
        }
        else
        {
            foreach (AnimationState state in anim)
            { state.speed = 1; }
        }

        // Only checks after the car passes the stop sign
        if(zoomOutSign.transform.position.x > Car.xPos) { return; }
        
        // Assigns point for waiting at the Intersection
        if(!stopSign.enabled && GameManager.gameActive && !GameManager.gamePaused && !pointGiven)
        {
            string str = "Impressive!";
            gm.DisplayMessage(str);
            pointGiven = true;
            gm.UpdateScore();
            Destroy(gameObject);
        }

        // Player didn't stop, or started too soon
        else
        {
            string str = "Uh-oh! You ran a Red Light!";
            gm.DisplayMessage(str);
            gm.OpenEnd();
            Destroy(gameObject);
        }
    }
}
