using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YieldSign : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject truck;

    #endregion Variables
    
    // Start is called before the first frame update
    void Start()
    {
        // allows randomness of oncoming cars existing
        /* if(Random.Range(0, 1) == 1) { Destroy(truck); } */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
