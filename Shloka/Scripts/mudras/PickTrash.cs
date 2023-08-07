using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Talking;
using UnityEngine.UI;

public class PickTrash : MonoBehaviour
{
    public float shrinkSpeed = 0.01f;
    public Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f);
    public DiaglogueManager dialogueManager;
    public Diaglogue newDialogue;
    public Image filled;
    public GameObject KarmaChakra;
    public GameObject clouds;


    private bool isShrinking = false;
    private BoxCollider2D boxCollider;
    private static int count;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (filled.fillAmount == 0.33f){
                shrinkSpeed = 10f;
            }
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Check if the mouse position overlaps with the BoxCollider2D bounds.
            if (boxCollider.OverlapPoint(mousePosition))
            {
                if (!isShrinking)
                {
                    StartCoroutine(ShrinkAnimation());
                }
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
            count++;
            Debug.Log("Got Rid of" + count);
            clouds.SetActive(false);

            
            if (count == 4)
            {
                KarmaChakra.SetActive(true);
                dialogueManager.StartNewDialogue(newDialogue);
            }
            
        }
    }
}
