using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName; // Sesin ad�
    public AudioClip clip; // Ses dosyas�

    [Range(0f, 1f)]
    public float volume = 0.7f; // Ses seviyesi

    [Range(0.1f, 3f)]
    public float pitch = 1f; // Ses perdesi

    public bool loop = false; // Ses tekrar etsin mi

    private AudioSource source; // Sesin kaynak component'i

    // Ses kayna��n� ayarlamak i�in
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
    }

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
}