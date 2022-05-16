using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Sound[] sounds;
    void Awake()
    {
        foreach (Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;
            sound.source.outputAudioMixerGroup = sound.group;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.spatialBlend = sound.spatialBlend;
        }
    }

    public void play(string soundName) 
    {
        Sound sound = Array.Find(sounds, sound => sound.name == soundName);
        if (sound != null)
            sound.source.Play();
        else
            Debug.LogWarning("Sound: " + soundName + " was not found!");
    }
}
