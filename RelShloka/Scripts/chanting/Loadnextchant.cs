using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadnextchant : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collided with the boundary object
        if (collision.CompareTag("Boundry"))
        {
            // Load another level or perform any desired actions
            SceneManager.LoadScene("trash");
        }
    }
}
