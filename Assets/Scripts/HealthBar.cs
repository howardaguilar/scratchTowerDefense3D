using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform anchor;

    void Awake()
    {
        {
            anchor = GetComponentInChildren<Transform>();
        }
    }

    public void Damage(int amountOfHealth, int totalHealth)
    {
        float healthPercentage = Mathf.Clamp(amountOfHealth / totalHealth, 0, 1); // check value is between 0 and 1
        anchor.localScale = new Vector3(healthPercentage, anchor.localScale.y, anchor.localScale.z);
    }
}
