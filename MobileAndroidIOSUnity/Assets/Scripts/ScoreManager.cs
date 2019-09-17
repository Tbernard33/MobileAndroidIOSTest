using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    #region singleton
    static ScoreManager _instance;

    static public bool IsActive
    {
        get
        {
            return _instance != null;
        }
    }

    static public ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = UnityEngine.Object.FindObjectOfType(typeof(ScoreManager)) as ScoreManager;

                if (_instance == null)
                {
                    GameObject go = new GameObject("ScoreManager");
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<ScoreManager>();
                }
            }
            return _instance;
        }
    }
    #endregion


    int score = 0;
    public Text scoreUI;

    public void AddScore()
    {
        score++;
        if(!Achievements.ButtonPushed.IsUnlocked)
        {
            Achievements.ButtonPushed.Unlock();
        }
    }

    public void UpdateScoreUI()
    { 
        if(scoreUI != null)
        scoreUI.text = "Score : " + score;
    }

    public void PublishScore()
    {
        if(score != 0)
        {
            // Submit to leaderboard
            Leaderboards.GlobalRank.SubmitScore(score);
        }
    }
}
