using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Map 3")
        {
            Debug.Log("Player is in Map 3");
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput) * Time.deltaTime * 5f;
            transform.Translate(movement, Space.World);
        }
    }


}
