using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    public Vector2 characterPos;
    public float posX;
    public float posY;
    
    public float oldPosX;
    public float oldPosY;
    public bool facingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        oldPosX = transform.position.x;
        oldPosY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        characterPos = this.transform.position;
        posX = characterPos.x;
        posY = characterPos.y;
        
        if (posX < oldPosX && posY < oldPosY && facingRight)
        {
            Flip();
        }
        else if (posX > oldPosX && posY > oldPosY && !facingRight)
        {
            Flip();
        }
        
        oldPosX = transform.position.x;
        oldPosY = transform.position.y;
        
    }

    public void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

}
