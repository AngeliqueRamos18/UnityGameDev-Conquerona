using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJoystickRotation : MonoBehaviour
{
	public Joystick joystick;
	public GameObject Object;
	Vector2 GameobjectRotation;
	private float GameobjectRotation2;
	private float GameobjectRotation3;

	public bool FacingRight = true;

	public bool windowsVer;

	void Update()
	{

		switch (windowsVer)
		{
			default:
				Debug.Log("No Version");
				break;
			case true:
				Debug.Log("Windows");
				break;
			case false:
				Debug.Log("Android Ver");
				//Gets the input from the jostick
				GameobjectRotation = new Vector2(joystick.Horizontal, joystick.Vertical);
				GameobjectRotation3 = GameobjectRotation.x;

				if (FacingRight)
				{
					//Rotates the object if the joystick is facing right
					GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * 90;
					Object.transform.rotation = Quaternion.Euler(0f, 0f, GameobjectRotation2);
				}
				else
				{
					//Rotates the object if the joystick is facing left
					GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * -90;
					Object.transform.rotation = Quaternion.Euler(0f, 180f, -GameobjectRotation2);
				}
				if (GameobjectRotation3 < 0 && FacingRight)
				{
					// Executes the void: Flip()
					Flip();
				}
				else if (GameobjectRotation3 > 0 && !FacingRight)
				{
					// Executes the void: Flip()
					Flip();
				}
				break;
		}

	}
	private void Flip()
	{
		// Flips the weapon
		FacingRight = !FacingRight;
		Object.transform.Rotate(0, 180, 0);
	}
}
