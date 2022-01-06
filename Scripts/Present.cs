using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    private float speed = 10f;
    [SerializeField] private float startPresentDuration;
    private float presentDuration;
    [SerializeField] private float xWaySpot = 15f;

    private Vector3 target;
    private Vector3 TargetToFollow;

    private void Start()
    {
        target = transform.position;
        TargetToFollow = new Vector3(target.x + xWaySpot, target.y, target.z);
        presentDuration = startPresentDuration;

    }
    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
        if (presentDuration > 0f) presentDuration -= Time.deltaTime;
        else
        {
            Destroy(gameObject);
            presentDuration = startPresentDuration;
        }

        if (transform.position.x >= target.x + xWaySpot)
        {
            transform.position = new Vector3(10f, target.y,  target.z);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        PlayerStats.Money += 50;
    }
}
