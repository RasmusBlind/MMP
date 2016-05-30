using UnityEngine;
using System.Collections;

public class playerControl : Photon.MonoBehaviour
{

    [SerializeField] //needs to seralize because the rigidbody is private
    private Rigidbody m_Rigidbody;
    public float speed = 10f;

    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncPosition;
    private Vector3 syncVelocity;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //Serialize the data
            stream.SendNext(m_Rigidbody.position);
            stream.SendNext(m_Rigidbody.velocity); //send velocity
        }
        else
        {
            //read from serialized data
            syncPosition = (Vector3)stream.ReceiveNext();
            syncVelocity = (Vector3)stream.ReceiveNext();

            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime; //find the difference in synchronization in milisec "the snapshot"
            lastSynchronizationTime = Time.time;

            syncEndPosition = syncPosition + syncVelocity * syncDelay; //predict end position by adding velocity
            syncStartPosition = m_Rigidbody.position;
        }
    }

    void Update()
    {
        if (photonView.isMine)
        {
            InputMovement();
        }
        else
        {
            syncTime += Time.deltaTime;
            transform.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay); //prediction of position
                                                                                                         //transform.position = Vector3.Lerp(transform.position, syncPosition, Time.deltaTime *5 ); //interpolate of last known position

        }
    }


    [PunRPC]
    void ChangeColorTo(Vector3 color)
    {
        GetComponent<Renderer>().material.color = new Color(color.x, color.y, color.z, 1f);
    }

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.W))
            m_Rigidbody.MovePosition(m_Rigidbody.position + Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            m_Rigidbody.MovePosition(m_Rigidbody.position - Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            m_Rigidbody.MovePosition(m_Rigidbody.position + Vector3.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            m_Rigidbody.MovePosition(m_Rigidbody.position - Vector3.right * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 colorF = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            this.photonView.RPC("ChangeColorTo", PhotonTargets.All, colorF);
        }
    }
}
