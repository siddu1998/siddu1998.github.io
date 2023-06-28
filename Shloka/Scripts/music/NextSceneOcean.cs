using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOcean : MonoBehaviour
{
    // Start is called before the first frame update

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Mudras");
    }
}
