using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_general : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] spawners;
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] spawnTypes;
    public string tipo;
    public bool urgencia;
    public bool cerca;
    public float time_limit;
    float cur_time;
    public float low_limit;
    public float up_limit;

    void Start()
    {
        Invoke(nameof(Spawn),0.5f);
    }

    // Update is called once per frame
    void Spawn()
    {
        GameObject target = ChooseSpawner();
        if(target != this.gameObject)
        {
            GameObject type = ChooseSpawnType();
            GameObject go = Instantiate(type, ChooseSpawner().transform.position, type.transform.rotation);
        }
        
        Invoke(nameof(Spawn), ChooseTime());

    }
    private GameObject ChooseSpawner()
    {
        List<GameObject> availSpawn = new();
        for (int i = 0; i < spawners.Length; i++)
        {
            int layerT = LayerMask.NameToLayer(tipo);
            Collider[] res = Physics.OverlapSphere(spawners[i].transform.position, 3f, 1 << layerT);

            if (res.Length == 0)
            {
                float dist = Vector3.Distance(spawners[i].transform.position, player.transform.position);
                if ((cerca && dist > 0.01f) | !cerca)
                {
                    availSpawn.Add(spawners[i]);
                }
            }
        }
        int newIndex = Random.Range(0, availSpawn.Count);
        return availSpawn.Count == 0? this.gameObject: availSpawn[newIndex];
    }

    private GameObject ChooseSpawnType()
    {
        int newIndex;
        int limit = 5;
        if(tipo == "food")
        {
            int rng = Random.Range(1, 10);
            newIndex = rng < limit ? 1 : 0;
        }
        else
        {
            newIndex = Random.Range(0, spawnTypes.Length);
        }
        return spawnTypes[newIndex];
    }
    private float ChooseTime()
    {
        cur_time = Time.deltaTime;
        float rightime = urgencia? Mathf.Lerp(low_limit,up_limit,cur_time/time_limit): Random.Range(low_limit,up_limit);
        return rightime;
    }
}
