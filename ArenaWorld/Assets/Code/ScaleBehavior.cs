using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "ShrinkLaser")
        {
            Debug.Log("Shrink Engaged");
        } 

        if (other.name == "EnlargeLaser")
        {
            Debug.Log("Enlarge Engaged");
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "ShrinkLaser")
        {
            Debug.Log("Shrink Finished");
            this.transform.localScale = new Vector3 (0.01f, 0.01f, 0.01f);
        } 

        if (other.name == "EnlargeLaser")
        {
            Debug.Log("Enlarge Finished");
            this.transform.localScale = new Vector3 (0.5f, 0.5001f, 0.5f);
        } 
    }
}
