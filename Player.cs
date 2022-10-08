using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShot = false;
    public bool canSpeedBoost = false;
    public bool canShield = false;
    public int life = 3;
    // [SerializeField]
    // private GameObject canTripleShot(){}

    [SerializeField]
    private GameObject _explosionPreFab;

    [SerializeField]
    private GameObject _laserPreFab;
    [SerializeField]
    private GameObject _tripleShotPreFab;

    [SerializeField]
    private GameObject _shieldGameObject;
    [SerializeField]

    private float _fireRate = 0.5f;
    [SerializeField]
    private float _nextFire = 0.0f;

    private float _speed = 5.0f;

    private UI_Manager _uiManager;
    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        if(_uiManager != null)
        {
            _uiManager.updateLives(life);
        }
    }

    private void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButton(0)))
        {
            Shoot();

        }
    }
    private void Shoot()
    {

        if (Time.time > _nextFire)
        {
            if (canTripleShot == true)
            {

                Instantiate(_tripleShotPreFab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPreFab, transform.position + new Vector3(0, 0.95f, 0), Quaternion.identity);
            }
            _nextFire = Time.time + _fireRate;
        }

    }
    private void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if(canSpeedBoost == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed * 1.5f * h );
            transform.Translate(Vector3.up * Time.deltaTime * _speed * 1.5f * v );
        }
        else {
        transform.Translate(Vector3.right * Time.deltaTime * _speed * h);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * v);
        }
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.56f)
        {
            transform.position = new Vector3(transform.position.x, -4.56f, 0);
        }

        if (transform.position.x > 11.6f)
        {
            transform.position = new Vector3(11.6f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.6f)
        {
            transform.position = new Vector3(-11.6f, transform.position.y, 0);
        }


    }
    public void Damage()
    {
        if(canShield == true)
        {
            canShield = false;
            _shieldGameObject.SetActive(false);
            return;
        }
        life--;
        _uiManager.updateLives(life);
        if(life < 1)
        {
            Instantiate(_explosionPreFab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    public void ShieldUpOn ()
    {
        canShield = true;
        _shieldGameObject.SetActive(true);
    }
    public void TripleShotPowerUpOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotCooldown());
    }
    public void SpeedBoostUpON()
    {
        canSpeedBoost = true;
        StartCoroutine(SpeedBoostCooldown());
    }
     public IEnumerator TripleShotCooldown()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }
     public IEnumerator SpeedBoostCooldown()
    {
        yield return new WaitForSeconds(5.0f);
        canSpeedBoost = false;
    
    }
   
}
