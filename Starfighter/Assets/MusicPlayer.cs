using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField][Header("Scene Loading")]
    [Tooltip("This variable sets the amount of time before the first level is loaded")]
    private float timeToLoadLevel = 3f;

    [SerializeField]
    [Tooltip("This variable is the build index of the desired level for loading")]
    private int desiredBuildIndex = 1;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Invoke("LoadFirstScene", timeToLoadLevel);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(desiredBuildIndex); //scene 1 is the first level
    }
}
