using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Sounds", menuName = "Sound/Sounds")]
public class SO_Sounds : ScriptableObject
{
    [SerializeField] private AudioClip[] _clips; //m�zik veya ses efektini buraya koyun
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

        source.clip = _clips[Random.Range(0, _clips.Length)];
        if (!source.clip) return;

        source.loop = _isLoop;
        source.playOnAwake = _isOnAwaker;

        source.Play();
    }

    private enum SoundType
    {
        Shot,
        Loop
    }
}