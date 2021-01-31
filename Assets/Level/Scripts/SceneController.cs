using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    [HideInInspector] public static int NextSceneIndex = 1;
    public static void ChangeScene()
    {
        SceneManager.LoadScene(NextSceneIndex);
    }
}
