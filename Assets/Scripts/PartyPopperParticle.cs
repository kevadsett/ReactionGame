using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyPopperParticle : MonoBehaviour
{
    public float VelocityScale = 1;
    public float Gravity = 9.8f;
    private Vector2 Velocity;
    // Start is called before the first frame update
    void Start()
    {
        Velocity = new Vector2(Random.value * 2 - 1, Random.value * 2 - 1) * VelocityScale;
        Image MyImage = GetComponent<Image>();
        MyImage.color = new Color(Random.value, Random.value, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        Velocity.y -= Gravity * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + Velocity.x * Time.deltaTime, transform.position.y + Velocity.y * Time.deltaTime, 0);
    }
}
