using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class KeyDetection2 : MonoBehaviour
{
    private Material m = null;
    public ParticleSystem ps;
    public AudioSource audioClip;
    

    private void OnTriggerEnter(Collider collision)
    {
        GameObject player = collision.transform.gameObject;
        if (!player.CompareTag("Player")) return;

        String status = player.GetComponent<ChangePlayerStatus>().objectTag;
        
        //Debug.LogError(collision.gameObject.name);
        if (player.layer == LayerMask.NameToLayer("Player") && transform.gameObject.tag == status )
        {
            Debug.Log("Delivered collectible " + gameObject.tag);
            transform.parent.SendMessage("KeyImput", gameObject.tag);
            //collision.gameObject.SendMessage("HoldStatus");
            collision.gameObject.SendMessage("DropItColor", gameObject.tag);
            
            //change player color to white again
            player.GetComponent<ChangePlayerStatus>().objectTag = "Default";
            
            //change Beam material opacity
            if (m == null)
            {
                m = transform.gameObject.GetComponent<Renderer>().material;
            }
            m.SetColor("_Color",new Color(m.color.r, m.color.g, m.color.b, 0.7f));
            
            //Increase particles and velocity on particle system
            var main = ps.main;
            main.startSpeed = 1f;
            var emission = ps.emission;
            emission.rateOverTime = 80;
            var fo = ps.forceOverLifetime;
            fo.y = 2;
            
            //Play sound 
            audioClip.GetComponent<AudioSource>();
            audioClip.Play();
            

        }
        else if(collision.transform.gameObject.layer == LayerMask.NameToLayer("Hold"))
        {
            collision.gameObject.SendMessage("PickStatus", false);
        }
    }
}
