using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float maxInitialFallSpeed = 10f;
    public int scoreValue = 1;
    public AudioClip destructionSound;

    public float initialFallSpeed;
    public float currentFallSpeed;

    private AudioController audioController;

    private void Start()
    {
        initialFallSpeed = Random.Range(0, maxInitialFallSpeed);
        currentFallSpeed = initialFallSpeed;

        audioController = FindObjectOfType<AudioController>();
        if (audioController == null)
        {
            GameObject audioControllerObject = new GameObject("AudioController");
            audioController = audioControllerObject.AddComponent<AudioController>();
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                AddToScore();
                PlayDestructionSound(); // Play sound when the item is destroyed
                Destroy(gameObject);
            }
        }
    }

    private void AddToScore()
    {
        ScoreManager.Instance.AddScore(scoreValue);
    }

    private void PlayDestructionSound()
    {
        audioController.PlayOneShot(destructionSound);
    }
}