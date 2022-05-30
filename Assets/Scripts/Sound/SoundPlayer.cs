using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private SO_Sound _sound;
    [SerializeField] private SO_Sound _deepSound;
    [SerializeField] private SO_Sound _insideSound;

    private AudioSource _source;

    private SnapshotController.Area _currentArea = SnapshotController.Area.Outside;
    private void Start()
    {
        _source = GetComponent<AudioSource>();

        _sound.PlaySound(_source);
    }

    public void ChangeArea(SnapshotController.Area area)
    {
        if (_currentArea == area) return;
        _currentArea = area;
        switch (area)
        {
            case SnapshotController.Area.Deep:
                StartCoroutine(_deepSound.TransitionTo(_source));
                break;

            case SnapshotController.Area.Inside:
                StartCoroutine(_insideSound.TransitionTo(_source));
                break;

            default:
                StartCoroutine(_sound.TransitionTo(_source));
                break;
        }
    }

}
