using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float initialFallSpeed = 5f;
    public float maxInitialFallSpeed = 10f;  
    public float accelerationRate = 1f;  
    public int scoreValue = 1;

    private float currentFallSpeed;

    void Start()
    {
        currentFallSpeed = initialFallSpeed;
        StartCoroutine(IncreaseInitialFallSpeedOverTime());
    }

    void Update()
    {
        transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                AddToScore();
                Destroy(gameObject);
            }
        }
    }

    void AddToScore()
    {
        ScoreManager.Instance.AddScore(scoreValue);
    }

    IEnumerator IncreaseInitialFallSpeedOverTime()
    {
        while (initialFallSpeed < maxInitialFallSpeed)
        {
            initialFallSpeed += accelerationRate * Time.deltaTime;
            yield return null;
        }

        currentFallSpeed = initialFallSpeed;
    }
}