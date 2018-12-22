using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

    [SerializeField]
    private float delayTime = 2f;

    private void Start() {
        Destroy(gameObject, delayTime);
    }
}
