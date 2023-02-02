using UnityEngine;

[CreateAssetMenu(fileName = "SoundList", menuName = "AudioManager/SoundList", order = 0)]
public class SoundList : ScriptableObject {
    public Sound[] sounds;
}

[System.Serializable]
public class Sound {
    public string name;
    public AudioClip clip;
    [Range(0, 1)]public float volume = 1f;
    [Range(0, 2)]public float pitch = 1f;

    public bool loop;
}
