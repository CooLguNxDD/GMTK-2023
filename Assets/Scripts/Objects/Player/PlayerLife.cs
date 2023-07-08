using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private int health = 100; 
    private Rigidbody2D rb;
    private Animator anim;
    private bool isDead = false;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isDead)
        {
            CheckDeath();
        }
    }

    public bool IsDead()
    {
        return isDead;
    }


    private void CheckDeath()
    {
    if (health <= 0)
    {
        Die();
    }
    }

    private void Die()
    {
        isDead = true;
        deathSoundEffect.Play();
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        anim.SetTrigger("Die");
        Invoke("RestartLevel", 3f);
    }

    private void RestartLevel()
    {
        isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
