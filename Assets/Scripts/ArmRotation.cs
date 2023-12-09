// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public float maxRotationAngle = 45f; // Maksimum d�nd�rme a��s�

    // Update is called once per frame
    void Update()
    {
        // Mouse pozisyonunu al
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Karakterin pozisyonunu al
        Vector3 characterPosition = transform.parent.position;

        // Mouse'un karaktere g�re konumunu hesapla
        Vector3 direction = mousePosition - characterPosition;
        direction.Normalize();

        // Mouse'un y�n�ndeki a��y� hesapla ve s�n�rla
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -maxRotationAngle, maxRotationAngle);

        // Kolun rotasyonunu ayarla (z de�eri eksi olmayacak)
        transform.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}



