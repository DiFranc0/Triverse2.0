using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class PlayfabScript : MonoBehaviour
{

    public GameObject loadIcon;
    public GameObject insiraBG;
    public GameObject leaderboardBG;

    [Header("PlayFab")]
    string LoggedId;
    bool isLogged;

    [Header("GET LEADERBOARD")]
    public GameObject rowPrefab;
    public Transform rowsParent;

    public TMP_InputField playerID;
    public int playerNumber = 1;


    public PlayfabScript Instance { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerNumber"))
        {
            PlayerPrefs.SetInt("PlayerNumber", playerNumber);
        }

        if (isLogged == true)
        {
            Debug.Log("User already logged in");
        }
        else
        {
            Debug.Log("Trying to log in");
            login();
        }
    }


    // LOGIN /////////////////////////////////////////////
    public void login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = PlayerPrefs.GetInt("PlayerNumber").ToString(),
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, onLoginSucces, Onerror);
    }

    public void onLoginSucces(LoginResult result)
    {
        LoggedId = result.PlayFabId;
        Debug.Log("Successful login/account create!");
        Debug.Log(LoggedId);
        isLogged = true;
        playerNumber = PlayerPrefs.GetInt("PlayerNumber");
        playerNumber++;
        PlayerPrefs.SetInt("PlayerNumber", playerNumber);
        Debug.Log(PlayerPrefs.GetInt("PlayerNumber"));


        /*if (!PlayerPrefs.HasKey("PlayerGamerTag"))
        {
            PlayerPrefs.SetString("PlayerGamerTag", result.PlayFabId);
        }*/
    }

    public void Onerror(PlayFabError playFabError)
    {
        Debug.Log("Error while loggin in/creating account!");
        Debug.Log(playFabError.GenerateErrorReport());
    }

    public void UpdateDisplayName()
    {
        loadIcon.SetActive(true);

        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = playerID.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnerrorUpdateName);


    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("nome alterado");
        //PlayerPrefs.SetString("PlayerGamerTag", inputField.text);
        //IMPLEMENTAR FEEDBACK
        SendLeaderboard();
    }

    void OnerrorUpdateName(PlayFabError playFabError)
    {
        Debug.Log("Error while loggin in/creating account!");
        Debug.Log(playFabError.GenerateErrorReport());
        //IMPLEMENTAR FEEDBACK
        

    }


    public void SendLeaderboard()
    {


        var request = new UpdatePlayerStatisticsRequest

        {

            Statistics = new List<StatisticUpdate>

        {

            new StatisticUpdate
            {

                StatisticName = "alltimeLeaderboard",

                Value = GameOverScreen.highscore

    }

            }

        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, Onerror);

    }



    public void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)

    {

        Debug.Log("Successfull leaderboard sent");
        
        CallLeaderboard();

    }

    // GET LEADERBOARDS /////////////////////////////////////////////////////



    public void CallLeaderboard()
    {
        StartCoroutine(Leaderboard());
    }



    IEnumerator Leaderboard()
    {
        yield return new WaitForSeconds(1);
        loadIcon.SetActive(false);
        insiraBG.SetActive(false);
        leaderboardBG.SetActive(true);
        GetLeaderboard();
        
    }



    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "alltimeLeaderboard",
            StartPosition = 0,
            MaxResultsCount = 50
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, Onerror);
    }



    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }



        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position + 1).ToString();
            if (item.DisplayName == null)
            {
                texts[1].text = item.PlayFabId;
            }
            else
            {
                texts[1].text = item.DisplayName;
            }
            texts[2].text = item.StatValue.ToString();
        }
    }
}
