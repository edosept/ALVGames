using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class CharacterImun : MonoBehaviour {

    //The Player movement speed
    [SerializeField]
    private float speed;

    public Animator MyAnimator { get; set; }

    //The Player direction
    private Vector2 direction;

    private Rigidbody2D myRigidbody;

    public bool IsAttacking { get; set; }

    protected Coroutine attackRoutine;

    [SerializeField]
    protected Transform hitBox;

    [SerializeField]
    protected Stat health;

    public Transform MyTarget { get; set; }

    public Stat MyHealth
    {
        get { return health; }
    }

    [SerializeField]
    private float initHealth;

    public bool IsMoving
    {
        get
        {
            return Direction.x != 0 || Direction.y != 0;
        }
    }

    public Vector2 Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public bool IsAlive
    {
        get
        {
           return health.MyCurrentValue > 0;
        }
    }

    // Use this for initialization
    protected virtual void Start ()
    {
        health.Initialize(initHealth, initHealth);
        myRigidbody = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        HandleLayers();
	}

    private void FixedUpdate()
    {
        Move();
    }

    //Moves the player
    public void Move()
    {
        if (IsAlive)
        {
            //Makes sure that the player moves
            myRigidbody.velocity = Direction.normalized * Speed;
        }
    }

    public void HandleLayers()
    {
        if (IsAlive)
        {
            if (IsMoving)
            {
                ActivateLayer("WalkLayer");

                MyAnimator.SetFloat("x", Direction.x);
                MyAnimator.SetFloat("y", Direction.y);
            }

            else if (IsAttacking)
            {
                ActivateLayer("AttackLayer");
            }
            else
            {
                ActivateLayer("IdleLayer");
            }
        }
        else
        {
            ActivateLayer("DeathLayer");
        }
    }

    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < MyAnimator.layerCount; i++)
        {
            MyAnimator.SetLayerWeight(i, 0);
        }

        MyAnimator.SetLayerWeight(MyAnimator.GetLayerIndex(layerName), 1);  
    }

    public virtual void TakeDamage(float damage, Transform source)
    {
        health.MyCurrentValue -= damage;

        if (health.MyCurrentValue <= 0)
        {
            Direction = Vector2.zero;
            myRigidbody.velocity = Direction;
            MyAnimator.SetTrigger("die");
        }
    }
}
