using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float maxInitialFallSpeed = 10f;
    public int scoreValue = 1;

    public float initialFallSpeed;
    public float currentFallSpeed;

    void Start()
    {
        initialFallSpeed = Random.Range(0, maxInitialFallSpeed);
        currentFallSpeed = initialFallSpeed;
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
}