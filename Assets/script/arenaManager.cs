using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arenaManager : MonoBehaviour
{
    [SerializeField] private Mode ID = Mode.Type1;
    [SerializeField] private Animator anim;

    [SerializeField] private float speed=2;
    private bool up;

    [Header("variabel Type 2")]
    public bool buka=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ID==Mode.Type1)
        {
            NaikTurun(0.53f, -9.11f, speed);
        }
        else if (ID==Mode.Type2)
        {
            Gerbang();
        }
        
    }
    private void Gerbang()
    {
        anim.SetBool("Start",buka);
        anim.SetFloat("speed", speed);
    }
    private void NaikTurun(float Max,float Min,float Speed)
    {
        print(up);
        if (up==true)
        {
            if (transform.position.y <= Max)
            {
                transform.Translate(Vector3.up * Speed * Time.deltaTime);
            }
            else
            {
                up = false;
            }
        }
        else if (up==false)
        {
            if (transform.position.y>=Min)
            {
                transform.Translate(-Vector3.up * Speed * Time.deltaTime);
            }
            else if(transform.position.y<Min)
            {
                up = true;
            }
        }
    }
}
public enum Mode
{
    Type1,Type2
}
