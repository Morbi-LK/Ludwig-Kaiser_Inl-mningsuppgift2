using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCole : MonoBehaviour, Respawnable

{
    public Action OnConsume;
    [SerializeField] private GameObject Cole;
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Furnace"))
        {
            Debug.Log("Cole Consumed");
            gameObject.SetActive(false);
            transform.position = initialPosition;
            OnConsume?.Invoke();
            
        }
    }

    public void OnRespawn()
    {
        initialPosition = transform.position;
    }
}
