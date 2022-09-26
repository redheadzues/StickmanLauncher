using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

public class ButtonOpenLeaderboard : MonoBehaviour
{
    [SerializeField] private YandexLeaderbord _leaderboard;

    private Button _buttonOpenLEaderBoard;

    private void OnValidate()
    {
        _leaderboard = FindObjectOfType<YandexLeaderbord>();
    }

    private void Awake()
    {
        _buttonOpenLEaderBoard = GetComponent<Button>();
        _leaderboard.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _buttonOpenLEaderBoard.onClick.AddListener(OpenLeaderboard);
    }

    private void OnDisable()
    {
        _buttonOpenLEaderBoard.onClick.RemoveListener(OpenLeaderboard);
    }

    private void OpenLeaderboard()
    {
        _leaderboard.gameObject.SetActive(true);

    }
}
