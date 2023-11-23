using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon_Mod : MonoBehaviour
{
    public GameObject dragonEggPrefab;
    public GameObject dragonEggPrefab_small;
    public float speed = 1;
    public float timeBetweenEggDrops = 4f;
    public float timeBetweenEggDrops_series = 1f;
    public float leftRightDistance = 10f;
    public float chanceDirection = 0.01f;
    public float chanceSeries = 0.1f;
    public float gravity = 10f;
    void Start()
    {
        Physics.gravity = new Vector3 (0, -gravity, 0);
        StartCoroutine(DropEgg());
    }

    IEnumerator DropEgg()
    {
        while (!false)
        {
            float rand = Random.value;
            if (rand <= chanceSeries)
            {
                Debug.Log("series");
                for (int i = 0; i < 3; ++i)
                {
                    GameObject egg = Instantiate<GameObject>(dragonEggPrefab_small);
                    egg.transform.position = transform.position + new Vector3(0.0f, 5.0f, 0.0f);
                    yield return new WaitForSeconds(timeBetweenEggDrops_series);
                }
            }
            else
            {
                Debug.Log("single");
                Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
                GameObject egg = Instantiate<GameObject>(dragonEggPrefab);
                egg.transform.position = transform.position + myVector;
                yield return new WaitForSeconds(timeBetweenEggDrops);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftRightDistance){
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance){
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate() {
        if (Random.value < chanceDirection){
            speed *= -1;
        }
    }
}
