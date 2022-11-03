using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Simple Audio Manager to play/stop a given sound from a Sound Array.
    /// </summary>

    #region Variables

    private static AudioManager _instance;
    public Sound[] sounds;

    #endregion

    // Declare Audio Manager Singleton instance.
    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }

    #region Functions

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.isLoop;            
        }
    }

    private void OnEnable()
    {
        // subscribe to Flower Grow State Event
        Flowers.State.FlowerGrowState.flowerHasGrownSound += Play;
    }

    private void OnDisable()
    {
        // unsubscribe to Flower Grow State Event
        Flowers.State.FlowerGrowState.flowerHasGrownSound -= Play;
    }

    private void Start()
    {
        // TODO: add background music / noise
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound == null)
        {
            Debug.LogError("Sound " + name + " not found!");
            return;
        }

        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound == null)
        {
            Debug.LogError("Sound " + name + " not found!");
            return;
        }

        sound.source.Stop();
    }

    #endregion
}
