using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeZone : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        var respawn = other.GetComponent<Respawnable>();
        if (respawn != null)
        {
            respawn.OnRespawn();
        }
    }
}
