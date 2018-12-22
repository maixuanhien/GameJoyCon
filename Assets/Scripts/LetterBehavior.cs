using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehavior : MonoBehaviour {

    [SerializeField]
    private float maxVelocity = 4f;
    [SerializeField]
    private int hp = 1;

    private Rigidbody rigibody;
    private float vitesse = 0f;

    public Renderer letterRenderer;

    private void Start() {
        rigibody = GetComponent<Rigidbody>();
    }

    public void SetData() {
        rigibody = GetComponent<Rigidbody>();
        vitesse = maxVelocity;
        rigibody.velocity = new Vector3(0, -vitesse, 0);
    }

    public void AddDamage(int damage) {
        hp = hp - damage;
        if (hp <= 0) {
            Debug.Log("call add score - letter");
            GamePlayManager.Instance.AddScore(false, null, gameObject.name);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == Constants.TAG_GROUND) {
            gameObject.SetActive(false);
        }
    }
}
