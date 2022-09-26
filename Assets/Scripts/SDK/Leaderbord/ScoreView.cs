using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textNickname;
    [SerializeField] private TMP_Text _textScore;

    public void Initialize(string nickname, int score)
    {
        _textNickname.text = nickname;
        _textScore.text = score.ToString();
    }
}
