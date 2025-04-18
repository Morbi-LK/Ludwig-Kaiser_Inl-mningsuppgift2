using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour
{
    private const int MAX_SPAWN = 14;

    [SerializeField] private Transform[] _spawnHolders;

    private List<Transform> _spawnPoints = new();
    private List<SpawnObject> _spawnObjects = new();
    private WorldGenerator _worldGenerator;

    public void AssignWorldGenerator(WorldGenerator generator) 
    {
        _worldGenerator = generator;
        GatherSpwnPoints();
    }

    private void GatherSpwnPoints() 
    {
        foreach (var holder in _spawnHolders) 
        {
            foreach(Transform point in holder.GetComponentInChildren<Transform>()) 
            {
                _spawnPoints.Add(point);
            }
        }
    }

    public void ReGenerateFolliage() 
    {
        foreach(var obj in _spawnObjects) 
        {
            _worldGenerator.ReturnSpawnObject(obj);
        }
        _spawnObjects.Clear();

        var count = 0;
        foreach (Transform t in _spawnPoints) 
        {
            if (count >= MAX_SPAWN)
                return;

            var value = UnityEngine.Random.Range(0, 100);
            if(value > 60) 
            {
                var obj = _worldGenerator.GetSpawnObject(t);
                _spawnObjects.Add(obj);
                count++;
            }
        }
    }
}
