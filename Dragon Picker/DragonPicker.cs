using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldButtomY = -6f;
    public float energyShieldRadius = 1.5f;
    public List<GameObject> basketList;

    public AudioSource audioSource;
    public AudioClip gameOverSound;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 1; i <= numEnergyShield; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(energyShieldPrefab);
            tBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
            tBasketGo.transform.localScale = new Vector3(1 * i, 1 * i, 1 * i);
            basketList.Add(tBasketGo);
        }
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    void Update()
    {
    }
    public void DragonEggDestroyed()
    {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("DragonEgg");
        foreach (GameObject tGO in tDragonEggArray)
        {
            Destroy(tGO);
        }
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);
        
        if (basketList.Count == 0)
        {
            if (gameOverSound != null)
            {
                audioSource.PlayOneShot(gameOverSound);
            }
            DragonEgg.fallSpeed = 1f;
            StartCoroutine(WaitAndLoadScene());
        }
    }
        private IEnumerator WaitAndLoadScene() // Корутин
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("_0Scene");
    }
}
