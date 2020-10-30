using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
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

    public void AddCash(int amountOfCash)
    {
        score += amountOfCash;
        points.text = score.ToString();
    }

    public void SetCash()
    {
        points.text = score.ToString();
    }

    public bool PlaceTower (int AmountOfCashRequired)
    {
        if (score - AmountOfCashRequired >= 0)
        {
            score -= AmountOfCashRequired;
            SetCash(); //Update GUI
            return true;
        }
        else
        {
            return false;
        }
    }
}
