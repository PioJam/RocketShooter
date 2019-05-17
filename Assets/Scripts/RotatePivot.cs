using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePivot : MonoBehaviour
{
    void Update()
    {
            Touch touch = Input.GetTouch(0);
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, touchPos - transform.position);
    }
}
