using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    [SerializeField]
    private float xRange = 30f;

    private float rate = 2f;
    private float nextRate = 0f;

    private int saveScore;
    private float delay = 6f;
    private float nextDelay = 0f;

    [SerializeField]
    private Pooling pooling;

    private void Update() {
        int level = GamePlayManager.Instance.GetDiffCulty();
        int score = GamePlayManager.Instance.GetScore();
        if (level > 0) {
            if (saveScore != score) {
                GetClone(true);
                saveScore = score;
            } else if (nextDelay < Time.time) {
                nextDelay = Time.time + delay;
                GetClone(true);
                saveScore = score;
            } else {
                if (nextRate < Time.time) {
                    nextRate = Time.time + rate;
                    GetClone(false);
                }
            }
        } else {
            saveScore = score;
        }
    }

    private void GetClone(bool target) {
        Material color;
        GameObject clone = GamePlayManager.Instance.GetClone(out color, target);
        if(clone != null) {
            Vector3 pos = transform.position;
            pos.x = pos.x + Random.Range(-xRange, xRange) / 2f;
            GameObject obj = pooling.Spawn(clone, pos, transform.rotation);
            var balloonBehavior = obj.GetComponent<BalloonBehavior>();
            if (balloonBehavior != null) {
                balloonBehavior.SetData();
                balloonBehavior.balloonRenderer.material = color;
            }
            var letterBehavior = obj.GetComponent<LetterBehavior>();
            if (letterBehavior != null) {
                letterBehavior.SetData();
                letterBehavior.letterRenderer.material = color;
            }
        } 
    }
}
