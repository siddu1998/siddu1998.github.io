using UnityEngine;
using UnityEngine.UI;

public class PaintController : MonoBehaviour
{
    public LayerMask paintableLayer; // The layer that contains the objects to be deactivated

    private Camera mainCamera;
    public Image voicedown;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (voicedown.fillAmount >= 0.33f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DeactivateObjects();
            }
        }
        
    }

    private void DeactivateObjects()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, paintableLayer);

        if (hit.collider != null)
        {
            hit.collider.gameObject.SetActive(false);
        }
    }
}
