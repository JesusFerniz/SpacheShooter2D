using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float maxHP = 100;
    public float timeBetweenShoots = 0.5f;

    public GameObject bulletPrefab;
    public Transform bulletOrigin;

    public Text hpText;

    public GameObject deadParticlePrefab;

    public AudioClip shootAudioClip;
    public AudioClip explosionPlayerAudioClip;

    private float currentHP;
    private float timeOfLastShoot;


    private void Start()
    {
        currentHP = maxHP;
        hpText.text = "HP: " + currentHP;
    } 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > timeOfLastShoot + timeBetweenShoots)
                Shoot();
        }
    }

    public void Damage(float amount)
    {
        currentHP -= amount;
        hpText.text = "HP: " + currentHP;

        if (currentHP <= 0f)
        {
            Dead();
        }
    }

    private void Shoot()
    {
        GameObject particles = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        Destroy(particles, 1f);
        timeOfLastShoot = Time.time;

        AudioSource.PlayClipAtPoint(shootAudioClip, transform.position, 0.8f);
    }

    private void Dead()
    {
        AudioSource.PlayClipAtPoint(explosionPlayerAudioClip, transform.position, 1f);

        Instantiate(deadParticlePrefab, transform.position, transform.rotation);

        FindObjectOfType<GameManager>().GameOver();

        Destroy(this.gameObject);
    }
}