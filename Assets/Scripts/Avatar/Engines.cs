using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engines : MonoBehaviour
{
        
    private BaseAvatar avatar;
    
    private Transform avatarTransform;

    [SerializeField]
    private Vector2 speed;

    public Vector2 Speed
    {
        get => speed;
        set => speed = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        avatarTransform = GetComponent<Transform>();
        avatar = GetComponent<BaseAvatar>();
        avatarTransform.position = avatar.transform.position;
        speed = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        avatarTransform.position += new Vector3(Speed.x, Speed.y, 0) * Time.deltaTime * avatar.MaxSpeed;
    }
}
