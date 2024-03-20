using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InventoryTests
    {
        [UnityTest]
        public IEnumerator Inventory_AddItem_Success()
        {
            // Créer un objet de collecte
            GameObject collectableObject = new GameObject();
            collectableObject.AddComponent<Rigidbody2D>();
            Collectable collectableComponent = collectableObject.AddComponent<Collectable>();
            collectable.type = CollectableType.GOLD; // Spécification du type
            

            // Créer un objet joueur
            GameObject playerObject = new GameObject();
            Player playerComponent = playerObject.AddComponent<Player>();

            // Créer un gestionnaire d'inventaire
            GameObject inventoryManagerObject = new GameObject();
            InventoryManager inventoryManagerComponent = inventoryManagerObject.AddComponent<InventoryManager>();

            // Ajouter l'inventaire du joueur dans le gestionnaire d'inventaire
            inventoryManagerComponent.inventoryByName.Add("Backpack", new Inventory(10)); // Capacité de 10 emplacements

            // Ajouter l'inventaire du joueur dans le joueur
            playerComponent.inventory = inventoryManagerComponent;

            // Ajouter un collectable à l'inventaire
            playerComponent.inventory.Add("Backpack", collectableComponent);

            // Attendre une frame pour permettre la mise à jour des inventaires
            yield return null;

            // Vérifier si l'inventaire contient l'objet ajouté
            Assert.IsTrue(playerComponent.inventory.inventoryByName["Backpack"].slots.Exists(slot => slot.GetTypeSlot == CollectableType.GOLD));
        }
    }
}