using UnityEngine;

public class PalaController : MonoBehaviour
{

    const float MAX_Y = 5f;
    const float MIN_Y = -5f;
    [SerializeField]
    float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("PalaDerecha"))
        {
            if (Input.GetKey("up") && transform.position.y < MAX_Y)
            {
                transform.Translate(Vector3.up*speed*Time.deltaTime);
            }
            if (Input.GetKey("down") && transform.position.y > MIN_Y)
            {
                transform.Translate(Vector3.down*speed*Time.deltaTime);
            }
        }
        if (gameObject.CompareTag("PalaIzquierda")) {

            if (Input.GetKey("w") && transform.position.y < MAX_Y)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetKey("s") && transform.position.y > MIN_Y)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }
}
