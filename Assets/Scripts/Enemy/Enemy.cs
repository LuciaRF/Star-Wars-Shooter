using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] int _speed;
    [SerializeField] float _distanceToPlayer;
    
    [Header("Attack")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform [] _bulletSpawn;
    [SerializeField] float timeBetweenBullets;
    
    GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        InvokeRepeating("Attack",1, timeBetweenBullets);
    }

    void Update()
    {
        if (_player == null)
        {
            return;
        }
        
        transform.LookAt(_player.transform.position);
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        if (distance > _distanceToPlayer)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        for (int i = 0; i < _bulletSpawn.Length; i++)
        {
            Instantiate(bulletPrefab, _bulletSpawn[i].position, _bulletSpawn[i].rotation);
        }
    }
}
