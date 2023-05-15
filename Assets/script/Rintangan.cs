using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rintangan : MonoBehaviour
{
    [SerializeField] private string TagPlayer;
    [SerializeField] private Animation anim;
    [SerializeField] private type tipe = type.pembatas;
    [SerializeField] private arenaManager am;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagPlayer))
        {
            if (tipe==type.pembatas)
            {
                gameObject.SetActive(false);
            }
            else if (tipe==type.tombol)
            {
                anim.Play();
                am.buka = true;
            }
        }
    }
}
public enum type
{
    pembatas, tombol
}