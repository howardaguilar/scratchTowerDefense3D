using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Waypoints[] navPoints;
    private Transform target;
    private Vector3 direction;
    private int index = 0;
    public float amplify = 1;
    private bool move = true;
    private Rigidbody rb;
    // Health
    private int startingHealth;
    public int health = 100;
    public HealthBar healthBar;
    // Purse
    public Purse message;
    // Start is called before the first frame update

    //Teacher stuff
    public int cashPoints = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthBar = GetComponentInChildren<HealthBar>();
        startingHealth = health;
        // Place our enemy at the start point
        //transform.position = navPoints[index].transform.position; //Makes enemies spawn at starting waypoint
        message = GameObject.Find("Purse").GetComponent<Purse>(); //Teacher found with tag
        NextWayPoint();
        
        //target = navPoints[index].transform;


        // Move towards the next waypoint
        // Retarget to the following waypoint when we reach our current waypoint
        // Repat through all of the waypoints until you reach the end
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0) && gameObject.tag == "EasyEnemy") // Always true because in Enemy Script, move elsewhere
        {
            Debug.Log(gameObject.tag);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // Clicking on any game object counts as a click for EasyEnemy, since it exists?
            {
                Debug.Log("EasyEnemy was clicked!");
                health = health - 25;
                Debug.Log(health);o
                if (health <= 0)
                {
                    message.updateScore();
                    Destroy(gameObject); // Need to figure out how to destroy just one enemy, they all have same health variable? Issue could be since it's a mouse click?
                }
            }
        } */
        if (move)
        {
            transform.Translate(direction.normalized * Time.deltaTime * amplify); // Normalize since it may act different with vectors for far away nodes


            if ((transform.position - target.position).magnitude < .1f)
            {
                NextWayPoint();
            }
        }
        
    }

    private void NextWayPoint()
    {
        if (index < navPoints.Length - 1)
        {
            index++;
            target = navPoints[index].transform;
            direction = target.position - transform.position;
        } else
        {
            move = false;
        }
        
    }

    // 
    private void destructionTime(GameObject name)
    {
        message.updateScore();
        Destroy(name);
    }

    private void OnCollisionEnter(Collision other)
    {
        // Maybe use for bullet collisions
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            message.AddCash(amount);
            Destroy(this.gameObject);
        }
        else
        {
            healthBar.Damage(health, startingHealth);
        }
    }

}
