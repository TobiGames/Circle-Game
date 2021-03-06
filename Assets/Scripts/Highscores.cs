﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores : MonoBehaviour
{
    const string privateCode = "rG-MhbgQpkSOjmEWXLhDIws7qZb3KU_02VAza5ipgLiw";
    const string publicCode = "5bc3c6d2613a89132cdfa5f2";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    static Highscores instance;
    DisplayHighscores highscoresDisplay;

    private void Awake()
    {
        instance = this;
        highscoresDisplay = GetComponent<DisplayHighscores>();
    }

    public static void AddNewHighScore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successfull");
            FetchHighscores();
        }
        else
        {
            print("Error loading: " + www.error);
        }
    }

    public void FetchHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }


    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print(www.text);
            FormatHighscores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Error fetching: " + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        for (int i = 0; i <entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }
}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}