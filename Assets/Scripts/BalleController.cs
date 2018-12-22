using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleController : MonoBehaviour {
    [SerializeField]
    private int damage = 1;

    public void SetData() {
        StopAllCoroutines();
        StartCoroutine(Disable());
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == Constants.TAG_BALLOON) {
            TouchBalloon(other.gameObject);
        }
        if (other.gameObject.tag == Constants.TAG_LETTER) {
            TouchLetter(other.gameObject);
        }
    }

    private IEnumerator Disable() {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    private void TouchBalloon(GameObject obj) {
        var balloonBehavior = obj.GetComponent<BalloonBehavior>();
        balloonBehavior.AddDamage(damage);
        gameObject.SetActive(false);
    }

    private void TouchLetter(GameObject obj) {
        var letterBehavior = obj.GetComponent<LetterBehavior>();
        letterBehavior.AddDamage(damage);
        gameObject.SetActive(false);
    }
}
