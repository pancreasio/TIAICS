using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float viewDistance;
    [SerializeField]
    float shootDistance;
    [SerializeField]
    float idleRotationRate;
    [SerializeField]
    float bulletSpawnPhase;
    [SerializeField]
    float speed;
    public GameObject player;

    private string bulletException;
    enum enemyState
    {
        idle, chase, combat,
    }

    private enemyState currentState;
    public int HP;
    public GameObject bullet;
    void Start()
    {
        currentState = enemyState.idle;
        bulletException = "Enemy";
    }

    void Update()
    {
        Debug.Log(HP);
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }

        if (player != null)
        {
            float dist = Vector3.Distance(player.transform.position, this.transform.position);

            if (dist <= shootDistance)
            {
                currentState = enemyState.combat;
            }
            else
            {
                if (dist <= viewDistance)
                {
                    currentState = enemyState.chase;
                }
                else
                {
                    currentState = enemyState.idle;
                }
            }
        }
        else
        {
            currentState = enemyState.idle;
        }
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case enemyState.idle:
                transform.Rotate(new Vector3(0, idleRotationRate, 0));
                transform.position += transform.forward * speed;
                break;
            case enemyState.chase:
                transform.LookAt(player.transform);
                transform.position += transform.forward * speed;
                break;
            case enemyState.combat:
                transform.LookAt(player.transform);
                transform.position += transform.forward * speed;
                break;
        }
    }

    private void Fire()
    {
        GameObject fireBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + bulletSpawnPhase), transform.rotation);
        fireBullet.tag = "PlayerBullet";
        fireBullet.GetComponent<Bullet>().exception = bulletException;
    }

    public void Damage(int damage)
    {
        HP --;
    }
}
