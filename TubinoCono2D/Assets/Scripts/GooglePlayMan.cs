using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.NativePlugins;
using UnityEngine.UI;

public class GooglePlayMan : MonoBehaviour
{
    bool isAvailable = false;
    public static GooglePlayMan Instance;
    public bool alreadyAsk = false;

    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public bool IsLogin()
    {
        return NPBinding.GameServices.IsAvailable() && NPBinding.GameServices.LocalUser.IsAuthenticated;
    }
    public void Login()
    {
        isAvailable = NPBinding.GameServices.IsAvailable();
        //Debug.Log("isavailable " + isAvailable);

        bool _isAuthenticated = NPBinding.GameServices.LocalUser.IsAuthenticated;


        if (!_isAuthenticated)
        {
            //Authenticate Local User
            NPBinding.GameServices.LocalUser.Authenticate((bool _success, string _error) => {

                if (_success)
                {
                    Debug.Log("Sign-In Successfully");
                    Debug.Log("Local User Details : " + NPBinding.GameServices.LocalUser.ToString());

                }
                else
                {
                    Debug.Log("Sign-In Failed with error " + _error);

                }
            });
        }
    }

    public void SignOut()
    {
        NPBinding.GameServices.LocalUser.SignOut((bool _success, string _error) => {

            if (_success)
            {
                Debug.Log("Local user is signed out successfully!");
            }
            else
            {
                Debug.Log("Request to signout local user failed.");
                Debug.Log(string.Format("Error= {0}.", _error));
            }
        });
    }


    void ShowLeaderBoardPopup()
    {
        NPBinding.GameServices.ShowLeaderboardUIWithGlobalID("FALLCRAFT_LEADERBOARD",
                    eLeaderboardTimeScope.ALL_TIME, (string _errorshow) => {

                    });
    }

    void ReportScoreAndShowPopup()
    {
         /*NPBinding.GameServices.ReportScoreWithGlobalID("FALLCRAFT_LEADERBOARD", DataMan.Instance.bestScore, (bool _success, string _error) => {

            if (_success)
            {
                ShowLeaderBoardPopup();
            }
            else
            {

            }
        });*/
    }

    public void ShowLeaderBoard()
    {
        //Show Leaderboards UI

        if (IsLogin())
        {
            ReportScoreAndShowPopup();
        }
        else
        {
            NPBinding.GameServices.LocalUser.Authenticate((bool _success, string _error) => {

                if (_success)
                {
                    ReportScoreAndShowPopup();
                }
                else
                {

                }
            });
        }
    }


    public void ReportAchievement(string achievementKey)
    {
        // If its an incremental achievement, make sure you send a incremented cumulative value everytime you call this method
        NPBinding.GameServices.ReportProgressWithGlobalID(achievementKey, 100f, (bool _status, string _error) => {

            if (_status)
            {
                
            }
            else
            {
                
            }
        });
    }

    public void ShowAchievementUI()
    {
        if (IsLogin())
        {
            NPBinding.GameServices.ShowAchievementsUI((string _errornose) =>
            {
                if (!string.IsNullOrEmpty(_errornose))
                    Debug.Log("error");
            });
        }
        else
        {
            NPBinding.GameServices.LocalUser.Authenticate((bool _success, string _error) =>
            {
                if (_success)
                {
                    NPBinding.GameServices.ShowAchievementsUI((string _errornose) =>
                    {
                        if (!string.IsNullOrEmpty(_errornose))
                            Debug.Log("error");
                    });
                }
                else
                {

                }
            });
        }
    }

}
