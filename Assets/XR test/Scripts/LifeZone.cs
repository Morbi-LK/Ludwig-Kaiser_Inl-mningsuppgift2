using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeZone : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        var repawn = other.GetComponent<Respawnable>();
        repawn.OnRespawn();
    }
}
