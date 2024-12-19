using System.Collections;
using UnityEngine;

enum Direction
{
    LEFT=-1,
    NOASSIGNED=0,
    RIGHT=1
}

public class PelotaController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    [SerializeField]
    GameController manager;
    [SerializeField]
    float force=1f;
    [SerializeField]
    int delay = 2;
    const int POS_Y_MIN = -3;
    const int POS_Y_MAX = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(LanzarPelota());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if(tag == "PalaIzquierda" || tag == "PalaDerecha")
        {
            Debug.Log("CHOCA con " + tag.ToString());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PorteriaIzquierda")
        {
            Debug.Log("GOL player 2");
            manager.addPointP2();
            StartCoroutine(LanzarPelota(Direction.LEFT));
        }
        if (collision.tag == "PorteriaDerecha")
        {
            manager.addPointP1();
            Debug.Log("GOL player 1");
            StartCoroutine(LanzarPelota(Direction.RIGHT));
        }
    }

    private IEnumerator LanzarPelota(Direction HorizontalDirection=Direction.NOASSIGNED)
    {

        yield return new WaitForSeconds(delay);
        float posY = Random.Range(POS_Y_MIN, POS_Y_MAX);
        transform.position = new Vector3(0, posY, 0);
        rigidBody.linearVelocity = Vector3.zero;
        if (HorizontalDirection == Direction.NOASSIGNED) 
        {
            System.Array values = System.Enum.GetValues(typeof(Direction));
            HorizontalDirection = (Direction)values.GetValue(Random.Range(0, values.Length));
        }
        float angulo = Random.Range(15, 35);
        Vector2 vector2 = new Vector2((int)HorizontalDirection*Mathf.Cos(angulo), PositiveOrNegative()*Mathf.Sin(angulo));
        rigidBody.AddForce(vector2 * force, ForceMode2D.Impulse);

    }
    private float PositiveOrNegative()
    {
        return Mathf.Pow(-1, Random.Range(1, 2));
    }
}
