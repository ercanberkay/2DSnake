using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    [SerializeField] float _minX, _maxX, _minY, _maxY;
    [SerializeField] SnakeController _snake;
    void Start()
    {
        RandomChickenPosition();
    }


    void RandomChickenPosition()
    {
        transform.position = new Vector2(
            Mathf.Round(Random.Range(_minX, _maxX)) +0.5f,
            Mathf.Round(Random.Range(_minY, _maxY)) +0.5f
            );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Snake"))
        {
            RandomChickenPosition();
            _snake.CreateSegment();
        }
    }
}
