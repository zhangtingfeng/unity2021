﻿using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

[InitializeOnLoad]
public class Autorun
{
    static Autorun()
    {
        EditorApplication.update += InitProject;

    }

    static void InitProject()
    {
        EditorApplication.update -= InitProject;
        if (EditorApplication.timeSinceStartup < 10 || !EditorPrefs.GetBool("AlreadyOpened"))
        {
            if (EditorSceneManager.GetActiveScene().name != "gameJellyGarden" && Directory.Exists("Assets/JellyGarden/Scenes"))
            {
                EditorSceneManager.OpenScene("Assets/JellyGarden/Scenes/gameJellyGarden.unity");

            }
            LevelMakerEditor.Init();
            LevelMakerEditor.ShowHelp();
            EditorPrefs.SetBool("AlreadyOpened", true);
        }

    }
}