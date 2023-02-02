using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundList soundList;
    Dictionary<string, AudioSource> sources;

    static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        sources = new Dictionary<string, AudioSource>();

        foreach (Sound sound in soundList.sounds)
        {
            sources.Add(sound.name, CreateAudioSource(sound));
        }
    }

    AudioSource CreateAudioSource(Sound sound)
    {
        AudioSource ad = gameObject.AddComponent<AudioSource>();
        ad.clip = sound.clip;
        ad.volume = sound.volume;
        ad.pitch = sound.pitch;
        ad.loop = sound.loop;

        return ad;
    }


    public void Play(string name)
    {
        sources[name].Play();
    }

    public void Stop(string name)
    {
        sources[name].Stop();
    }


}
