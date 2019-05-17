using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationAutoDestroy : MonoBehaviour
{
    public float delay = 0f;

    void Update()
    {
        delay++;
        if (delay == 100f)
        {
            Destroy(this.gameObject);
        }
    }
}
