using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private SO_Sound _sound;

    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();

        _sound.PlaySound(_source);
    }


}
