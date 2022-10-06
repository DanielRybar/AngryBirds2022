using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstrum : MonoBehaviour
{
    public Sprite deadSprite;
    private bool _hasDied;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(ShouldDieFromCollision(collision)) 
        {
            StartCoroutine(Die());
        }
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
            return true;
        if (collision.contacts[0].normal.y < - 0.5)
            return true;
        return false;
    }

    IEnumerator Die() 
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = deadSprite;
        yield return new WaitForSeconds(1);
        ;
        gameObject.SetActive(false);
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
