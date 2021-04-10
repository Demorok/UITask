using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] UserSettings userSettings;
    [SerializeField] AudioSource effectsSound;
    [SerializeField] AudioSource musicSound;

    static public Queue<AudioClip> effectsQueue = new Queue<AudioClip>();
    static public Queue<AudioClip> musicQueue = new Queue<AudioClip>();

    void Update()
    {
        Check_Effects_Queue();
        Check_Music_Queue();
    }

    void Check_Effects_Queue()
    {
        if (effectsQueue.Count > 0)
            effectsSound.PlayOneShot(effectsQueue.Dequeue(), userSettings.soundSettings.effectsVolume);
    }

    void Check_Music_Queue()
    {
        if (musicQueue.Count > 0)
        {
            musicSound.clip = musicQueue.Dequeue();
            musicSound.Play();
        }
        if (musicSound.volume != userSettings.soundSettings.musicVolume)
            musicSound.volume = userSettings.soundSettings.musicVolume;
    }
}
