using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour {

    private Rigidbody2D myRigidBody;

    [SerializeField]
    private float speed;

    public Transform MyTarget { get; private set; }

    private Transform source;

    private int damage;

	// Use this for initialization
	void Start ()
    {
        //creates a reference to the spell's rigidbody
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Transform target, int damage, Transform source)
    {
        this.MyTarget = target;
        this.damage = damage;
        this.source = source;
    }

    private void FixedUpdate()
    {
        if (MyTarget != null)
        {
            //calculates the spells direction
            Vector2 direction = MyTarget.position - transform.position;

            //Moves the spell by using the rigidbody
            myRigidBody.velocity = direction.normalized * speed;

            //calculates the rotation angle
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //rotates the spell towards the target
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HitBox" && collision.transform == MyTarget)
        {
            CharacterImun c = collision.GetComponentInParent<CharacterImun>();
            speed = 0;
            c.TakeDamage(damage, source);
            GetComponent<Animator>().SetTrigger("impact");
            myRigidBody.velocity = Vector2.zero;
            MyTarget = null;
        }
    }
}
