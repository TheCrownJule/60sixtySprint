using System;
using System.Collections.Generic;
using UnityEngine;


public class Hashmap : MonoBehaviour
{
    [SerializeField]
    private List<SoundEntries> soundEntries = new List<SoundEntries>();

    private Dictionary<string, AudioClip> soundTable = new Dictionary<string, AudioClip>();

    void Awake()
    {
        BuildSoundTable();
    }

    private void BuildSoundTable()
    {
        soundTable.Clear();

        foreach (var entry in soundEntries)
        {
            if (!soundTable.ContainsKey(entry.key))
            {
                soundTable.Add(entry.key, entry.sound);
            }
            else
            {
                Debug.LogWarning("Sound with key " + entry.key + " already exists in the hashtable.");
            }
        }
    }

    // Add sound entry to the list and rebuild the hashtable
    public void AddSoundEntry(string key, AudioClip sound)
    {
        soundEntries.Add(new SoundEntries { key = key, sound = sound });
        BuildSoundTable();
    }

    // Get sound from the hashtable
    public AudioClip GetSound(string key)
    {
        AudioClip sound;
        if (soundTable.TryGetValue(key, out sound))
        {
            return sound;
        }
        else
        {
            Debug.LogWarning("Sound with key " + key + " does not exist in the hashtable.");
            return null;
        }
    }
}
