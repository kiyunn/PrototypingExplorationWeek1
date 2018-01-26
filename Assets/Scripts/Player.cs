using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject particlesPrefab;
    public int controller = 1;
    public float moveForce = 2000f;
    public float interactionRange = 0.5f;
    public TextMesh scoreText;
    int score;

    Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Calls Move and Interact functions
        UpdateMove();
        UpdateInteract();
        scoreText.gameObject.transform.localScale = Vector3.Slerp(scoreText.gameObject.transform.localScale, new Vector3(0.1f, 0.1f, 0.1f), 10f * Time.deltaTime);
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

    //Interaction with items function
    void UpdateInteract()
    {
        //If player hits key (button dependent on input settings in unity) 
        if (Input.GetButtonDown("Collect" + controller))
        {
            //Local Variables for interact function
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, interactionRange, Vector2.zero, 0);
            Collectible bestCollectible = null;
            float bestDistance = float.MaxValue;

            foreach (RaycastHit2D hit in hits)
            {
                //Detects, filters and ignore any object that is not a collectible item (another Player)
                //Continue to loop and filter the next object detected
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject == gameObject)
                {
                    continue;
                }

                //Get treasure script component
                Collectible treasure = hitObject.GetComponent<Collectible>();

                //if the gameobject detected is a collectable, then calculate the distance between the player and collectable
                //if the player is in range distance of collectible, then allow collectable interaction
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

            //If collectable, tries to collect object (Jess's script) and create particle effects when button is pressed
            if (bestCollectible)
            {
                bestCollectible.Collect(this);
                Instantiate(particlesPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    //Add Score function
    //Connects score value to text mesh to show score and transforms local scale of text score
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        scoreText.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    public int GetScore()
    {
        return score;
    }

}
