using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    [Header("Itemler Sahnede Olmalı (Görünmeyen Bir yerde)")]
    [SerializeField] private Transform[] _items;

    [Header("SpawnPointler Sahnede olmalı")]
    [SerializeField] private List<Transform> _spawnPoints;

    private void Awake()
    {
        foreach (Transform item in _items)
        {
            if (_spawnPoints.Count <= 0) return;

            Transform spawn = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            item.position = spawn.transform.position;

            _spawnPoints.Remove(spawn);
        }
    }
}
