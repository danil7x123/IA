using UnityEngine;

public class RPGScript : MonoBehaviour
{
        int vida;
        int edad;
        float altura;
        bool estoyVivo;
        string nombrePersonaje;
        public float velocidad;
        private Animator myAnimator;
     //   public GameObject disparo;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("check");
        vida = 100;
        velocidad = 5;
        myAnimator = GetComponent<Animator>();

    
    }

    // Update is called once per frame
    void Update()
    {
    
        
        if (Input.GetKey(KeyCode.A))
        {
            myAnimator.Play("RPG_WalkSide");
            //Debug.Log("move to the left");
            transform.Translate(Vector3.left * Time.deltaTime * velocidad, Space.World);
            transform.eulerAngles = new Vector3(0,180,0);
        } 
        if (Input.GetKey(KeyCode.D))
        {
            myAnimator.Play("RPG_WalkSide");
            //Debug.Log("move to the right");
            transform.Translate(Vector3.right * Time.deltaTime * velocidad, Space.World);
            transform.eulerAngles = new Vector3(0,0,0);

        }
        if (Input.GetKey(KeyCode.W))
        {
            myAnimator.Play("RPG_WalkBack");
            //Debug.Log("move up");
            transform.Translate(Vector3.up * Time.deltaTime * velocidad, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myAnimator.Play("RPG_WalkFront");
            //Debug.Log("move down");
            transform.Translate(Vector3.down * Time.deltaTime * velocidad, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
          //  Instantiate(disparo, transform.position, transform.rotation);
            myAnimator.Play("RPG_AttackFront");
        }
        if(!Input.anyKey)
        {
            myAnimator.Play("RPG_Idle");
        }
    }

}
