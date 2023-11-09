using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeAudio
{
    Background,
    LoseGame,
    CompletedGame,
    Other
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioSource audioSource;
    public AudioClip audioClip;
    [Range(0, 1f)] public float volume;
    [Range(0, 1f)] public float pitch;
    public bool isPlayOnAwake;
    public bool isLoop;
    public TypeAudio type;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<Sound> sounds;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;

        foreach (var s in sounds)
        {
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.isLoop;
            s.audioSource.playOnAwake = s.isPlayOnAwake;
            if (s.isPlayOnAwake)
                s.audioSource.Play();
        }
    }

    public void PlaySounds(TypeAudio typeAudio)
    {
        foreach (var sound in sounds)
        {
            if(sound.type == typeAudio)
            {
                sound.audioSource.Play();
            }
        }
    }
}
