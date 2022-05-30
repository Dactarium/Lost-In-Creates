using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TriggerArea : MonoBehaviour
{
    [SerializeField] private SnapshotController.Area _area;
    [SerializeField] private SnapshotController _controller;
    [SerializeField] private SoundPlayer _soundPlayer;
    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _controller.ChangeArea(_area);
        _soundPlayer.ChangeArea(_area);
    }
}
