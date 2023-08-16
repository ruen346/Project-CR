using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private Dictionary<string, AudioClip> bgmAudioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> soundAudioClips = new Dictionary<string, AudioClip>();

    private AudioSource bgmAudioSource;
    
    public enum Bgm
    {
        Lobby
    }
    
    public enum Sound
    {
        TouchButton
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

    public void PlaySound()
    {
        
    }
}
