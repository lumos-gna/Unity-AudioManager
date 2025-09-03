using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;


public class AudioManager : MonoBehaviour
{
    private const string AudioDataPath = "Audio";
    
    private Dictionary<string, AudioData> _audioDictionary;
    private ObjectPool<AudioManagedSource> _audioPool;
    private void Awake()
    {
        _audioDictionary = Resources.LoadAll<AudioData>(AudioDataPath).ToDictionary(x => x.key);

        _audioPool = new ObjectPool<AudioManagedSource>(
            createFunc: CreateAudioSource,
            actionOnGet: EnableAudioSource,
            actionOnRelease: DisableAudioSource,
            actionOnDestroy: (source) => Destroy(source.gameObject)
        );
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Play("Test");
        }
    }

    public void Play(string key)
    {
        if (_audioDictionary.ContainsKey(key))
        {
            var audioObj = _audioPool.Get();
            audioObj.Play(_audioDictionary[key]);
        }
    }

    AudioManagedSource CreateAudioSource()
    {
        var sourceObj = new GameObject("AudioSource");
        
        var audioSource = sourceObj.AddComponent<AudioSource>();
        
        var audioManagedSource = sourceObj.AddComponent<AudioManagedSource>();
        audioManagedSource.Init(audioSource, _audioPool);
        
        return audioManagedSource;
    }
    
    private void EnableAudioSource(AudioManagedSource source)
    {
        source.gameObject.SetActive(true);
    }

    private void DisableAudioSource(AudioManagedSource source)
    {
        source.gameObject.SetActive(false);
    }
}
