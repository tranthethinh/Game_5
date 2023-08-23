using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public static float masterVolume = 1.0f; // Default volume value (can be adjusted in the Inspector)

    private static VolumeManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
