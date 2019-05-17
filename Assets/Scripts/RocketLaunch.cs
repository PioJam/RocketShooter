using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{
    public Transform firePoint;
    public Rocket rocket;

    void Update()
    {
        Invoke("LaunchOnMouseClick", 0.0001f);
    }
    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Rocket rocketClone = Instantiate(rocket, firePoint.position, firePoint.rotation);
            rocketClone.maxReach = Input.mousePosition.y;
        }
    }
}
