using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Decoration : MonoBehaviour {

    [SerializeField]
    private GameObject balloonDeco;
    [SerializeField]
    private int numberBalloonDeco = 300;
    [SerializeField]
    private float x = 15f;
    [SerializeField]
    private float y = 5f;
    [SerializeField]
    private float z = 5f;

    private int currentNumber = 0;
    private float currentX = 0f;
    private float currentY = 0f;
    private float currentZ = 0f;
    [ExecuteInEditMode]
    private void Update() {
        if(numberBalloonDeco != currentNumber || x != currentX || y != currentY || z != currentZ) {
            foreach (Transform child in transform) {
                GameObject.DestroyImmediate(child.gameObject);
            }
            Vector3 position = Vector3.zero;
            for (int i = 0; i < numberBalloonDeco; i++) {
                GameObject obj = Instantiate(balloonDeco, transform);
                var renderer = obj.GetComponent<Renderer>();
                var temMaterial = new Material(renderer.sharedMaterial);
                temMaterial.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
                renderer.sharedMaterial = temMaterial;
                position = new Vector3(Random.Range(-x, x) / 2, Random.Range(-y, y) / 2, Random.Range(-z, z) / 2);
                obj.transform.localPosition = position;
            }
            currentNumber = numberBalloonDeco;
            currentX = x;
            currentY = y;
            currentZ = z;
        }
    }

}
