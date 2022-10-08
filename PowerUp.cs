using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int PowerUPID;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Collided with" + other.name);
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                // enable triple shot
                if (PowerUPID == 0)
                {
                    player.TripleShotPowerUpOn();
                }
                else if (PowerUPID == 1)
                {
                    player.SpeedBoostUpON();
                }
                else if (PowerUPID == 2)
                {
                    player.ShieldUpOn();
                }
            }

            Destroy(this.gameObject);
        }

    }
}