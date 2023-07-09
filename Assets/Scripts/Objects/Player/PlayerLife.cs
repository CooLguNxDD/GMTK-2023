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

    [SerializeField] private AudioSource deathSound;

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
            isDead = true;
        }
    }

    private void Die()
    {
        isDead = true;
        StartCoroutine(DeathTrigger());
        
        // Invoke("RestartLevel", 3f);
    }

    IEnumerator DeathTrigger(){

        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        deathSoundEffect.Play();
        animator.SetTrigger("Die");
        GameManager.Instance.bgMusic.Stop();
        Debug.Log("yes");

        yield return new WaitForSeconds(3f);
        Debug.Log("No");
        GameManager.Instance.deathMusic.Play();

        GameManager.Instance.TotalRun = transform.position.x;
        GameManager.Instance.Die = true;
    }

    private void RestartLevel()
    {
        Destroy(this.gameObject);
        isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
