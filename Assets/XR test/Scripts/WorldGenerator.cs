using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    [SerializeField] private int _direction = 0;

    [SerializeField] private WorldTile WorldTile;
    [SerializeField] private List<WorldTile> _treadMill = new();
    [SerializeField] private SpawnObject spawnObjectPrefab;

    [SerializeField] private ButtonInteraction _forward;
    [SerializeField] private ButtonInteraction _stop;
    [SerializeField] private ButtonInteraction _backward;

    private List<SpawnObject> _activeObjects = new();
    private List<SpawnObject> _objectPool = new();

    private float _maxPos = 0;
    private float _minPos = 0;

    public void AssignDirection(int i)
    {
        if (i == 0)
            _direction = 0;
        else
            _direction += i;

        _direction = Mathf.Clamp(_direction, -5, 5);
    }

    private void Awake()
    {
        foreach (var tile in _treadMill)
        {
            tile.AssignWorldGenerator(this);
            tile.ReGenerateFolliage();
        }

        if (_treadMill.Count > 0)
        {
            _maxPos = _treadMill[0].transform.position.z;
            _minPos = _treadMill[_treadMill.Count - 1].transform.position.z;
        }

        _forward.OnClick += AssignDirection;
        _stop.OnClick += AssignDirection;
        _backward.OnClick += AssignDirection;
    }

    private void OnDestroy()
    {
        _forward.OnClick -= AssignDirection;
        _stop.OnClick -= AssignDirection;
        _backward.OnClick -= AssignDirection;
    }

    void FixedUpdate()
    {
        var moveDelta = Vector3.forward * Time.fixedDeltaTime * (Speed * _direction);

        foreach (var tile in _treadMill)
        {
            tile.transform.position += moveDelta;

            if(tile.transform.position.z > _maxPos) 
            {
                var newPos = tile.transform.position;
                newPos.z -= 607.5f;
                tile.ReGenerateFolliage();
                tile.transform.position = newPos;
            }
            else if (tile.transform.position.z < _minPos)
            {
                var newPos = tile.transform.position;
                newPos.z += 607.5f;
                tile.ReGenerateFolliage();
                tile.transform.position = newPos;
            }
        }
    }

    public SpawnObject GetSpawnObject(Transform parent)
    {
        if(_objectPool.Count > 0)
        {
            var spawnObj = _objectPool[0];
            _objectPool.RemoveAt(0);
            _activeObjects.Add(spawnObj);
            spawnObj.gameObject.SetActive(true);
            spawnObj.transform.SetParent(parent);
            spawnObj.transform.position = parent.position;
            return spawnObj;
        }

        var newspawnObj = Instantiate(spawnObjectPrefab);
        newspawnObj.transform.SetParent(parent);
        newspawnObj.transform.position = parent.position;
        _activeObjects.Add(newspawnObj);
        return newspawnObj;
    }

    public void ReturnSpawnObject(SpawnObject obj) 
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        _activeObjects.Remove(obj);
        _objectPool.Add(obj);
    }
}
