using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class ButtonSound : MonoBehaviour
{
    public AudioClip clickSound;
    [Range(0f,1f)] 
    public float volume = 1f;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

    }
        
    public void PlayClickSound()
    {
        if (clickSound == null) return;

        audioSource.PlayOneShot(clickSound, volume);
    }
}
