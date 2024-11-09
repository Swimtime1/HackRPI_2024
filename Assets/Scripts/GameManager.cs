using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables

    [Header("Game Flow")]
    [SerializeField] private bool gameStarted;
    [SerializeField] private bool gameActive;

    [Header("Menus")]
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject endMenu;

    #endregion Variables
    
    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        gameActive = false;
        
        OpenStart();
    }

    // Closes the Start Menu and starts the game
    public void StartGame()
    {
        gameStarted = true;
        gameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Menus

    // Closes every menu
    public void CloseMenus()
    {
        startMenu.SetActive(false);
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);
    }

    // Opens the Start Menu
    public void OpenStart()
    {
        CloseMenus();
        startMenu.SetActive(true);
    }

    #endregion Menus
}
