using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("movimento")] //titulos unity
    public float moveSpeed = 5f; //classes visiveis

    [Header("Mouse")] //titulos unity
    public float mouseSensitivity = 2f; //classes visiveis
    public float verticalClamp = 60f; //classes visiveis

    [Header("Referências")] //titulos unity
    public Transform cameraContainer; //classes visiveis

    [Header("tiro")] //titulos unity
    public GameObject bulletPrefab; //classes visiveis
    public Transform muzzle; //classes visiveis
    private float verticalRotation = 0f; //classes visiveis


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     Cursor.lockState = CursorLockMode.Locked; //faz sumir o cursor do mouse
    }

    // Update is called once per frame
    void Update()  
    {
        // Rotação horizontal do player  (eixo --- y)
        float mouseX = Input.GetAxis("Mouse X"); // criação de variavel  input = import getAxis = pega do propriedaades
        transform.Rotate(0f, mouseX, 0f); // transforma a rotação do player quando utilizado t minusculo 
        // T maiusculo cria um tipo
        // gameObject adiciona objeto tipo de variavel 
        //float tipo de variavel
        // rotate rotação
        //Quaternion
        //Euler
        //direction
        // Vertical rotation rotação vertical 
       
        //Rotação vertical da Camera (eixo x local)
        float mouseY = Input.GetAxis("Mouse Y");
        verticalRotation -= mouseY; //+= soma e igual a algo ou -= subtrai e igual a algo
        verticalRotation -= Mathf.Clamp(verticalRotation, -verticalClamp, verticalClamp); //mathf.clamp  clamp limitar 
        cameraContainer.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f); 
        //troca rotação local; local em relação a mim, em base de uma posição.


        //Movimento Wasd / setas
        float h = Input.GetAxis("Horizontal"); // movimento em horizontal  entrando numa variavel do tipo float
        float v = Input.GetAxis("Vertical"); // movimento em horizontal  entrando numa variavel do tipo float
        Vector3 direction = transform.right * h + transform.forward * v; //variavel nome direction do tipo vector
        transform.position += direction * moveSpeed * Time.deltaTime; // transform a posição da direção somando e juntando a velocidade de movimento em segundos

        // fazer tiro
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("atirou");
            Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        }
    }
}
