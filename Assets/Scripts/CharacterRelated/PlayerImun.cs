using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImun : CharacterImun
{
    private static PlayerImun instance;

    public static PlayerImun MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerImun>();
            }

            return instance;
        }
    }

    [SerializeField]
    private Stat mana;

    private float initmana = 50;

    [SerializeField]
    private Block[] blocks;

    [SerializeField]
    private Transform[] exitPoints;

    private int exitIndex = 2;

    private Vector3 min, max;

    protected override void Start ()
    {
        mana.Initialize(initmana, initmana);
        base.Start();
    }

	// Update is called once per frame
	protected override void Update ()
    {
        //Executes the GetInput function
        GetInput();

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x),
            Mathf.Clamp(transform.position.y, min.y, max.y),
            transform.position.z);

        base.Update();
	}

    //Listen to the player input
    private void GetInput()
    {
        Direction = Vector2.zero;

        //THIS IS USE FOR DEBUGGING ONLY
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
            mana.MyCurrentValue -= 10;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
            mana.MyCurrentValue += 10;
        }

        if (Input.GetKey(KeybindManager.MyInstance.Keybinds["UP"]))
        {
            exitIndex = 0;
            Direction += Vector2.up;
        }

        if (Input.GetKey(KeybindManager.MyInstance.Keybinds["LEFT"]))
        {
            exitIndex = 3;
            Direction += Vector2.left;
        }

        if (Input.GetKey(KeybindManager.MyInstance.Keybinds["DOWN"]))
        {
            exitIndex = 2;
            Direction += Vector2.down;
        }

        if (Input.GetKey(KeybindManager.MyInstance.Keybinds["RIGHT"]))
        {
            exitIndex = 1;
            Direction += Vector2.right;
        }

        if (IsMoving)
        {
            StopAttack();
        }

        foreach (string action in KeybindManager.MyInstance.ActionsBinds.Keys)
        {
            if (Input.GetKeyDown(KeybindManager.MyInstance.ActionsBinds[action]))
            {
                UIManager.MyInstance.ClickActionButton(action);
            }
        }
    }

    public void SetLimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }

    private IEnumerator Attack(string spellName)
    {
        Transform currentTarget = MyTarget;

        Spell newSpell = SpellBook.MyInstance.CastSpell(spellName);

        IsAttacking = true;
        MyAnimator.SetBool("attack", IsAttacking); //starts the attack animations

        yield return new WaitForSeconds(newSpell.MyCastTime); //This is a hardcoded cast time, for debugging

        if (currentTarget != null && InLineOfSight())
        {
            SpellScript s = Instantiate(newSpell.MySpellPrefab, exitPoints[exitIndex].position, Quaternion.identity).GetComponent<SpellScript>();
            s.Initialize(currentTarget, newSpell.MyDamage, transform);
        } 

        StopAttack(); //Ends the attack
    }

    public void CastSpell(string spellName)
    {
        Block();

        if (MyTarget != null && MyTarget.GetComponentInParent<CharacterImun>().IsAlive && !IsAttacking && !IsMoving && InLineOfSight())
        {
            attackRoutine = StartCoroutine(Attack(spellName));
        }
    }

    private bool InLineOfSight()
    {
        if (MyTarget != null)
        {
            Vector3 targetDirection = (MyTarget.transform.position - transform.position).normalized;

       RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, Vector2.Distance(transform.position, MyTarget.transform.position), 256);

            if (hit.collider == null)
            {
                return true;
            }
        }

        return false;
    }

    private void Block()
    {
        foreach (Block b in blocks)
        {
            b.Deactivate();
        }

        blocks[exitIndex].Activate();
    }

    public void StopAttack()
    {
        SpellBook.MyInstance.StopCating();

        IsAttacking = false;
        MyAnimator.SetBool("attack", IsAttacking);

        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
        }
    }
}
