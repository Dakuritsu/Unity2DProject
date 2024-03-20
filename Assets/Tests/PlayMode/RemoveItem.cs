using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class InventoryTests
    {
        [Test]
        public void RemoveItemFromInventory()
        {
            // Créer un inventaire avec 3 emplacements
            Inventory inventory = new Inventory(3);

            // Ajouter un élément à l'emplacement 0
            inventory.slots[0].AddItem(new Collectable(CollectableType.GOLD, null, 1));

            // Vérifier que l'emplacement 0 contient un élément
            Assert.IsFalse(inventory.slots[0].IsEmpty);

            // Supprimer l'élément de l'emplacement 0
            inventory.Remove(0);

            // Vérifier que l'emplacement 0 est vide après la suppression
            Assert.IsTrue(inventory.slots[0].IsEmpty);
        }

        [Test]
        public void RemoveMultipleItemsFromInventory()
        {
            // Créer un inventaire avec 5 emplacements
            Inventory inventory = new Inventory(5);

            // Ajouter plusieurs éléments à différents emplacements
            inventory.slots[0].AddItem(new Collectable(CollectableType.GOLD, null, 2));
            inventory.slots[1].AddItem(new Collectable(CollectableType.GOLD, null, 1));
            inventory.slots[2].AddItem(new Collectable(CollectableType.GOLD, null, 3));

            // Vérifier que les emplacements contiennent les bons nombres d'éléments
            Assert.AreEqual(2, inventory.slots[0].GetCount);
            Assert.AreEqual(1, inventory.slots[1].GetCount);
            Assert.AreEqual(3, inventory.slots[2].GetCount);

            // Supprimer 1 élément de l'emplacement 0 et 2 éléments de l'emplacement 2
            inventory.Remove(0, 1);
            inventory.Remove(2, 2);

            // Vérifier que les emplacements ont les bons nombres d'éléments après la suppression
            Assert.AreEqual(1, inventory.slots[0].GetCount);
            Assert.AreEqual(1, inventory.slots[1].GetCount);
            Assert.AreEqual(1, inventory.slots[2].GetCount);
        }
    }

}