using UnityEngine;

public class Hurtboxes : MonoBehaviour
{
    public GameObject rightHurtbox;
    public GameObject leftHurtbox;
    public GameObject downHurtbox;

    void Start()
    {
        // Ensure all hurtboxes are disabled initially
        if (rightHurtbox != null)
            rightHurtbox.SetActive(false);
        if (leftHurtbox != null)
            leftHurtbox.SetActive(false);
        if (downHurtbox != null)
            downHurtbox.SetActive(false);
    }

    void Update()
    {
        // Enable the right hurtbox when the right arrow is held down, disable otherwise.
        if (rightHurtbox != null)
            rightHurtbox.SetActive(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space));

        // Enable the left hurtbox when the left arrow is held down, disable otherwise.
        if (leftHurtbox != null)
            leftHurtbox.SetActive(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space));

        // Enable the down hurtbox when the down arrow is held down, disable otherwise.
        if (downHurtbox != null)
            downHurtbox.SetActive(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.Space));
    }
}
