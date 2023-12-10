using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public void goGame()
    {
        SceneManager.LoadSceneAsync("city2");
    }
}
