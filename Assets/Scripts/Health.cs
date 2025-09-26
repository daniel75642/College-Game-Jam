using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float minHealth;

    public Slider slider;

    public float damage;
    public float heavyDamage;

    private GameObject player;

    public Transform canvasTransform;

    private ThirdPersonController thirdPersonController;
    private Attack attack;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 1000;
        minHealth = 0;
        health = maxHealth;

        player = GetComponent<GameObject>();

        GetComponentInChildren<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        canvasTransform.LookAt(Camera.main.transform);

        if (health <= minHealth)
        {
            GameManager.Instance.playersLeft--;
            gameObject.SetActive(false);
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        slider.value = health;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AttackHitBox"))
        {
            health -= damage;
        }

        if (other.gameObject.CompareTag("HeavyAttack"))
        {
            health -= heavyDamage;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathLayer"))
        {
            GameManager.Instance.playersLeft--;
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            health -= 1f;
        }

        if (other.gameObject.CompareTag("heal"))
        {
            health += 100f;
        }
    }
}
