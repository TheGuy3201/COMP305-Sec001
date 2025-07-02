using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class DayNightController : MonoBehaviour
{
    [SerializeField] Light2D ambient;
    [SerializeField] float ambientMax = 1;
    [SerializeField] float ambientMin = .02f;
    [SerializeField] Light2D sun;
    [SerializeField] float sunMax;
    [SerializeField] float sunMin;
    [SerializeField] float radius;
    [SerializeField] float timeSpeed = 0.2f;
    [SerializeField] float interval = 0.01f;
    public float angle = 0;
    public float intendedIntensity;
    void Start()
    {
        StartCoroutine(RunCycle());
    }
    IEnumerator RunCycle()
    {
        while (true)
        {
            angle += Time.deltaTime * timeSpeed;
            //calculate the new position of the sun
            float x = Mathf.Cos(angle) * 25;
            float y = Mathf.Sin(angle) * 15 - 8;
            sun.transform.position = new Vector3(x, y, 0);
            sun.intensity = Mathf.Clamp(Mathf.Sin(angle), ambientMin, ambientMax);
            //modify the intensity of the ambient light
            intendedIntensity = Mathf.Sin(angle) * ambientMax;
            ambient.intensity = Mathf.Clamp(intendedIntensity, ambientMin, ambientMax);
            yield return new WaitForSeconds(interval);
        }
    }
}