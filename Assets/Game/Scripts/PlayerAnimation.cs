using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animmationManagement;

    // Start is called before the first frame update
    void Start()
    {
        _animmationManagement = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _animmationManagement.SetBool("Turn_Left", true);
            _animmationManagement.SetBool("Turn_Right", false);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animmationManagement.SetBool("Turn_Left", false);
            _animmationManagement.SetBool("Turn_Right", false);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _animmationManagement.SetBool("Turn_Left", false);
            _animmationManagement.SetBool("Turn_Right", true);
        }
    }
}
