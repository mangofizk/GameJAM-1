using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
public class BigBumboBlast : MonoBehaviour
{
[SerializeField] GameObject Player;
[SerializeField] float maxTapDelay = 0.3f;
public static  float cooldown =2f;
private float timer = 0f;
private GameObject[] enemies;
float lastTapTime = 0f;
private Animator animator;
    public bool blastBool;



    private void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("Starting blast");
        
    }
    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    private IEnumerator WaitForBlast()

    {
        yield return new WaitForSeconds(2f);
    }

    private float lastTimeProcked = float.MaxValue;
    void Update()
    {
        timer += Time.deltaTime;

          if (touch.activeTouches.Count < 1)
        {
            //Debug.Log("0 touch");
            return;
        }
            
        var touch1 = touch.activeTouches[0];
        Debug.Log("1 touch");
        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
           
            

            Debug.Log("Blasting early");
            if (lastTapTime >= maxTapDelay && lastTimeProcked >= cooldown)
            {
                lastTimeProcked = Time.time;
                timer = 0f;
                blastBool = true;
                animator.Play("BideBlast");
                Debug.Log("Blasting");
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<enemyManager>().dealdamage(999);
                }
                
                lastTapTime = 0f;
                StartCoroutine(WaitForBlast());
                blastBool = false;
            }
            else
            {
                lastTapTime = Time.time;
            }


        }

    }
}
