﻿namespace LordOfUltima.MGameboard
{
    public class LakeElementType : IElementType
    {
        private readonly string _name;
        private readonly string _imagePath;
        private readonly string _detailImagePath;
        private readonly string _elementInfo;
        private readonly bool _hasLevelEnable;
        private readonly bool _isRessources;
        private readonly ElementType.Type _elementType;
        private readonly ElementProductionBonus _elementProductionBonus;

        public LakeElementType()
        {
            _elementType = ElementType.Type.RESSOURCE_WATER;
            _name = ElementType.GetTypeName(_elementType);
            _isRessources = true;
            _hasLevelEnable = false;
            _imagePath = "pack://application:,,,/Resources/Images/resource_lake.png";
            _detailImagePath = "pack://application:,,,/Resources/Images/menu_lake.png";
            _elementInfo = "Increases the food production efficiency of adjacent Farms by 50%.";

            // Bonus linked to fields
            _elementProductionBonus = new ElementProductionBonus(0, 0, 0, 0);
            _elementProductionBonus.IsRessourcesBonus = true;
            _elementProductionBonus.FirstBonus = 50;
            _elementProductionBonus.SecondBonus = 50;
        }

        public string Name() { return _name; }
        public bool HasLevelEnable() { return _hasLevelEnable; }
        public bool IsRessources() { return _isRessources; }
        public string GetImagePath() { return _imagePath; }
        public string GetDetailImagePath() { return _detailImagePath; }
        public string GetElementInfo() { return _elementInfo; }
        public ElementType.Type GetElementType() { return _elementType; }
        public ElementCost GetElementCost(int level) { return null; } // Return null because there is no level with ressources
        public ElementProduction GetElementProduction(int level) { return null; }
        public ElementProductionBonus GetElementProductionBonus(int level) { return _elementProductionBonus; }
        public int GetScoreValue(int level) { return 0; }
        public ElementStorage GetElementStorage(int level) { return null; }
        public bool IsMilitary() { return false; }
    }
}