using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyShield : MonoBehaviour
{
    public TextMeshProUGUI scoreGT;
    public AudioSource audioSource;
    public float fallSpeedIncrease = 4f;
    public float maxFallSpeed = 50f;
    void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        scoreGT.text = "0";
    }
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
     private void OnCollisionEnter(Collision coll)
    {
        GameObject Collided = coll.gameObject;
        if (Collided.tag == "DragonEgg")
        {
            Destroy(Collided);
        }
        int score = int.Parse(scoreGT.text);
        score += 1;
        scoreGT.text = score.ToString();
        
        if (score % 10 == 0)
            {
                IncreaseFallSpeed(); // Увеличиваем скорость падения яиц
            }
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void IncreaseFallSpeed() {
        if (DragonEgg.fallSpeed < maxFallSpeed) 
        {
            DragonEgg.fallSpeed += fallSpeedIncrease;
            
            if (DragonEgg.fallSpeed > maxFallSpeed) 
            {
                DragonEgg.fallSpeed = maxFallSpeed;
            }
        }
    } 
}