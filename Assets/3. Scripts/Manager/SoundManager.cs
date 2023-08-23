using System.Collections.Generic;
using UnityEngine;

public class SoundManager : DontDestroySingleton<SoundManager>
{
    private Dictionary<string, AudioClip> bgmAudioClips = new();
    private Dictionary<string, AudioClip> soundAudioClips = new();

    private AudioSource bgmAudioSource;
    private List<AudioSource> soundAudioSources = new();
    
    public enum Bgm
    {
        Lobby
    }
    
    public enum Sound
    {
        Clear
    }

    public void PlayBgm(Bgm bgm)
    {
        if (bgmAudioSource == null)
        {
            bgmAudioSource = gameObject.AddComponent<AudioSource>();
            bgmAudioSource.loop = true;
            bgmAudioSource.volume = 0.3f;
        }
        
        string bgmString = bgm.ToString();
        
        if(!bgmAudioClips.ContainsKey(bgmString))
        {
            var audio = Resources.Load<AudioClip>($"Sound/Bgm/{bgmString}");
            bgmAudioClips.Add(bgmString, audio);
        }

        bgmAudioSource.clip = bgmAudioClips[bgmString];
        bgmAudioSource.Play();
    }

    public void PlaySound(Sound sound, float volume = 1f)
    {
        var source = GetEmptySource();
        
        if (source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
            soundAudioSources.Add(source);
        }
        
        string soundString = sound.ToString();
        
        if(!soundAudioClips.ContainsKey(soundString))
        {
            var audio = Resources.Load<AudioClip>($"Sound/Sound/{soundString}");
            soundAudioClips.Add(soundString, audio);
        }

        source.clip = soundAudioClips[soundString];
        source.volume = volume;
        source.Play();
    }

    private AudioSource GetEmptySource()
    {
        foreach (var source in soundAudioSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }
        
        var newSource = gameObject.AddComponent<AudioSource>();
        soundAudioSources.Add(newSource);
        
        return newSource;
    }
}
