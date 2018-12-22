using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private GameObject balle;
    [SerializeField]
    private float force = 10f;

    [SerializeField]
    private Material materialTarget;
    public Material materialOrigin;
    private Renderer balloonRenderer;
    private bool isTarget = false;

    [SerializeField]
    private Pooling pooling;

    private void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
            if (hit.collider.tag == Constants.TAG_BALLOON) {
                if (!isTarget) {
                    var balloonBehavior = hit.collider.GetComponent<BalloonBehavior>();
                    balloonRenderer = balloonBehavior.balloonRenderer;
                    materialOrigin = balloonRenderer.material;
                    balloonRenderer.material = materialTarget;
                    isTarget = true;
                }
            } else {
                if (isTarget) {
                    balloonRenderer.material = materialOrigin;
                    isTarget = false;
                }
            }
        } else {
            if (isTarget) {
                balloonRenderer.material = materialOrigin;
                isTarget = false;
            }
        }
    }

    public void Attack() {
        GameObject obj = pooling.Spawn(balle, transform.position, transform.rotation);
        var balleController = obj.GetComponent<BalleController>();
        balleController.SetData();
        obj.transform.forward = transform.forward;
        obj.GetComponent<Rigidbody>().velocity = obj.transform.forward * force;
    }
}
