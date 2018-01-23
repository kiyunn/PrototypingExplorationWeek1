using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject particlesPrefab;
    public int controller = 1;
    public float moveForce = 2000f;
    public float interactionRange = 0.5f;
    Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateMove();
        UpdateInteract();   
    }

    //Character move function 
    void UpdateMove()
    {
        //Characters directional input using input settings in unity
        Vector2 direction = Vector2.right * Input.GetAxis("Horizontal" + controller) + Vector2.up * Input.GetAxis("Vertical" + controller);
        if (direction.magnitude > 1)
        {
            direction = direction.normalized;

        }

        //Add force to character to make it move
        body.AddForce(direction * moveForce * Time.deltaTime);
    }

    //Picking up items function
    void UpdateInteract()
    {
        //If player hits key (button dependent on input settings in unity) 
        if (Input.GetButtonDown("Collect" + controller))
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, interactionRange, Vector2.zero, 0);
            Collectible bestCollectible = null;
            float bestDistance = float.MaxValue;

            foreach (RaycastHit2D hit in hits)
            {
                //If player's collider is in treasure object, continue to next statement below
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject == gameObject)
                {
                    continue;
                }

                Collectible treasure = hitObject.GetComponent<Collectible>();
                if (treasure)
                {
                    float distance = Vector2.Distance(transform.position, hitObject.transform.position);
                    if (distance < bestDistance)
                    {
                        bestCollectible = treasure;
                        bestDistance = distance;
                    }
                }
            }

            if (bestCollectible)
            {
                bestCollectible.Collect(this);
                Instantiate(particlesPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
