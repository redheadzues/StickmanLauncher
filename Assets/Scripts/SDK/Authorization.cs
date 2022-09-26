using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class Authorization : MonoBehaviour
{   
    public void TryAutorize()
    {
        PlayerAccount.Authorize(OnSuccsessAuthorization, OnError);
    }

    private void OnSuccsessAuthorization()
    {
        print("Succsess");
    }

    private void OnError(string callback)
    {
        print(callback);
    }
}
