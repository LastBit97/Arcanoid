using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _awake;
    [SerializeField] private AudioClip _collision;


    public void PlaySoundAwake()
    {
        if (SoundController.Instance.IsSoundOn())
        {
            _audioSource.PlayOneShot(_awake);
        }
    }

    public void PlaySoundCollision()
    {
        if (SoundController.Instance.IsSoundOn())
        {
            _audioSource.PlayOneShot(_collision);
        }
    }
}
