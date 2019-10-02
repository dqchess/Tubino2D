using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public int stars = 0;
    public bool iscomplete = false;
    public bool isLock = true;
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
        

        if (!leveldata[realid].iscomplete)
        {
            leveldata[realid].iscomplete = isComplete;
            ES3.Save<bool>("c" + realid, leveldata[realid].iscomplete);

            int unlock = realid + 1;
            if(unlock < leveldata.Count)
            {
                Debug.Log("unloqueando " + unlock);
                leveldata[unlock].isLock = false;
                ES3.Save<bool>("l" + unlock, leveldata[unlock].isLock);
            }
            
        }
            

        if (leveldata[realid].stars < stars)
        {
            leveldata[realid].stars = stars;
            ES3.Save<int>("s" + realid, leveldata[realid].stars);
        }
            
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
            if(i==0)
                ld.isLock = ES3.Load<bool>("l" + i, false);
            else
                ld.isLock = ES3.Load<bool>("l" + i, true);

            leveldata.Add(ld);


            //BORRAME
            ld.isLock = false;
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
