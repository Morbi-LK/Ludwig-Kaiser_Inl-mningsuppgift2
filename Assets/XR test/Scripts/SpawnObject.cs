using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject tree2;
    [SerializeField] private GameObject tree3;
    [SerializeField] private GameObject house;

    private GameObject LastActive = null;

    public void OnEnable()
    {
        var i = Random.Range(0, 5);

        if(LastActive != null)
            LastActive.SetActive(false);

        switch (i) 
        {
            case 0:
            case 1:
            LastActive = tree;
                break;
            case 2:
            LastActive = tree2;
                break;
            case 3:
            LastActive = tree3;
                break;
            case 4:
                LastActive = house;
                break;
            default:
                LastActive = house;
                break;
        }

        LastActive.SetActive(true);
        LastActive.transform.Rotate(Vector3.up, i * 25);
    }
}
