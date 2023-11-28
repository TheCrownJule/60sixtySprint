using Unity.VisualScripting;
using UnityEngine;


public class SFXManager : MonoBehaviour
{
    public Hashmap soundHashMap; // Reference to the HashMap script
    private AudioSource audioSource;
    public static SFXManager SFXinstance;

    private void Awake()
    {
        SFXinstance = this;
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {

    }

    // Play sound based on the button press
    public void PlaySound(string soundKey)
    {
        AudioClip sound = soundHashMap.GetSound(soundKey);

        if (sound != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }

    // Method to set the volume for a specific sound --- took out this method bc it also doesnt work 

    // Method to stop a specific sound based on the provided key -------- doesnt work tho idk why 
    public void StopSound(string soundKey)
    {
        
        // Check if the sound is currently playing
        if (audioSource.clip != null && audioSource.clip.name == soundKey)
        {
            audioSource.Stop();
            Debug.Log("sound should stop now");
        }
    }
}