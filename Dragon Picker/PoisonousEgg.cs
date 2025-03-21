using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PoisonousEgg : MonoBehaviour
{
    public static float bottomY = -30f;

    private void OnTriggerEnter(Collider other) {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;

        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void Update() {
        if (transform.position.y < bottomY) {
            Destroy(this.gameObject);
        }
    }
}

