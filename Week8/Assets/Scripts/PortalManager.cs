using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("NightPortal"))
            {
                Debug.Log($"{other.gameObject.tag} has entered");
                SceneManager.LoadScene("NightScene");
            }
        }
    }
}