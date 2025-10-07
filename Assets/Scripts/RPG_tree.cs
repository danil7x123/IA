using UnityEngine;

public class RPG_tree : MonoBehaviour
{

 public enum Estados {Patrullar, Perseguir, Atacar};

public GameObject Player;
public Estados mystate;
public float myspeed, visiondistance, visionattack;
public bool Voyovengo, estoydisparando;
public Transform Check1, Check2;
private Animator myAnimator;
public GameObject disparo;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mystate= Estados.Patrullar;
        Voyovengo= false;
        myAnimator = GetComponent<Animator>();
        estoydisparando=false;
    }

    // Update is called once per frame
    void Update()
    {
         switch (mystate)
        {
        case Estados.Patrullar:
            Patrulle();                 
            break;
        case Estados.Perseguir:
            Persigue();
            break;
        case Estados.Atacar:
            Ataque();
            break;
        default:
            print ("Incorrect intelligence level.");
            break;
        }
        
    }



public void Patrulle()
{
// VOy de un punto A a B

if (Voyovengo)
{
transform.position = Vector3.MoveTowards(transform.position, Check1.position, myspeed * Time.deltaTime);
if ( (Vector3.Distance(transform.position, Check1.transform.position) < 0.05f ) )
{
    myAnimator.Play("Tower_WalkDown");
Voyovengo = false;
}
}


else {
transform.position = Vector3.MoveTowards(transform.position, Check2.position, myspeed * Time.deltaTime);
if ((Vector3.Distance(transform.position, Check2.transform.position) < 0.05f ) )
{
     myAnimator.Play("Tower_Walk");
Voyovengo = true;
}
}


 //**********************************
// if (veo al jugador) cabio el estado a perseguir
if (Vector3.Distance(transform.position, Player.transform.position) < 1 ) 
{
    mystate = Estados.Atacar;
}
if (Vector3.Distance(transform.position, Player.transform.position) < 5 ) 
{
    mystate = Estados.Perseguir;
}
}







public void Persigue()
{
   
//Persigo al jugador

transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, myspeed * Time.deltaTime);

 //**********************************

// if (distancia del jugador < 1m) cabio el estado a atacar

if (Vector3.Distance(transform.position, Player.transform.position) < 1 ) 
{
    mystate = Estados.Atacar;
}
// if (no veo) cambio el estado a patrullar
if (Vector3.Distance(transform.position, Player.transform.position) >5 ) 
{
    mystate = Estados.Patrullar;
}
}







public void Ataque()
{
// le ataco
if (estoydisparando == false){
InvokeRepeating(nameof(Funciondisparo), 0.0f, 3.0f);
estoydisparando = true;
}
//InvokeRepeating(nameof(Funciondisparo), 0.0f, 3.0f);

 //Instantiate(disparo, transform.position, transform.rotation);
 //**********************************

// if (distancia al jugador > 1 ) cabio el estado a perseguir
if (Vector3.Distance(transform.position, Player.transform.position) >visiondistance ) 
{
    mystate = Estados.Patrullar;
}
// if (no veo) cambio el estado a patrullar
if (Vector3.Distance(transform.position, Player.transform.position) >visionattack ) 
{
    mystate = Estados.Perseguir;
}
    }


    private void Funciondisparo()

    {
            Instantiate(disparo, transform.position, transform.rotation);

    }


}

/*
public void Ataque()
{
    if (!disparo) {

InvokeRepeating(nameof(Funciondisparo), 0.0f, 3.0f);
estoydisparando = true;
    }

if (Vector3.Distance(transform.position, Player.transform.position) >visiondistance )
{

    mystate = Estados.Patrullar;
}
if (Vector3.Distance(transform.position, Player.transform.position) >visionattack )
{

    mystate = Estados.Perseguir;
}
    }

    private void Funciondisparo()

    {
            Instantiate(disparo, transform.position, transform.rotation);

    }


}

*/
