using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainLocomotion : MonoBehaviour
{
    [Header("Test values")]
    [SerializeField] private bool TestValues = false;
    [SerializeField] private bool Forwards = false;
    [SerializeField] private bool Backwards = false;
    [Header("End of test")]

    [SerializeField] private float speed = 5f;

    private int direction = 0;

    public void Forward()
    {
        direction = 1;
    }
    public void Backward()
    {
        direction = -1;
    }
    public void Stop()
    {
        direction = 0;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TestValues)
        {
            if (Forwards)
                direction = 1;
            else if (Backwards)
                direction = -1;
            else
                direction = 0;
        }
        {
            transform.position += Vector3.forward * direction * speed * Time.deltaTime;
        }
    }
}
