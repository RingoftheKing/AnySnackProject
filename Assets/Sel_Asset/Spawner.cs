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

            spawnNote(Random.Range(1,5));
            timer = 0.0f;
        }
    }

    void spawnNote(int track)
    {
        Vector3 track_vector = Vector3.zero;
        Debug.Log("spawned note in track " + track);

        if (track == 1)
        {
            track_vector = new Vector3(-5f, 7f, 0f);
        }
        else if (track == 2)
        {
            track_vector = new Vector3(5f, 7f, 0f);
        }
        else if (track == 3)
        {
            track_vector = new Vector3(-1.67f, 7f, 0f);
        }
        else if (track == 4)
        {
            track_vector = new Vector3(1.67f, 7f, 0f);
        }

        Instantiate(noteprefab, track_vector, Quaternion.identity);
        Normal_Note_Script note_script = noteprefab.GetComponent<Normal_Note_Script>();
        note_script.track_no = track;
    }
}
