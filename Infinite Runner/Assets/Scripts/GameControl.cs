using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator anim;
    private bool isDead;

    public GameObject coin;
    public float coinTimer = 2.0f;
    public GameObject troll;
    public float trollTimer = 4.0f;

    public int coins;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButtonDown("Jump") && !isDead && rbody.velocity.y == 0)
        {
            rbody.AddForce(Vector2.up * 350f);
        }

        coinTimer -= Time.deltaTime;
        if (coinTimer <= 0)
        {
            Instantiate(coin, new Vector3(10.8f, Random.Range(-3.0f,2.0f), 0), Quaternion.identity);
            coinTimer = Random.Range(1.0f, 6.0f);
        }

        trollTimer -= Time.deltaTime;
        if (trollTimer <= 0)
        {
            Instantiate(troll, new Vector3(10.8f, -3, 0), Quaternion.identity);
            trollTimer = Random.Range(4.0f, 8.0f);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            isDead = true;
            anim.SetTrigger("isDead");
            StartCoroutine("Dead");
        }

        if (col.gameObject.tag.Equals("Coin") && col.GetComponent<CoinBehaviour>() != null)
        {
            coins++;
            col.GetComponent<CoinBehaviour>().pickUp();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            isDead = true;
            anim.SetTrigger("isDead");
            StartCoroutine("Dead");
        }
    }

    IEnumerator Dead()
    {
        PlayerPrefs.SetInt("currCoins", coins);
        PlayerPrefs.SetFloat("currTime", timer);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("DeadScene");
    }

}
