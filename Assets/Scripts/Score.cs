using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    public static int scoreType = 0;

    // Update is called once per frame
    void Update()
    {
        string scoreText=scoreType.ToString();
        score.text = "Score: " + scoreText + "/" + scoreText + " signs";

        
    }
}
