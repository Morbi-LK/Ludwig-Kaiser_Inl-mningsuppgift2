using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [Header("Range of motion")]
    [SerializeField] private float max = 25f;
    [SerializeField] private float min = -25f;
    private float CurrentRange;

    private void CalculateRange()
    {
        //calculate correct range of the lever
        CurrentRange = Mathf.Clamp(CurrentRange, min ,max);
    }
    public float GetRange()
    {
        //returns value of range
        return 0f;
    }

    // Start is called before the first frame update
    void Start()
    {        
    }
    // Update is called once per frame
    void Update()
    {       
    }
}
