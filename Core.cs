using Alta;
using Alta.Caves;
using MelonLoader;
using System.Reflection;
using UnityEngine;
using CustomDistributionAPI;

[assembly: MelonInfo(typeof(MaterialDistributionAPI.Core), "MaterialDistributionAPI", "1.0.0", "CGNik", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace MaterialDistributionAPI
{
    public class Core : MelonMod
    {
        public static Distribution wyrmMaterialDistribution;
        public static Distribution crystalWyrmMaterialDistribution;
        public static Distribution canvasMaterialDistribution;
        public static Distribution ropeMaterialDistribution;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }

        public override void OnLateInitializeMelon()
        {
            wyrmMaterialDistribution = CustomDistributionAPI.Core.CreateEmptyDistribution(49221, "Wyrm Material Distribution", 0f);
            CustomDistributionAPI.Core.AddToDistribution(wyrmMaterialDistribution, PhysicalMaterial.All.Where(mat => mat.Hash == 63538u).First(), 1f, 1f, new AttributeCurveRange[] { });
            crystalWyrmMaterialDistribution = CustomDistributionAPI.Core.CreateEmptyDistribution(49222, "Crystal Wyrm Material Distribution", 0f);
            CustomDistributionAPI.Core.AddToDistribution(crystalWyrmMaterialDistribution, PhysicalMaterial.All.Where(mat => mat.Hash == 63538u).First(), 1f, 1f, new AttributeCurveRange[] { });
            GameObject wyrm = (GameObject)Resources.Load("network prefabs/creatures/monsters/wyrms/Wyrm");
            PhysicalMaterialPart physicalMaterialPart_wyrm = wyrm.GetComponent<PhysicalMaterialPart>();
            typeof(PhysicalMaterialPart).GetField("materialDistribution", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(physicalMaterialPart_wyrm, Core.wyrmMaterialDistribution);
            GameObject crystalWyrm = (GameObject)Resources.Load("network prefabs/creatures/monsters/wyrms/Crystal Wyrm");
            PhysicalMaterialPart physicalMaterialPart_crystalWyrm = crystalWyrm.GetComponent<PhysicalMaterialPart>();
            typeof(PhysicalMaterialPart).GetField("materialDistribution", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(physicalMaterialPart_crystalWyrm, Core.crystalWyrmMaterialDistribution);
            GameObject wyrmTrial = (GameObject)Resources.Load("network prefabs/creatures/monsters/trial monster spawners/Wyrm (Trial)");
            PhysicalMaterialPart physicalMaterialPart_wyrmTrial = wyrmTrial.GetComponent<PhysicalMaterialPart>();
            typeof(PhysicalMaterialPart).GetField("materialDistribution", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(physicalMaterialPart_wyrmTrial, Core.wyrmMaterialDistribution);
            GameObject crystalWyrmTrial = (GameObject)Resources.Load("network prefabs/creatures/monsters/trial monster spawners/Crystal Wyrm (Trial)");
            PhysicalMaterialPart physicalMaterialPart_crystalWyrmTrial = crystalWyrmTrial.GetComponent<PhysicalMaterialPart>();
            typeof(PhysicalMaterialPart).GetField("materialDistribution", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(physicalMaterialPart_crystalWyrmTrial, Core.crystalWyrmMaterialDistribution);

            canvasMaterialDistribution = CustomDistributionAPI.Core.CreateEmptyDistribution(49223, "Canvas Material Distribution", 0f);
            CustomDistributionAPI.Core.AddToDistribution(canvasMaterialDistribution, PhysicalMaterial.All.Where(mat => mat.Hash == 61790u).First(), 1f, 1f, new AttributeCurveRange[] { });
            GameObject canvas = (GameObject)Resources.Load("network prefabs/crafting/crafting materials prefabs/Thin Cloth Medium Square");
            PhysicalMaterialPart physicalMaterialPart_canvas = canvas.GetComponent<PhysicalMaterialPart>();
            typeof(PhysicalMaterialPart).GetField("materialDistribution", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(physicalMaterialPart_canvas, Core.canvasMaterialDistribution);
            GameObject oreSidePouchAttachment = (GameObject)Resources.Load("network prefabs/props/inventory/Ore Side Pouch Attachment");
            oreSidePouchAttachment.transform.Find("Mesh").Find("ore_bag_attachment_cloth_cover").gameObject.SetActive(false);

            ropeMaterialDistribution = CustomDistributionAPI.Core.CreateEmptyDistribution(49224, "Rope Material Distribution", 0f);
            CustomDistributionAPI.Core.AddToDistribution(ropeMaterialDistribution, PhysicalMaterial.All.Where(mat => mat.Hash == 35204u).First(), 1f, 1f, new AttributeCurveRange[] { });
            GameObject ropeClump = (GameObject)Resources.Load("network prefabs/crafting/crafting materials prefabs/Rope Clump");
            PhysicalMaterialPart physicalMaterialPart_ropeClump = ropeClump.GetComponent<PhysicalMaterialPart>();
            typeof(PhysicalMaterialPart).GetField("materialDistribution", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(physicalMaterialPart_ropeClump, Core.ropeMaterialDistribution);
        }
    }
}