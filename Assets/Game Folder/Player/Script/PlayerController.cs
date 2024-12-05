using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 vel;
    public AudioSource audioSource;
    public AudioClip attack1Sound;
    public AudioClip attack2Sound;
    public AudioClip dashSound;
    public AudioClip damageSound;

    public Transform gameOverScreen;
    public Transform pauseScreen;
    public Transform floorCollider;
    public Transform skin;


    public int comboNum;
    public float comboTime;
    public float dashTime;

    public LayerMask floorLayer;

    public string currentLevel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Comando utilizado para inicalizar o jogo com o personagem com corpo rídigdo
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        currentLevel = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame

    // para atualizar o personagem
    void Update()
    {
        //dados da cena em que meu personagem se encontra
        if (!currentLevel.Equals(SceneManager.GetActiveScene().name))
        {
            currentLevel = SceneManager.GetActiveScene().name;
            transform.position = GameObject.Find("Spawn").transform.position;
        }
        //comando de morte
        if (GetComponent<Character>().life <= 0)
        {
            gameOverScreen.GetComponent<GameOver>().enabled = true;
            rb.simulated = false;
            this.enabled = false;
        }
        //comando de dash
        dashTime = dashTime + Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && dashTime > 0.5f)
        {
            audioSource.PlayOneShot(dashSound, 0.5f);

            dashTime = 0;
            skin.GetComponent<Animator>().Play("Player Dash", -1);
            rb.linearVelocity = Vector2.zero;
            rb.AddForceX(skin.localScale.x * 950);
        }

        // dados de combo + contador de combo de ataque
        comboTime = comboTime + Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && comboTime > 0.5f)
        {
            comboNum++;
            if (comboNum > 2)
            {
                comboNum = 1;
            }

            comboTime = 0;
            skin.GetComponent<Animator>().Play("Player Attack " + comboNum, -1);
            if (comboNum == 1)
            {
                audioSource.PlayOneShot(attack1Sound, 1);
            }
            if (comboNum == 2)
            {
                audioSource.PlayOneShot(attack2Sound, 1);
            }

        }
        if (comboTime >= 1)
        {
            comboNum = 0;
        }

        // salto
        bool canJump = Physics2D.OverlapCircle(floorCollider.position, 0.1f, floorLayer);
        if (canJump && Input.GetButtonDown("Jump") && comboTime > 0.5f)
        {
            skin.GetComponent<Animator>().Play("Player Jump", -1);
            rb.linearVelocity = Vector2.zero;
            rb.AddForceY(950);
        }
        // movimentação / animação de direção da movimentação
        vel = new Vector2(Input.GetAxisRaw("Horizontal") * 7, rb.linearVelocityY);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            skin.GetComponent<Animator>().SetBool("PlayerRun", true);
        }

        else
        {
            skin.GetComponent<Animator>().SetBool("PlayerRun", false);
        }
        //comando para pause
        if (Input.GetButtonDown("Cancel"))
        {
            pauseScreen.GetComponent<Pause>().enabled = !pauseScreen.GetComponent<Pause>().enabled;
        }
    }
    private void FixedUpdate()
    {
        if (dashTime > 0.5)
        {
            rb.linearVelocity = vel;
        }

    }
    public void DestroyPlayer()
    {
        Destroy(transform.gameObject);
    }
}
