using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragonEgg : MonoBehaviour
{
    public static float bottomY = -30f;
    public static float fallSpeed = 1f; // начальная скорость падения яиц
    public AudioSource audioSource;
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;
        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            DragonPicker apScript = Camera.main.GetComponent<DragonPicker>();
            apScript.DragonEggDestroyed();
        }
    }
}

