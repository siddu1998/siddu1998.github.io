using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Music;
public class ShrinkOnClick : MonoBehaviour
{
    public float shrinkSpeed = 0.5f;
    public Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f);
    public ManagerforMusic dialogueManager;
    public Diagformusic newDialogue;
    public GameObject teleport;
    public GameObject trash;

    private bool isShrinking = false;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isShrinking)
            {
                StartCoroutine(ShrinkAnimation());
            }
        }
    }

    private IEnumerator ShrinkAnimation()
    {
        isShrinking = true;
        while (transform.localScale.x > targetScale.x && Input.GetMouseButton(0))
        {
            transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed) * Time.deltaTime;
            yield return null;
        }
        isShrinking = false;
         if (transform.localScale.x <= targetScale.x)
        {
            dialogueManager.StartNewDialogue(newDialogue);
            trash.SetActive(false);
            teleport.SetActive(true);
        }
    }
}
