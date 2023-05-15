using UnityEngine;


class PlayerAnimController:MonoBehaviour
{
    playerController pl;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        pl = FindObjectOfType<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk", pl.walk);
        if (pl. isGrounded==true)
        {
            anim.SetBool("grounded",true);
        }
        else
        {
            anim.SetBool("grounded", false);
        }
        
    }
}
