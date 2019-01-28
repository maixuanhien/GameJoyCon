using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    [SerializeField]
    private float rotationSpeed = 5f;

    private Quaternion rotationOrigin;
    private PlayerController player;

    private void Start()
    {
        rotationOrigin = transform.rotation;
        player = GetComponent<PlayerController>();
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(-y, x, 0) * rotationSpeed);
        if(Input.GetMouseButtonDown(1)){
            transform.rotation = rotationOrigin;
        }
        if(Input.GetMouseButtonDown(0)){
            player.Attack();
        }
    }
}
