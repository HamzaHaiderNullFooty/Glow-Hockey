using UnityEngine;
 
public class MultiplayerScript : MonoBehaviour, IResetable {
 
    private Rigidbody2D rb;
    private Vector2 startingPosition;
	public static int x, y;
 
    public Rigidbody2D Puck;
 
    public Transform PlayerBoundaryHolder;
    private Boundary playerBoundary;
 
    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;
 
    private Vector2 targetPosition;
 
    private bool isFirstTimeInOpponentsHalf = true;
    private float offsetXFromTarget;
 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
 
        playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y,
                              PlayerBoundaryHolder.GetChild(1).position.y,
                              PlayerBoundaryHolder.GetChild(2).position.x,
                              PlayerBoundaryHolder.GetChild(3).position.x);
 
        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                              PuckBoundaryHolder.GetChild(1).position.y,
                              PuckBoundaryHolder.GetChild(2).position.x,
                              PuckBoundaryHolder.GetChild(3).position.x);
 
        UiManager.Instance.ResetableGameObjects.Add(this);
 
   
        }
    }
 
    private void FixedUpdate()
    {
        if (!PuckScript.WasGoal)
        {
            
            rb.MovePosition();
        }
    }
 
    public void ResetPosition()
    {
        rb.position = startingPosition;
    }
}