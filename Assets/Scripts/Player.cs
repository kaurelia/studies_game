using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TouchTest myTouch;
    public GameObject knife;
    public GameObject superKnife;
    public Transform spawner;

    private Collider2D myCollider;
    private Touch firstFinger;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (myCollider == Physics2D.OverlapPoint(myTouch.endPosition) && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                float randomChanceToSpawnSuperKnife = Random.value;
                if(randomChanceToSpawnSuperKnife < .97f)
                {
                    ThrowAKnife();
                } else
                {
                    ThrowASuperKnife();
                }
            }
        } 

    }

    private void ThrowAKnife()
    {
        Instantiate(knife, spawner.position, Quaternion.Euler(0, 0, 0));
    }
    private void ThrowASuperKnife()
    {
        Instantiate(superKnife, spawner.position, Quaternion.Euler(0, 0, 0));
    }
}
