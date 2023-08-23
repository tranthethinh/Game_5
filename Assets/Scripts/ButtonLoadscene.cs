using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonLoadscene : MonoBehaviour
{
    public int sceneToLoad;
    private void Start()
    {
        // Attach a listener to the button's click event
        GetComponent<Button>().onClick.AddListener(SetSceneId);
    }
    void SetSceneId()
    {
        LoadSceneByIndex(sceneToLoad);
    }
    private void LoadSceneByIndex(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
