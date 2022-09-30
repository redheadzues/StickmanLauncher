using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

[RequireComponent(typeof(Button))]
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
        gameObject.SetActive(false); 
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
#if !UNITY_EDITOR
        PlayerAccount.RequestPersonalProfileDataPermission();

        if ((YandexGamesSdk.IsInitialized == true) && (PlayerAccount.IsAuthorized == true))
        {  
            _leaderboard.gameObject.SetActive(true);
        }
        else
        {            
            PlayerAccount.Authorize(OpenLeaderboard);
        }

#endif

#if UNITY_EDITOR    
        _leaderboard.gameObject.SetActive(true);
#endif
    }
}
