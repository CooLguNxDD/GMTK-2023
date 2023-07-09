using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private UnitSetting unitSetting;

    private float health = 100;
    private Rigidbody2D rb;
    private bool isDead = false;

    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
    
    if (unitSetting.GetHP() <= 0)
    {
        
        Die();
    }
    }

    private void Die()
    {
        isDead = true;
        //deathSoundEffect.Play();
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        animator.SetTrigger("Die");
        GameManager.Instance.Die = true;


        // Invoke("RestartLevel", 3f);
    }

    private void RestartLevel()
    {
        Destroy(this.gameObject);
        isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
