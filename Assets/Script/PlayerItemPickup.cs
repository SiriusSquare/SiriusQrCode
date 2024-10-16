using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemPickup : MonoBehaviour
{
    public string itemTag = "Weapon";
    public Transform container;
    private Transform equippedWeapon;
    public Vector3 equippedWeaponScale = new Vector3(5f, 5f, 5f);
    public Vector3 containerWeaponScale = new Vector3(1f, 1f, 1f);
    private float transparentAlpha = 0f;


    public void PickupWeapon(GameObject weaponPrefab)
    {

        if (equippedWeapon != null)
        {
            equippedWeapon.SetParent(container);
            equippedWeapon.localPosition = Vector3.zero;
            equippedWeapon.localScale = containerWeaponScale;
            SetWeaponTransparency(equippedWeapon, transparentAlpha); 
        }

        // 새로운 무기 생성 및 장착
        GameObject newWeapon = Instantiate(weaponPrefab, transform);
        EquipWeapon(newWeapon.transform);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag(itemTag))
        {

            if (equippedWeapon != null)
            {

                equippedWeapon.SetParent(container);
                equippedWeapon.localPosition = Vector3.zero;
                equippedWeapon.localScale = containerWeaponScale;
                SetWeaponTransparency(equippedWeapon, transparentAlpha); 


                EquipWeapon(other.transform);
            }
            else
            {

                EquipWeapon(other.transform);
            }
        }
    }

    void EquipWeapon(Transform newWeapon)
    {

        newWeapon.SetParent(transform);
        newWeapon.localPosition = Vector3.zero;


        newWeapon.localScale = equippedWeaponScale;

   
        SetWeaponTransparency(newWeapon, 1f);


        equippedWeapon = newWeapon;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && equippedWeapon != null)
        {

            equippedWeapon.SetParent(container);
            equippedWeapon.localPosition = Vector3.zero;
            equippedWeapon.localScale = containerWeaponScale;
            SetWeaponTransparency(equippedWeapon, transparentAlpha);


            if (container.childCount > 0)
            {

                Transform weaponInContainer = container.GetChild(0);
                EquipWeapon(weaponInContainer);
            }
            else
            {

                equippedWeapon = null;
            }
        }
    }


    void SetWeaponTransparency(Transform weapon, float alpha)
    {

        SpriteRenderer weaponSprite = weapon.GetComponent<SpriteRenderer>();
        if (weaponSprite != null)
        {
            Color color = weaponSprite.color;
            color.a = alpha;
            weaponSprite.color = color;
        }


        foreach (Transform child in weapon)
        {
            SetWeaponTransparency(child, alpha);
        }
    }

}

