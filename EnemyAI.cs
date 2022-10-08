using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyExplosionPreFab;
    
    private float _speed = 5.0f;
    private UI_Manager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {

         if(transform.position.y < -7.6f)
        {
            float randomX = Random.Range(-10f, 10f);
            transform.position = new Vector3(randomX, 7.6f, 0);
        }
       transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }  
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(_enemyExplosionPreFab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player")
        {
        //  Player player = other.GetComponent<Player>();
        Player player = other.GetComponent<Player>();
           
            if(player!= null)
            {
                player.Damage();
            }
        }
            Instantiate(_enemyExplosionPreFab, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }

}
