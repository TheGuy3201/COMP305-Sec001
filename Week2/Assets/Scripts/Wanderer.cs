using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class Wanderer : MonoBehaviour
{
    [SerializeField] List<GameObject> wayPoints = new List<GameObject>();
    [SerializeField] float epsilon = 1.2f;
    [SerializeField] float speed = 0.05f;
    [SerializeField] float delayTime = 0.01f;
    Vector2 movement = Vector2.zero;
    int currentTargetIndex = 0;
    Vector2 targetPosition;
    void Start()
    {
        StartCoroutine(MoveNPC());
    }

    void SelectWaypoint()
    {
        int newTargetIndex;
        do
        {
            newTargetIndex = Random.Range(0, wayPoints.Count);
        } while (newTargetIndex == currentTargetIndex);

        currentTargetIndex = newTargetIndex;
        targetPosition = wayPoints[currentTargetIndex].transform.position;
        //change the color of the npc
        GetComponent<SpriteRenderer>().material.color = wayPoints[currentTargetIndex].GetComponent<SpriteRenderer>().color;
    }

    IEnumerator MoveNPC()
    {
        while (true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
                { break; }
            //check the closeness to the target
            if (Vector2.Distance(transform.position, targetPosition) < epsilon)
            {
                SelectWaypoint();
            }
            //move towards the target
            transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            speed);
            //yield
            yield return new WaitForSeconds(delayTime);
        }
    }
}