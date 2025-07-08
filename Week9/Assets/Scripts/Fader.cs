using System;
using System.Collections;
using UnityEngine;

public class Fader : MonoBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] float speed;
    string prop = "_Fade"; //Check in graph inspector for name


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(ShowImage());
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(HideImage());
        }
    }

    IEnumerator HideImage()
    {
        float fade = mat.GetFloat(prop);
        while (fade < 1)
        {
            fade += 0.1f;
            mat.SetFloat(prop, fade);
            yield return new WaitForSeconds(speed);
        }
    }

    IEnumerator ShowImage()
    {
        float fade = mat.GetFloat(prop);
        while (fade > 0)
        {
            fade -= 0.1f;
            mat.SetFloat(prop, fade);
            yield return new WaitForSeconds(speed);
        }
    }
}
