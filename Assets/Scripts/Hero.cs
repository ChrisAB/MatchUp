﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private int healthPoints;
    private int maxHealthPoints;
    private int ultimateBarCharge;
    private int ultimateRequirement;
    private int name;

    public int HealthPoints {
        get { return healthPoints; }
        set { SetHealthPoints(value); }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetHealthPoints(int value) {
        healthPoints = value;
    }
}
