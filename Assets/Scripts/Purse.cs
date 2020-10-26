using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Purse : MonoBehaviour
{
    public TextMeshProUGUI points;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore()
    {
        score = score + 50;
        points.text = score.ToString();
    }
}
