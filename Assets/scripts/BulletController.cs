using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 1f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision col) // quando a bala encosta num objeto; guarda dados da colisão
    {
        Debug.Log(col.gameObject.GetComponent<Transform>().name); //comentario quando acertar o inimigo

        if (col.gameObject.CompareTag("Enemy")) //col pegou de game object o inimigo em tag
        {
            Destroy(col.gameObject); //destruindo inimigo pelo comando destroy
        }
        Destroy(gameObject);
    }

} 
