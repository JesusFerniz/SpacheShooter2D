using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Meteoritos : MonoBehaviour
{
    public float speed = 5f;
    public float damageAmount = 10f;

    public GameObject particlePrefab;

    public AudioClip explosionMeteoritosAudioClip;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.Damage(damageAmount);
                DestroyMeteoritos();
            }
        }
    }

    public void DestroyMeteoritos()
    {
        AudioSource.PlayClipAtPoint(explosionMeteoritosAudioClip, transform.position, 1f);

        GameObject particles = Instantiate(particlePrefab, transform.position, transform.rotation);
        Destroy(particles, 1f);
        Destroy(this.gameObject);
    }
}
