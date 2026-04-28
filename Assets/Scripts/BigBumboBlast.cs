using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
public class BigBumboBlast : MonoBehaviour
{
[SerializeField] GameObject Player;
[SerializeField] float maxTapDelay = 0.3f;
public static  float cooldown =20f;
private float timer = 0f;
private GameObject[] enemies;
float lastTapTime = 0f;
    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }
    void Update()
    {
        timer += Time.deltaTime;

          if (touch.activeTouches.Count < 1)
            return;

        var touch1 = touch.activeTouches[0];

        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            float timeSinceLastTap = Time.time - lastTapTime;

            if (timeSinceLastTap <= maxTapDelay && timer >= cooldown)
            {
                timer = 0f;
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<enemyManager>().dealdamage(999);
                }
                Player.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
                lastTapTime = 0f; // reset
            }
            else
            {
                lastTapTime = Time.time;
            }
        }
    }
}
