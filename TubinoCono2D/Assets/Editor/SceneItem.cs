using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneItem : Editor
{
    [MenuItem("Scenes/InitScreen")]
    public static void InitScreen()
    {
        OpenScene("InitScreen");
    }

    [MenuItem("Scenes/MenuScene")]
    public static void MenuScene()
    {
        OpenScene("MenuScene");
    }

    [MenuItem("Scenes/Carcel")]
    public static void Carcel()
    {
        OpenScene("Carcel");
    }

    [MenuItem("Scenes/LoadingScene")]
    public static void LoadingScene()
    {
        OpenScene("LoadingScene");
    }


    [MenuItem("Scenes/LevelSelector")]
    public static void LevelSelector()
    {
        OpenScene("LevelSelector");
    }


    [MenuItem("Scenes/GameScreen")]
    public static void GameScreen()
    {
        OpenScene("Game");
    }

    
    static void OpenScene(string name)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/scenes/" + name + ".unity");
        }
    }
}