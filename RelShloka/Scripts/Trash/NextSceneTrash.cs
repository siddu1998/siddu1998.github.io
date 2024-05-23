using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrash : MonoBehaviour
{
    // Start is called before the first frame update

    public void LoadNextScene()
    {
        SceneManager.LoadScene("music");
    }
}
