using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera theCam;
    public Transform targetPos;

    public BoxCollider2D areaBox;
    private float halfW, halfH;
    // Start is called before the first frame update
    void Start()
    {
        theCam = GetComponent<Camera>();
        targetPos = PlayerMovement.instance.transform;

        halfH = theCam.orthographicSize;
        halfW = theCam.orthographicSize * theCam.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(targetPos.position.x, targetPos.position.y, transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, areaBox.bounds.min.x + halfW, areaBox.bounds.max.x - halfW), 
            Mathf.Clamp(transform.position.y, areaBox.bounds.min.y + halfH, areaBox.bounds.max.y - halfH), transform.position.z);
    }
}
