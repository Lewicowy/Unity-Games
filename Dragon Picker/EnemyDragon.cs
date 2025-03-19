using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDragon : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject dragonEggPrefab;
    public GameObject dragonEggPoison;
    public float speed = 1f;
    public float timeBetweenEggDropsMin = 1f; // Минимальное время яиц
    public float timeBetweenEggDropsMax = 3f; // Максимальное время яиц
 //   public float timeBetweenEggDrops = 1f;
    public float leftRightDistance = 10f;
    public float chanceDirections = 0.1f;

    void Start()
    {
        ScheduleNextEggDrop();
 //       Invoke("DropEgg", 2f); // 1
    }
    
    void DropEgg() // 2
    {
        Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(dragonEggPrefab);
//        GameObject eggpoison = Instantiate<GameObject>(dragonEggPoison);
        egg.transform.position = transform.position + myVector;
//        eggpoison.transform.position = transform.position + myVector;
//        Invoke("DropEgg", timeBetweenEggDrops);
        ScheduleNextEggDrop();
    }

    void ScheduleNextEggDrop() //генерация случайного времени
    {
        float randomTime = Random.Range(timeBetweenEggDropsMin, timeBetweenEggDropsMax);
        Invoke("DropEgg", randomTime);
    }

    void Update()
    {
        Vector3 pos = transform.position; 
        pos.x += speed * Time.deltaTime; 
        transform.position = pos; 
        
        if (pos.x < -leftRightDistance) 
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance) 
        {
            speed = -Mathf.Abs(speed);
        }
    }

     private void FixedUpdate()
    {
        if (Random.value < chanceDirections)
        {
                speed *= -1;
        }
    }
}
