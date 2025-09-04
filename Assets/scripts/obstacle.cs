using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public int index;
    private Scene _scene; // Declare the _scene variable

    void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) // Corrected casing of gameObject
        {
            SceneManager.LoadScene(index);
        }
    }
}
