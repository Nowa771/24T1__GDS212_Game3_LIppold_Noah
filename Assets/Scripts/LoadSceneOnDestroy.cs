using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnDestroy : MonoBehaviour
{
    public int sceneBuildIndex = 1;  

    void OnDestroy()
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}






