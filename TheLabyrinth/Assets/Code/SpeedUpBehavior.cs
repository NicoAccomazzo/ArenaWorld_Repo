using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBehavior : MonoBehaviour
{
    public float BoostMultiplier = 2.0f;
    public float BoostSeconds = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Gotta Go Fast!");

            PlayerBehavior Player = other.gameObject.GetComponent<PlayerBehavior>();
            Player.BoostSpeed(BoostMultiplier, BoostSeconds);
        }
    }
}
