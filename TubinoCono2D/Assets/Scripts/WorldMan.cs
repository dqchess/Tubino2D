using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public int stars = 0;
    public bool iscomplete = false;
}

public class WorldMan : MonoBehaviour
{
    public static WorldMan Me;
    public int currentLevel = 0;

    public List<LevelData> leveldata;

    void Awake()
    {
        Me = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    public void SaveValues(int stars,  bool isComplete)
    {
        int realid = this.currentLevel - 1;
        leveldata[realid].iscomplete = isComplete;
        leveldata[realid].stars = stars;
        ES3.Save<bool>("c" + realid, leveldata[realid].iscomplete);
        ES3.Save<int>("s" + realid, leveldata[realid].stars);
    }

    private void Start()
    {
        LoadData();
    }

    void LoadData()
    {
        leveldata = new List<LevelData>();
        for (int i = 0; i < Constants.numLevel; i++)
        {
            LevelData ld = new LevelData();
            ld.iscomplete = ES3.Load<bool>("c" + i, false);
            ld.stars = ES3.Load<int>("s" + i, 0);
            leveldata.Add(ld);
                
        }
    }

    public void SetCurrentLevel(int level)
    {
        this.currentLevel = level;
    }

    public bool SetNextLevel()
    {
        this.currentLevel++;
        if (this.currentLevel > 10)
        {
            this.currentLevel = 1;
            return false;
        }
        else
        {
            return true;
        }
            
    }
}
