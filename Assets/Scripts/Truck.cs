using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    #region Variables

    [SerializeField] private float speed;

    #endregion Variables
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        Debug.Log("Truck Update Called");
    }
}