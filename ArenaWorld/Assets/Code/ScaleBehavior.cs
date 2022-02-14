using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBehavior : MonoBehaviour
{
    public bool doShrink = false;
    public bool doEnlarge = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ShrinkLaser")
        {
            Debug.Log("Shrink Engaged");
        } 

        if (other.tag == "EnlargeLaser")
        {
            Debug.Log("Enlarge Engaged");
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ShrinkLaser")
        {
            Debug.Log("Shrink Finished");
            this.transform.localScale = new Vector3 (0.01f, 0.01f, 0.01f);
            doShrink = true;
            doEnlarge = false;
        } 

        if (other.tag == "EnlargeLaser")
        {
            Debug.Log("Enlarge Finished");
            this.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
            doEnlarge = true;
            doShrink = false;
        } 
    }
}
