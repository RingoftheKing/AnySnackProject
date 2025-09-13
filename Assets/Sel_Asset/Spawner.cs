using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject noteprefab;
    public float spawntime = 10f;
    private float timer = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnNote(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawntime)
        {
            timer += Time.deltaTime;
        }
        else       {

            spawnNote(Random.Range(1,13));
            timer = 0.0f;
        }
    }

    void spawnNote(int track)
    {
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
