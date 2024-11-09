using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region Variables

    [Header("Game Flow")]
    public static bool gameStarted;
    public static bool gameActive;

    [Header("Menus")]
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject endMenu;

    [Header("Other Managers")]
    [SerializeField] private SpawnManager spawnManager;

    private InputActions input;

    #endregion Variables
    
    // Called when the game is loaded
    private void Awake()
    {
        input = new InputActions();
    }
    
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

        CloseMenus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Input
    
    // Called when the script is enabled
    private void OnEnable()
    {
        input.Enable();
        input.UI.CloseStart.performed += OnStartPerformed;
        input.UI.TogglePause.performed += OnPausePerformed;
        input.Car.Stop.performed += OnStopPerformed;
    }

    // Called when the script is disabled
    private void OnDisable()
    {
        input.Disable();
        input.UI.CloseStart.performed -= OnStartPerformed;
        input.UI.TogglePause.performed -= OnPausePerformed;
        input.Car.Stop.performed -= OnStopPerformed;
    }

    // Called when any of the binds associated with CloseStart in input are used
    private void OnStartPerformed(InputAction.CallbackContext context)
    {
        // only opens the level selection menu if the start menu is active
        if(startMenu.activeSelf)
        {
            StartGame();
            spawnManager.StartSpawn();
        }
    }

    // Called when any of the binds associated with Stop in input are used
    private void OnStopPerformed(InputAction.CallbackContext context)
    {
        // Toggles whether the game is active
        if(gameStarted && !pauseMenu.activeSelf)
        {
            gameActive = !gameActive;
        }
    }

    // Called when any of the binds associated with TogglePause in input are used
    private void OnPausePerformed(InputAction.CallbackContext context)
    {
        // toggles the Pause Menu
        if(pauseMenu.activeSelf)
        {
            CloseMenus();
            gameActive = true;
        }
        else { OpenPause(); }
    }

    #endregion Input

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

    // Opens the Pause Menu
    public void OpenPause()
    {
        CloseMenus();
        gameActive = false;
        pauseMenu.SetActive(true);
    }

    // Opens the End Menu
    public void OpenEnd()
    {
        CloseMenus();
        endMenu.SetActive(true);
        gameActive = false;
    }

    #endregion Menus
}
