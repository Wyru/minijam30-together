using UnityEngine;
public class SlimeSounds : MonoBehaviour
{
    [SerializeField] string death_clip = "death_slime";
    public void Death()
    {
        AudioManager.Instance.Play(death_clip);
    }
}
