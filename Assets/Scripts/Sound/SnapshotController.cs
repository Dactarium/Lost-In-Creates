using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SnapshotController", menuName = "Sound/SnapshotController")]
public class SnapshotController : ScriptableObject
{
    [SerializeField] private AudioMixerSnapshot _deep;
    [SerializeField] private AudioMixerSnapshot _inside;
    [SerializeField] private AudioMixerSnapshot _outside;

    [SerializeField] private float _transitonTime;

    private Area _currentArea = Area.Null;
    public void ChangeArea(Area area)
    {
        if (_currentArea == area) return;

        switch (area)
        {
            case Area.Deep:
                _deep.TransitionTo(_transitonTime);
                break;
            case Area.Inside:
                _inside.TransitionTo(_transitonTime);
                break;
            case Area.Outside:
                _outside.TransitionTo(_transitonTime);
                break;
        }
    }

    public enum Area
    {
        Null,
        Deep,
        Inside,
        Outside
    }
}
