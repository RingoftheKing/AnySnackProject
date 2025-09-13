using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeatmapDetails
{
    public string title;
    public string artist;
    public string charter;
    public string level;
}

[System.Serializable]
public class Note
{
    public float hdur;
    public string track;
    public int cat;
    public bool inside;
    public bool outside;
    public float time;
}

[System.Serializable]
public class Beatmap
{
    public BeatmapDetails details;
    public Note[] noteList;
}