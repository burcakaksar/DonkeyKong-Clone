using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] public AudioClip[] clips;

    #region Singleton
    public static SoundManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWithIndex(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }
}
