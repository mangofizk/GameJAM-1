using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float MoveSpeed = 5;

    [SerializeField] private GameObject Player; 


    private Vector3 target;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        target = Player.transform.position;

        //target = PlayerLocation;

        transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);
    }
}
