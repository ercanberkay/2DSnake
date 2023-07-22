using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    Vector2 _direction;
    [SerializeField] GameObject _segmentPrefab;
    List<GameObject> _segments = new List<GameObject>();
    
    void Start()
    {
        Reset();
        ResetSegment();
    }
    
    void Update()
    {
        GetUserInput();
    }

    void FixedUpdate()
    {
        SnakeMove();
        MoveSegment();
    }

    public void CreateSegment()
    {
        GameObject _newSegment = Instantiate(_segmentPrefab);
        _newSegment.transform.position = _segments[_segments.Count - 1].transform.position;
        _segments.Add(_newSegment);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Reset()
    {
        _direction = Vector2.right;
        Time.timeScale = 0.1f;
    }

    void ResetSegment()
    {
        for (int i = 0; i < _segments.Count; i++)
        {
            Destroy(_segments[i]);
        }

        _segments.Clear();
        _segments.Add(gameObject);

        for (int i = 0; i < 3; i++)
        {
            CreateSegment();
        }
    }

    void MoveSegment()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].transform.position = _segments[i - 1].transform.position;
        }
    }

    void SnakeMove()
    {
        float x, y;
        x = transform.position.x + _direction.x;
        y = transform.position.y + _direction.y;

        transform.position = new Vector2(x, y);
    }

    void GetUserInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            RestartGame();
        }
        
    }


}
