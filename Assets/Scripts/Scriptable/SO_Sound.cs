using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Sound", menuName = "Sound/Sound")]
public class SO_Sound : ScriptableObject
{
    [SerializeField] private AudioClip _clip; //m�zik veya ses efektini buraya koyun
    [SerializeField] private SoundType _soundType; // tipini ayarlamak i�in
    [SerializeField] private AudioMixerGroup _group;

    private bool _isLoop = false;
    private bool _isOnAwaker = false;

    //Buras� preset ayar� i�in.
    private void OnEnable()
    {
        switch (_soundType)
        {
            case SoundType.Shot:
                _isLoop = false;
                _isOnAwaker = false;
                break;
            case SoundType.Loop:
                _isLoop = true;
                _isOnAwaker = true;
                break;
        }
    }
    /// <summary>
    /// �a�r�lacak objede mutlaka AudioSource bulunmal�d�r.
    /// </summary>
    /// <param name="source"></param>
    public void PlaySound(AudioSource source)
    {
        if (source.outputAudioMixerGroup != _group) source.outputAudioMixerGroup = _group;

        source.clip = _clip;
        source.loop = _isLoop;
        source.playOnAwake = _isOnAwaker;

        source.Play();
    }

    public IEnumerator TransitionTo(AudioSource source)
    {
        for (int i = 0; i < 5; i++)
        {
            source.volume -= 0.2f;
            yield return new WaitForSeconds(0.1f);
        }

        source.clip = _clip;
        source.loop = _isLoop;
        source.playOnAwake = _isOnAwaker;
        source.Play();

        for (int i = 0; i < 5; i++)
        {
            source.volume += 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private enum SoundType
    {
        Shot,
        Loop
    }
}