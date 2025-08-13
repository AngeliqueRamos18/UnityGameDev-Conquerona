using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveCharacter : MonoBehaviour
{
    public Vector2 characterPos;
    private Transform target;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        characterPos = this.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Debug.Log(characterPos);
    }
}
