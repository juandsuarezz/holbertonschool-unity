using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Triggers the timer to start when the player begins to move</summary>
public class TimerTrigger : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            other.gameObject.GetComponent<Timer>().enabled = true;
        }
    }
}
