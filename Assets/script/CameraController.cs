using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 poscam;
    [SerializeField] private Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Player.position.x + poscam.x, Player.position.y+poscam.y, poscam.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Player.position.x + poscam.x, Player.position.y + poscam.y, poscam.z);
    }
}
