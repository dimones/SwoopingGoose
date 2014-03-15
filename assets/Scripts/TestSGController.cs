using UnityEngine;
using System.Collections;

public class TestSGController : MonoBehaviour
{


    public float movementUp = 2;
    public float movementDown = -5;

    public float multiplierUp = 5;
    public float multiplierDown = 0.1F;

    public bool isUp = false;
    public bool isDown_1 = false;
    public bool start = false;
    public bool end = false;

    //public AddBlocks posicionador;

    void Start()
    {

        Application.targetFrameRate = 40;
    }


    void Update()
    {

        if (!end)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                //audio.Play();


                if (start)
                {

                    GameObject go = GameObject.FindGameObjectWithTag("Player");
                    gameObject.transform.parent = null;
                    Destroy(go);

                   // posicionador.enabled = true;

                }


                //start = true;
                isUp = true;

                //Stop coroutines
                Stop();

                //the bird begins to rise
                ElevateBird();
            }

            if (start)
            {

                if (isUp)
                {

                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, 16)), Time.deltaTime * 6F);

                }
                if (isDown_1)
                {

                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -56)), Time.deltaTime * 13F);
                }

            }
        }
        else
        {

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -56)), Time.deltaTime * 13F);
        }
    }

    IEnumerator Up(float upTo)
    {

        isDown_1 = false;

        float i = 0;

        float positionY = transform.position.y;

        while (i < 1)
        {

            positionY = Mathf.Lerp(positionY, upTo, i);

            transform.position = new Vector3(transform.position.x, positionY, transform.position.z);

            i += Time.deltaTime * multiplierUp;

            yield return 0;
        }

        isUp = false;

        DescendBird();
    }


    IEnumerator Down(float downTo)
    {

        float i = 0;

        StartCoroutine("Aviso");

        float positionY = transform.position.y;

        while (i < 1)
        {

            positionY = Mathf.Lerp(positionY, downTo, i);

            transform.position = new Vector3(transform.position.x, positionY, transform.position.z);

            i += Time.deltaTime * multiplierDown;

            yield return 0;
        }

        DescendBird();
    }

    IEnumerator DownFinish(float downTo)
    {

        float i = 0;

        StartCoroutine("Aviso");

        float positionY = transform.position.y;

        while (i < 1)
        {

            positionY = Mathf.Lerp(positionY, downTo, i);

            transform.position = new Vector3(transform.position.x, positionY, transform.position.z);

            i += Time.deltaTime * multiplierDown;

            yield return 0;
        }

    }




    void DescendBird()
    {

        StartCoroutine("Down", movementDown);
    }

    void ElevateBird()
    {

        StartCoroutine("Up", transform.position.y + movementUp);
    }

    IEnumerator Aviso()
    {

        yield return new WaitForSeconds(0.35F);
        isDown_1 = true;
    }

    public void Stop()
    {

        StopCoroutine("Up");
        StopCoroutine("Down");
        StopCoroutine("Aviso");
    }
    public void Fin()
    {
        end = true;
        StartCoroutine("DownFinish", -2.847819);
    }
}
