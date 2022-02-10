using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 5f, -2.5f);
    public Vector3 camOffset1 = new Vector3(0f, 2f, -5f);
    public Vector3 playerShrink = new Vector3(0.01f, 0.01f, 0.01f);
    public Vector3 playerEnlarge = new Vector3 (0.5f, 0.5001f, 0.5f);
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

        if (target.localScale == playerShrink)
        {
            this.transform.position = target.TransformPoint(camOffset1);
            this.transform.LookAt(target);
        }

        if (target.localScale == playerEnlarge)
        {
            this.transform.position = target.TransformPoint(camOffset1);
            this.transform.LookAt(target);
        }
    }
}
