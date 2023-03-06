using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUpController : MonoBehaviour
{
    private Rigidbody itemRb;
    private Collider itemCol;
    public Transform itemSlot;
    private Transform itemTransform;
    public GameObject cam;

    public LayerMask whatIsItem;

    public float raycastRange = 75f;
    private float pickUpDistance = 5;

    private float holdDownStart;
    private float holdDownEnd;
    [SerializeField] private const float maxHoldTime = 1.5f;
    [SerializeField] private const float maxForce = 15;
    public Text uiText;


    private bool slotFull = false;
    private void Awake()
    {
        if (slotFull == false)
        {
            uiText.text = "Hands";
        }
    }
    private void Update()
    {
        RaycastHit hit;
        //Vector3 distanceToPlayer = transform.position - itemTransform.position;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, raycastRange, whatIsItem))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.red);
            if (hit.collider.tag == "item")
            {
                if (Input.GetKeyDown(KeyCode.E) && slotFull == false)
                {
                    itemTransform = hit.transform;
                    itemRb = hit.rigidbody;
                    itemCol = hit.collider;
                    PickUp();
                }
            }

        }

        if (slotFull && Input.GetKeyDown(KeyCode.Q))
        {
            holdDownStart = Time.time;
        }
        if (slotFull && Input.GetKeyUp(KeyCode.Q))
        {
            holdDownEnd = Time.time - holdDownStart;
            if (holdDownEnd > maxHoldTime)
            {
                holdDownEnd = maxHoldTime;
            }
            Drop();
        }

    }

    private void PickUp()
    {
        slotFull = true;
        itemTransform.SetParent(itemSlot);
        itemTransform.localPosition = Vector3.zero;
        itemTransform.localRotation = Quaternion.Euler(Vector3.zero);
        itemTransform.localScale = Vector3.one;

        itemRb.isKinematic = true;
        itemCol.isTrigger = true;
        uiText.text = itemCol.name;

    }
    private void Drop()
    {

        slotFull = false;

        itemTransform.SetParent(null);

        itemRb.isKinematic = false;
        itemCol.isTrigger = false;
        float force = Mathf.Clamp01(holdDownEnd / maxHoldTime);

        //itemRb.velocity = this.GetComponent<Rigidbody>().velocity;
        itemRb.AddForce(cam.transform.forward * force * maxForce, ForceMode.Impulse);
        itemRb.AddForce(cam.transform.up * (force * maxForce) / 2, ForceMode.Impulse);

        float random = Random.Range(-1f, 1f);
        itemRb.AddTorque(new Vector3(random, random, random) * 10);
        uiText.text = "Hands";
    }


}
