﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Advize_PlantEverything.Framework
{
	internal class PrefabDB
	{
		internal string key;
		internal int biome;
		internal int resourceCost;
		internal int resourceReturn;
		internal bool extraDrops;
		internal bool icon;
		internal bool enabled = true;
		
		internal GameObject Prefab
		{
			get { return PlantEverything.prefabRefs[key]; }
		}
	}
	
	internal class PieceDB : PrefabDB
	{
		private Dictionary<string, int> resources;
		internal int respawnTime;
		internal bool recover;
		internal Piece piece;
		internal List<Vector3> points;
		
		internal KeyValuePair<string, int> Resource
		{
			get { return Resources.Count > 0 ? Resources.First() : new KeyValuePair<string, int>(Prefab.GetComponent<Pickable>().m_itemPrefab.name, resourceCost); }
			set { if (resources == null) { resources = new Dictionary<string, int>(); } if (!resources.ContainsKey(value.Key)) resources.Add(value.Key, value.Value); }
		}
		
		internal Dictionary<string, int> Resources
		{
			get { return resources ?? new Dictionary<string, int>(); }
			set { resources = value; }
		}
		
		internal int ResourceCost
		{
			get { return resourceCost; }
			set { resourceCost = value; enabled = value != 0; }
		}
	}
	
	internal class SaplingDB : PrefabDB
	{
		internal string source;
		internal string resource;
		internal float growTime;
		internal float growRadius;
		internal float minScale;
		internal float maxScale;
		internal GameObject[] grownPrefabs;
	}
}
