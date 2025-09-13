using System.Collections.Generic;
using System.Data.Common;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject noteprefab;
    public float spawntime = 10f;
    public float timer = 1.3f;
    public TextAsset jsonFile;
    private int idx = 0;
    private Beatmap bmdata;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bmdata = JsonUtility.FromJson<Beatmap>(jsonFile.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (bmdata.noteList[idx].time - timer <= 0.01)
        if (bmdata.noteList[idx].time - timer <= 0.01)
        {
            string track = bmdata.noteList[idx].track;
            if (track == "a")
            {
                spawnNote(10);
            }
            else if (track == "b")
            {
                spawnNote(11);
            }
            else
            {
                spawnNote(int.Parse(track));
                Debug.Log(track);
                Debug.Log(int.Parse(track));
            }
            ++idx;
        }
        timer += Time.deltaTime;
        //else
        //{

        //    //    spawnNote(Random.Range(0,12));
        //    //    timer = 0.0f;
        //    //}
    }

    void spawnNote(int track)
    {
        track = track + 1;
        // 计算旋转角度
        float rotationAngle = -((track - 1) * 30f + 15f);
        Quaternion rotation = Quaternion.Euler(0, 0, rotationAngle); // 绕Z轴旋转

        // 位置
        Vector3 track_vector = Vector3.zero;


        // 实例化并带旋转
        GameObject noteInstance = Instantiate(noteprefab, track_vector, rotation);

        // 初始化内部参数
        Normal_Note_Script note_script = noteInstance.GetComponent<Normal_Note_Script>();
        note_script.track_no = track;

        Debug.Log("spawned note in track " + track + " with rotation " + rotationAngle);
    }

}
