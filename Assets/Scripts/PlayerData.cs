using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
public class PlayerData : ScriptableObject {

	public int money;

	public int[] petalsLevel; 

}
