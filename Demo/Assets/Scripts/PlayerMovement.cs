using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private GamePanel gamePanel;

    Rigidbody2D rbody;
    Animator anim;

    public PlayerSavedData data;

    public bool canMove;
    public bool run;
    
	// Use this for initialization
	void Start () {
        gamePanel = FindObjectOfType<GamePanel>();
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
        anim.SetFloat("input_y", -1.0f);
        
        canMove = false;
        run = false;


	}
	
	// Update is called once per frame
	void Update () {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));///this input.getaxisraw simply return boolean value
        if(!canMove)
        {
            rbody.velocity = Vector2.zero;
            return;
        }
        if(movement_vector.x!=0&&movement_vector.y!=0)
        {
            movement_vector.x /= 1.414f;
            movement_vector.y /= 1.414f;
        }
        if (movement_vector!=Vector2.zero)///vector.zero is no input
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movement_vector.x);/////only when there is input, then the player move or face different direction.
            anim.SetFloat("input_y", movement_vector.y);
          
        }
        else
        {
            anim.SetBool("iswalking", false);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        if (!run)
        {
            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
            
        }
        else
        {
            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime*3);
        }
       




       
	}

    public void save()
    {
        data.canMove = this.canMove;
        data.run = this.run;
        data.position=this.rbody.position;
        data.AnimX=this.anim.GetFloat("input_x");
        data.AnimY=this.anim.GetFloat("input_y");

        gamePanel.thisGame.playerData = data;

        Debug.Log("yeas");
    }

    public void load()
    {
        data = gamePanel.thisGame.playerData;

        this.canMove = data.canMove;
        this.run = data.run;
        this.rbody.position=data.position;
       this.anim.SetFloat("input_x", data.AnimX);
       this.anim.SetFloat("input_y", data.AnimY);
    }

}

[System.Serializable]
public struct PlayerSavedData
{
    public Vector3 position;
    public float AnimX;
    public float AnimY;
    public bool canMove;
    public bool run;
}
