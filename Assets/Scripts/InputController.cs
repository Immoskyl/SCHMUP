using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Engines _engine;

    private BulletGun _bulletGun;
    
    // Start is called before the first frame update
    void Start()
    {
        _engine = GetComponent<Engines>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _bulletGun = GetComponent<BulletGun>();
            _bulletGun.Fire();
        }
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _engine.Speed = new Vector2(moveHorizontal, moveVertical);

    }
}
