using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/Audio Data")]
public class AudioData : ScriptableObject
{
    public string key;
    public AudioClip clip;
    public float volume = 1f;
    public bool loop = false;
}
