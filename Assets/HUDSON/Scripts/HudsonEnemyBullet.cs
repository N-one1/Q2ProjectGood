using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudsonEnemyBullet : MonoBehaviour
{

    public float dieTime, damage;
    public GameObject diePEFFECt;
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    void OnCollosionEnter2D(Collision2D col)
    {

        Die();

    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);

        Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
