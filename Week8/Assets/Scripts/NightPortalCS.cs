using UnityEngine;
using UnityEngine.SceneManagement;
public class NightPortalCS : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //should ckeck if the 'other' object is the player
        Debug.Log($"{other.gameObject.tag} has entered");
        SceneManager.LoadScene("NightScene");
    }
}