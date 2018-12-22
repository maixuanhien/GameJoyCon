using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoController : MonoBehaviour {

    [SerializeField]
    private GameObject balloon;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private SpawnController spawn;

    private List<Color> listColor;
    private List<GameObject> listBalloon;

    private void Start() {
        listColor = new List<Color>();
        listColor.Add(Color.blue);
        listColor.Add(Color.cyan);
        listColor.Add(Color.green);
        listColor.Add(Color.red);
        listColor.Add(Color.yellow);
        listBalloon = new List<GameObject>();
        Vector3 position = Vector3.zero;
        foreach(Color color in listColor) {
            GameObject obj = Instantiate(balloon, transform);
            listBalloon.Add(obj);
            obj.transform.localPosition = position;
            position.x = position.x + distance;
            var balloonController = obj.GetComponent<BalloonBehavior>();
            balloonController.balloonRenderer.material.color = color;
            var balloonRigibody = obj.GetComponent<Rigidbody>();
            balloonRigibody.useGravity = false;
            balloonRigibody.isKinematic = true;
        }
    }
    private void Update() {
        foreach(GameObject obj in listBalloon) {
            if(obj == null) {
                listBalloon.Remove(obj);
            }
        }
        if (listBalloon.Count == 0) {
            spawn.enabled = true;
        }
    }
}
