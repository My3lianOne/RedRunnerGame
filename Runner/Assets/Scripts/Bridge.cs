using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Оператор моста.
/// </summary>
public class Bridge : MonoBehaviour {

    /// <summary>
    /// Ссылка на рычаг-активатор.
    /// </summary>
    [SerializeField]
	private Crank activator;

	void Awake() {

        // Подписываемся на активацию.
		activator.CrankOn += Activate;    
	}

    /// <summary>
    /// Обработчик события активации.
    /// </summary>
	public void Activate() {

        // Получаем джоинты моста
		HingeJoint2D [] joints =  GetComponentsInChildren<HingeJoint2D>();

        // Проходим по всем джоинтам
        // для тех случаев, если у моста две створки (как в Питере).
        foreach (HingeJoint2D joint in joints)
        {
            JointMotor2D jointMotor = joint.motor;
            jointMotor.motorSpeed = -100;
            joint.motor = jointMotor;
        }
	}
}
