using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    [SerializeField]
    private Text textScore;
    [SerializeField]
    private Text textTime;

    private void Update() {
        int score = GamePlayManager.Instance.GetScore();
        if (score >= 0) {
            textScore.text = "Score : " + score;
        }
        if(GamePlayManager.Instance.StartGame()){
            float timePlay = GamePlayManager.Instance.GlobalTime();
            if (GamePlayManager.Instance.EndGame()){
                textTime.text = "Time total : " + timePlay;
            }else{
                textTime.text = "Time : " + timePlay;
            }
        }
    }
}
