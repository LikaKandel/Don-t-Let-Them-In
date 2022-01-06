using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float panSpeed = 30f;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    private float scrollSpeed;
    private bool doMovement = true;

    private void LateUpdate()
    {
        if (GameManager.GameEnded)
        {
            this.enabled = false;
            return;
        }
        if (Input.GetKey(KeyCode.Escape)) doMovement = !doMovement;
        if (!doMovement) return;

        if (transform.position.z <= minZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
        }
        if (transform.position.z >= maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
        }

        if (transform.position.x <= minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
    }
    void Update()
    {   //
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //
        //Vector3 pos = transform.position;
        //
        //pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        //pos.y = Mathf.Clamp(pos.z, minY, maxY);
        //
        //transform.position = pos;
        

    }

   
}
