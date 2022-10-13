using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] 
    float _launchForce = 500;
    [SerializeField] 
    float _maxDragDistance = 3;
    public int Rychlost = 3;

    Vector2 _startPosition;
    Rigidbody2D _rigidBody2D;
    SpriteRenderer _spriteRenderer;
    [Range(5,20)]
    public int Force;
    //Vector2 distance;

    // pred startem
    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        _startPosition = _rigidBody2D.position;
        _rigidBody2D.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        // nic
    }

    void OnMouseDown()
    {
        //_spriteRenderer.color = new Color();
        _spriteRenderer.color = Color.red;
        Debug.Log("Obarveno na červeno");
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desirePosition = mousePosition;
        float distance = Vector2.Distance(desirePosition, _startPosition);
        if (distance > _maxDragDistance) // pohybujeme se v kruhu
        {
            Vector2 direction = desirePosition - _startPosition;
            direction.Normalize();
            desirePosition = _startPosition + (direction * _maxDragDistance);
        }
        if (desirePosition.x > _startPosition.x) // pohybujeme se v půlkruhu
        {
            desirePosition.x = _startPosition.x;
            _rigidBody2D.position = desirePosition;
        }
        transform.position = desirePosition;
    }

    void OnMouseUp() 
    {
        _spriteRenderer.color = Color.white;
        Debug.Log("Obarveno na bílo");
        var currentPosition = _rigidBody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();
        _rigidBody2D.isKinematic = false;
        _rigidBody2D.AddForce(direction * _launchForce);
    }

    private void OnCollisionEnter2D(Collision2D colission) 
    {
        StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay() // to do list
    {
        /*
        while(flagpohyb) 
        {
            Pohyb();
            yield return null;
        }
        while(vystrel) 
        {
            Pohyb();
            yield return null;
        }
        */
        yield return new WaitForSecondsRealtime(3);
        _rigidBody2D.isKinematic = true;
        _rigidBody2D.velocity = Vector2.zero;
        _rigidBody2D.position = _startPosition;
    }

    public void GenerateColor()
    {
        _spriteRenderer.color = Color.green;
    }
}
