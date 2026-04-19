using UnityEngine;

public class HeyMachine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float movementSpeed;
    public float horizontalBoundary = 22;

    //HayBale declarations
    public GameObject hayBalePrefab;
    public Transform hayBaleSpawnPoint;
    public float shootInterval;
    private float shootTimer;
    private void Update()
    {
        UpdateMovement();
    }
    private void UpdateMovement()
    {
        UpdateShooting();
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // 1
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) // 1
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) // 2
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }
    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHayBale();
        }
    }
    private void ShootHayBale()
    {
        Instantiate(hayBalePrefab, hayBaleSpawnPoint.position, Quaternion.identity);
    }
}
