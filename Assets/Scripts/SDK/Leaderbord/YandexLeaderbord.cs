using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class YandexLeaderbord : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private Transform _container;

    private const string _leaderboardName = "SLLeaderboard";

    private List<GameObject> _displayedScores = new List<GameObject>();

    private void OnEnable()
    {
#if !UNITY_EDITOR
        if (YandexGamesSdk.IsInitialized == true)
            FillLeaderbord();
#endif

#if UNITY_EDITOR
        TestingFill();
#endif
    }

    public void AddPlayerScore(int score)
    {
#if !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized == false)
            return;

        Leaderboard.SetScore(_leaderboardName, score);
#endif
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void FillLeaderbord()
    {
        ClearLeaderboard();

        Leaderboard.GetEntries(_leaderboardName, (result) =>
        {
            int resultsAmount = result.entries.Length;

            resultsAmount = Mathf.Clamp(resultsAmount, 1, 5);

            for (int i = 0; i < resultsAmount; i++)
            {
                string name = result.entries[i].player.publicName;

                print(name);

                if (string.IsNullOrEmpty(name))
                    name = "Anonymos";

                int score = result.entries[i].score;

                ConsctructScoreView(i, name, score);
            }
        });
    }

    private void ClearLeaderboard()
    {
        for(int i = 0; i < _displayedScores.Count; i++)
            Destroy(_displayedScores[i]);

        _displayedScores = new List<GameObject>();
    }

    private void ConsctructScoreView(int number, string name, int score)
    {
        ScoreView scoreView = Instantiate(_scoreView, _container);
        scoreView.Initialize(number, name, score);
        _displayedScores.Add(scoreView.gameObject);
    }

    private void TestingFill()
    {
        ClearLeaderboard();

        for (int i = 0; i < 5; i++)
            ConsctructScoreView(i, "Name", Random.Range(10, 9999));
    }
}
