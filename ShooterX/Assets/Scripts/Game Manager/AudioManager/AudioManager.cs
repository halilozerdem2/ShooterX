using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // Bu, farklý seslerin tutulacaðý liste
    public List<Sound> sounds;

    void Awake()
    {
        // AudioManager singleton'ý kuruyoruz
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Sahne deðiþse bile yok olmasýn
        }
        else
        {
            Destroy(gameObject);
        }

        // Listedeki her ses için AudioSource ekliyoruz
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
            Debug.LogWarning("Ses bulunamadý: " + soundName);
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