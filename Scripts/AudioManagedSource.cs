using System;
using UnityEngine;
using UnityEngine.Pool;

public class AudioManagedSource : MonoBehaviour
{
    private ObjectPool<AudioManagedSource> _pool;
    private AudioData _audioData;
    private AudioSource _audioSource;

    private bool _isEnabled;

    private void OnDisable()
    {
        _isEnabled = false;
        _audioSource.Stop();
    }

    private void LateUpdate()
    {
        if (_isEnabled)
        {
            if (!_audioSource.isPlaying)
            {
                _pool.Release(this);
            }
        }
    }
    
    
    public void Init(AudioSource audioSource, ObjectPool<AudioManagedSource> pool)
    {
        _audioSource = audioSource;
        _pool = pool;
    }

    public void Play(AudioData audioData)
    {
        _isEnabled = true;
        
        _audioData = audioData;
        _audioSource.clip = _audioData.clip;
        _audioSource.volume = _audioData.volume;
        _audioSource.loop = _audioSource.loop;
        _audioSource.playOnAwake = false;
        
        _audioSource.Play();
    }
}
