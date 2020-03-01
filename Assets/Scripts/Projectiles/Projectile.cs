﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public Vector3 direction;
        public float speed = 1.0f;
        public AudioClip bulletHit;

        // Update is called once per frame
        void Update()
        {
            transform.position += (speed * Time.deltaTime) * direction.normalized;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                SoundManager.instance.PlaySound(bulletHit);
                ApplyEffectOnPlayer();
            }
            Destroy(gameObject);
        }

        protected abstract void ApplyEffectOnPlayer();
    }
}
