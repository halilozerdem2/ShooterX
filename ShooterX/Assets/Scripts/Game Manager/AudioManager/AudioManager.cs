using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // Bu, farkl� seslerin tutulaca�� liste
    public List<Sound> sounds;

    void Awake()
    {
        // AudioManager singleton'� kuruyoruz
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Sahne de�i�se bile yok olmas�n
        }
        else
        {
            Destroy(gameObject);
        }

        // Listedeki her ses i�in AudioSource ekliyoruz
        foreach (Sound sound in sounds)
        {
            sound.SetSource(gameObject.AddComponent<AudioSource>());
        }
    }

    // Ses oynatma metodu
    public void Play(string soundName)
    {
        Sound sound = sounds.Find(s => s.soundName == soundName);
        if (sound != null)
        {
            sound.Play();
        }
        else
        {
            Debug.LogWarning("Ses bulunamad�: " + soundName);
        }
    }

    public void Stop(string soundName)
    {
        Sound sound = sounds.Find(s => s.soundName == soundName);
        if (sound != null)
        {
            sound.Stop();
        }
    }
}