using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    #region Variables

    [SerializeField] private float speed;
    [SerializeField] private GameObject pauseMenu;

    #endregion Variables
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("Pause Menu");
    }
    
    // Update is called once per frame
    void Update()
    {
        // Only runs if the game is not paused
        if(!pauseMenu.activeSelf)
        { transform.Translate(Vector3.left * speed * Time.deltaTime); }
    }
}
