using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textNickname;
    [SerializeField] private TMP_Text _textScore;
    [SerializeField] private TMP_Text _number;

    public void Initialize(int number, string nickname, int score)
    {
        _number.text = number.ToString();
        _textNickname.text = nickname;
        _textScore.text = score.ToString();
    }
}
