using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 5f, -2.5f);
    public Vector3 camOffset1 = new Vector3(0f, 2f, -5f);
    public ScaleBehavior scaleBehavior;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);
        this.transform.LookAt(target);

        if (scaleBehavior.doShrink == true)
        {
            this.transform.position = target.TransformPoint(camOffset1);
            this.transform.LookAt(target);
        } 

        if (scaleBehavior.doEnlarge == true)
        {
            this.transform.position = target.TransformPoint(camOffset1);
            this.transform.LookAt(target);
        }
    }
}
