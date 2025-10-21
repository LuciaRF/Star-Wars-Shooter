using UnityEngine;

public class Xwing : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField] private int _speed;
    [SerializeField] private int _turnSpeed;
    
    [Header("Attack")]
    [SerializeField] GameObject _bulletPrefab;

    [SerializeField] private Transform[] posRotBullet;
    
    AudioSource _shootAudio;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _shootAudio =  GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        Turning();
        Attack();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = direction.normalized;
        
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    void Turning()
    {
        float xMouse = Input.GetAxisRaw("Mouse X");
        float yMouse = Input.GetAxisRaw("Mouse Y");

        Vector3 rotation = new Vector3(-yMouse, xMouse, 0);
        
        transform.Rotate(rotation.normalized * _turnSpeed * Time.deltaTime);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _shootAudio.Play();
            for (int i = 0; i < posRotBullet.Length; i++)
            {
                GameObject bullet = Instantiate(_bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
            }
        }
    }
}
