using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconController : MonoBehaviour {

    private List<Joycon> joycons;
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;

    [SerializeField]
    private float offset = 0.5f;
    private PlayerController playerController;

    private Quaternion rotationOrigin;

    private void Start() {
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1) {
            Destroy(gameObject);
        }
        playerController = GetComponent<PlayerController>();
        rotationOrigin = transform.rotation;
    }
    private void FixedUpdate() {
        if (joycons.Count > 0) {
            Joycon j = joycons[jc_ind];
            if (j.GetButtonDown(Joycon.Button.SHOULDER_2)) {
                playerController.Attack();
            }
            orientation = j.GetVector();
            orientation.x += offset;
            transform.rotation = orientation;
        }
    }
}