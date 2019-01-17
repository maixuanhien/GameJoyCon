using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : Singleton<GamePlayManager> {
    [SerializeField]
    private int scoreStart = -5;
    [SerializeField]
    private int score;

    [SerializeField]
    private GameObject balloon;
    [SerializeField]
    private List<GameObject> listAlphabet;
    [SerializeField]
    private List<Material> listColor;
    [SerializeField]
    private bool isBalloon = false;
    [SerializeField]
    private int index = -1;

    private void Start() {
        score = scoreStart;
    }

    public int GetScore() {
        return score;
    }

    public void AddScore(bool check_isBalloon, Color check_color, string letter = null) {
        if (score < 0) {
            score = score + Constants.SCORE_BALLOON;
        } else {
            if (isBalloon && check_isBalloon) {
                if (listColor[index].color == check_color) {
                    score = score + Constants.SCORE_BALLOON;
                    index = -1;
                }
            } else if(!isBalloon && !check_isBalloon) {
                if (index >= 0) {
                    if (letter != null && listAlphabet[index].name == letter.Substring(0, 1)) {
                        score = score + Constants.SCORE_LETTER;
                        index = -1;
                    }
                }
            }
        }
    }

    public int GetDiffCulty() {
        if (score < 0) {
            return 0;
        } else if (score < Constants.SCORE_MAX_LEVEL_1) {
            return 1;
        } else if (score < Constants.SCORE_MAX_LEVEL_2) {
            return 2;
        } else {
            return -1;
        }
    }

    public GameObject GetClone(out Material color, bool target = false) {
        int iColor;
        int iLetter;
        int level = GetDiffCulty();
        switch (level) {
            case 1:
                iColor = Random.Range(0, listColor.Count);
                if (target) {
                    isBalloon = true;
                    if (index < 0) {
                        index = iColor;
                    }
                    color = listColor[index];
                    SoundManager.Instance.PlaySoundGuide(isBalloon, index);
                } else {
                    color = listColor[iColor];
                }
                return balloon;
            case 2:
                iColor = Random.Range(0, listColor.Count);
                color = listColor[iColor];
                iLetter = Random.Range(0, listAlphabet.Count);
                if (target) {
                    isBalloon = false;
                    if (index < 0) {
                        index = iLetter;
                    } else {
                        SoundManager.Instance.PlaySoundGuide(isBalloon, index);
                        return listAlphabet[index];
                    }
                    SoundManager.Instance.PlaySoundGuide(isBalloon, index);
                }
                return listAlphabet[iLetter];
            default:
                color = listColor[0];
                return null;
        }
    }
}
