﻿using System;

namespace LordOfUltima.MGameboard
{
    public class LakeElementType : IElementType
    {
        private readonly string _name;
        private readonly string _imagePath;
        private readonly string _detailImagePath;
        private readonly string _elementInfo;
        private readonly bool _hasLevelEnable;
        private readonly bool _isRessources;
        private readonly ElementType.type _elementType;

        public LakeElementType()
        {
            _elementType = ElementType.type.RESSOURCE_WATER;
            _name = ElementType.getTypeName(_elementType);
            _isRessources = true;
            _hasLevelEnable = false;
            _imagePath = "Media/ressource/resource_lake.png";
            _detailImagePath = "Media/menu/menu_lake.png";
            _elementInfo = "Increases the food production efficiency of adjacent Farms by 50%.";
        }

        public string Name() { return _name; }
        public bool HasLevelEnable() { return _hasLevelEnable; }
        public bool IsRessources() { return _isRessources; }
        public string getImagePath() { return _imagePath; }
        public string getDetailImagePath() { return _detailImagePath; }
        public string GetElementInfo() { return _elementInfo; }
        public ElementType.type GetElementType() { return _elementType; }
        public ElementCost GetElementCost(int level) { return null; } // Return null because there is no level with ressources
        public ElementProduction GetElementProduction(int level) { return null; }
    }
}