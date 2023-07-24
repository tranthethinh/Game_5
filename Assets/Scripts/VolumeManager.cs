using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public static float masterVolume = 1.0f; // Default volume value (can be adjusted in the Inspector)

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // Ensures that this object persists across scene changes
    }
}
