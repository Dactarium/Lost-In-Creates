using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundPlayer : MonoBehaviour
{
    [SerializeField] private SO_Sounds _sounds;
    [SerializeField] private float _playRate;
    [SerializeField] private float _playRateRandomGap;

    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();

        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(Random.Range(_playRate - _playRateRandomGap, _playRate + _playRateRandomGap));
        _sounds.PlaySound(_source);

        StartCoroutine(Play());
    }

}
