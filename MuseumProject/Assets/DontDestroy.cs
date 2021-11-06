using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] string NextScene = "History";
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene(NextScene);
    }
}
