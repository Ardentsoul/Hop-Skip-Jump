using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public GameObject player;
    public AudioSource deathSound;
    bool isDead = false;
    private void Update()
    {
        if (transform.position.y < -2f && !isDead)
        {
            Die();
        }
    }
    void DisableGameObject()
    {
        player.SetActive(false);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<ThirdPersonMovement>().enabled = false;
            Die();
            Invoke(nameof(DisableGameObject), 1.3f);
        }
    }

    void Die()
    {
        Invoke(nameof(Respawn), 1.3f); // delay the loading of level
        isDead = true;
        deathSound.Play();
    }

    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
