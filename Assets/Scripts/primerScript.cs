using UnityEngine;

public class primerScript : MonoBehaviour
{
        int vida;
        int edad;
        float altura;
        bool estoyVivo;
        string nombrePersonaje;
        public float velocidad;
        private Animator myAnimator;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("check");
        vida = 100;
        //velocidad = 5;
        myAnimator = GetComponent<Animator>();

    
    }

    // Update is called once per frame
    void Update()
    {
        
        //si (presiono letra D) entonces muevete a la derecha
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space key is held down");
        }
        if (Input.GetKey(KeyCode.A))
        {
            myAnimator.Play("Player_Run");
            //Debug.Log("move to the left");
            transform.Translate(Vector3.left * Time.deltaTime * velocidad, Space.World);

        } 
        if (Input.GetKey(KeyCode.D))
        {
            myAnimator.Play("Player_Run");
            //Debug.Log("move to the right");
            transform.Translate(Vector3.right * Time.deltaTime * velocidad, Space.World);
        }
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("move up");
            transform.Translate(Vector3.up * Time.deltaTime * velocidad, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("move down");
            transform.Translate(Vector3.down * Time.deltaTime * velocidad, Space.World);
        }
        /*
        if(!Input.anyKey)
        {
            myAnimator.Play("Player_Idle");
        }
        */
    }
}
