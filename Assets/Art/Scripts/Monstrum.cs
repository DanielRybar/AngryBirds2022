using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Monstrum : MonoBehaviour
{
    public Sprite deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    public int Rychlost = 5;
    private bool _hasDied;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(ShouldDieFromCollision(collision)) 
        {
            StartCoroutine(Die());
        }
    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        if (_hasDied) return false;
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
            return true;
        if (collision.contacts[0].normal.y < -0.5)
            return true;
        return false;
    }

    private IEnumerator Die() 
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = deadSprite;
        _particleSystem.Play();
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("CervenyPtacek").GetComponent<Bird>().GenerateColor();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
