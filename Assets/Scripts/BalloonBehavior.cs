using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBehavior : MonoBehaviour {

    [SerializeField]
    private readonly float maxVelocity = 4f;
    [SerializeField]
    private int hp = 1;

    private Rigidbody rigibody;
    private float vitesse = 0f;

    public Renderer balloonRenderer;

    private Color colorOrigin;

    private void Start() {
        rigibody = GetComponent<Rigidbody>();
    }

    public void SetData(Color color) {
        rigibody = GetComponent<Rigidbody>();
        vitesse = maxVelocity;
        rigibody.velocity = new Vector3(0, -vitesse, 0);
        balloonRenderer.material.color = color;
        colorOrigin = color;
    }

    public void AddDamage(int damage) {
        hp = hp - damage;
        if(hp <= 0) {
            GamePlayManager.Instance.AddScore(true, colorOrigin);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == Constants.TAG_GROUND) {
            gameObject.SetActive(false);
        }
    }
}
