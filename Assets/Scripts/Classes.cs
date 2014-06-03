using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace fk.adventureRunner{

	public class PlayerObject{

		public string characterName;
		public int xp = 0;
		public void gainXP(int amount)
		{
			amount = (int)(amount*bonusXpModifier);
			if(amount > level*100)
			{
				xp += level*100;
				amount -= level*100;
				if(xp >= (level*(level+1)*100/2))
				{
					gainLevel();
				}
				gainXP(amount);
			}
			else
			{
				xp += amount;
				if(xp >= (level*(level+1)*100/2))
				{
					gainLevel();
				}
			}
		}

		public int level = 1;
		public void gainLevel(){
			level++;
			unusedAbilityPoints++;
			hp++;
		}


		public int hp
		{
			get
			{
				return hp+strength;
			}
		}
		public int currentHp;
		public int armor;

		public int unusedAbilityPoints;
		public void spendPoint(int ability)
		{
			if(unusedAbilityPoints == 0)
			{
				throw new UnityException("not enough points")
			}
			else
			{
				switch(ability){
				case 0:
					strength++;
					break;
				case 1:
					dexterity++;
					break;
				case 2:
					intelligence++;
					break;
				default:
					break;
				}
				unusedAbilityPoints--;
			}
		}

		public int strength;		//++dmg
		public int bonusDamage
		{
			get
			{
				return (int)(strength/2);
			}
		}

		public int dexterity;		//++attack speed
		public float bonusAttackSpeed
		{
			get
			{
				return (dexterity/10);
			}
		}
		public int intelligence;	//++xp
		public float bonusXpModifier
		{
			get
			{
				return 1+intelligence/10;
			}
		}

		public Inventory playerInv;



	}

	public class Quest{

		public int id;
		public string name;
		public string text;

	}

	[System.Serializable]
	public class Item{

		public int id;
		public string name;
		public string type;

		public float currentCharge;		//current level of charge
		public float attackCharge;		//level of charge needed to attack
		public void chargeUp(){
			currentCharge += Time.deltaTime;
			currentCharge = Mathf.Clamp(currentCharge,0,attackCharge);
		}

		public int armorValue;
		public int damageValue;



	}

	[System.Serializable]
	public class Inventory{

		public int size;
		public int usedSize;
		public List<Item> inv = new List<Item>();

		public void addItem(Item a)
		{
			if(inv.Contains(a))
			{
				inv.Add(a);
			}
			else if(!inv.Contains(a))
			{
				if(size-usedSize == 0)
				{
					throw new UnityException("not enough space");
				}
				else
				{
					inv.Add(a);
					usedSize++;
				}
			}
		}
		public void removeItem(Item a)
		{
			if(inv.Contains(a))
			{
				inv.Remove(a);
				usedSize--;
			}
			else if(!inv.Contains(a))
			{
				throw new UnityException("non-existant item");
			}
		}

		public Inventory(){}
		public Inventory(int InventorySize){
			size = InventorySize;
		}
	}
}
