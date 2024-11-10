using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    #region Variables

    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer sprite;

    #endregion Variables
    
    // Start is called before the first frame update
    void Start()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        sprite.color = new Color(r, g, b);
    }
    
    // Update is called once per frame
    void Update()
    {
        // Only runs if the game is not paused
        if(!GameManager.gamePaused)
        { transform.Translate(Vector3.left * speed * Time.deltaTime); }
    }
}
