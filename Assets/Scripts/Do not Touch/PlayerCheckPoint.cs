using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    public static PlayerCheckPoint instance;

    private GameObject playerObject;

    private void Awake()
    {
        instance = this;

        playerObject = GameObject.FindWithTag("Player");

        OnLevelReset();
    }

    public void OnLevelReset()
    {
        playerObject.transform.position = transform.position;
    }
}
