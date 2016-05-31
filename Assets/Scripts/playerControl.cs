using UnityEngine;
using System.Collections;

public class playerControl : Photon.MonoBehaviour
{
    [SerializeField] //needs to seralize since rigidbody is private
    private Rigidbody m_Rigidbody;
    public float speed = 10f;

    private float syncDelay = 0f;
    private float syncTime = 0f;
    private float lastSynchTime = 0f;
    private Vector3 syncVelocity;
    private Vector3 syncPos;
    private Vector3 syncStartPos = Vector3.zero;
    private Vector3 syncEndPos = Vector3.zero;
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //Serialize le data
            stream.SendNext(m_Rigidbody.position);
            stream.SendNext(m_Rigidbody.velocity); 
        }
        else
        {
            //read from serialized data
            syncPos = (Vector3)stream.ReceiveNext();
            syncVelocity = (Vector3)stream.ReceiveNext();

            syncTime = 0f;
            syncDelay = Time.time - lastSynchTime; 
            lastSynchTime = Time.time;

            syncEndPos = syncPos + syncVelocity * syncDelay; //adds velocity and thereby predect the end position
            syncStartPos = m_Rigidbody.position;
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
            transform.position = Vector3.Lerp(syncStartPos, syncEndPos, syncTime / syncDelay); //prediction of position
                                                                                                         //transform.position = Vector3.Lerp(transform.position, syncPosition, Time.deltaTime *5 ); //interpolate of last known position
        }
    }

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.S))
            m_Rigidbody.MovePosition(m_Rigidbody.position + Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            m_Rigidbody.MovePosition(m_Rigidbody.position - Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            m_Rigidbody.MovePosition(m_Rigidbody.position + Vector3.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            m_Rigidbody.MovePosition(m_Rigidbody.position - Vector3.right * speed * Time.deltaTime);
    }
}
