using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    [SerializeField]
    private Text textScore;

    private void Update() {
        int score = GamePlayManager.Instance.GetScore();
        if (score >= 0) {
            textScore.text = "Score : " + score;
        }
    }
}
