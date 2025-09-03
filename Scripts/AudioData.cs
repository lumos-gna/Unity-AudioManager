using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/AudioData")]
public class AudioData : ScriptableObject
{
    public AudioClip clip;

    [Space(10f)]
    public string key;
    public float volume = 1f;
    public bool loop = false;
}
