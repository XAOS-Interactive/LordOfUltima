﻿using System;

namespace LordOfUltima.MGameboard
{
    public class IronElementType : IElementType
    {
        private static readonly Random Random = new Random(121);
        private readonly string _name;
        private readonly string _imagePath;
        private readonly string _detailImagePath;
        private readonly string _elementInfo;
        private readonly bool _hasLevelEnable;
        private readonly bool _isRessources;
        private readonly ElementType.type _elementType;

        public IronElementType()
        {
            _elementType = ElementType.type.RESSOURCE_IRON;
            _name = ElementType.getTypeName(_elementType);
            _isRessources = true;
            _hasLevelEnable = false;
            var select = Random.Next(1, 5);
            _imagePath = "Media/ressource/resource_iron_" + select.ToString() + ".png";
            _detailImagePath = "Media/menu/menu_iron.png";
            _elementInfo = "Each Iron Mine gains 50% for the first adjacent iron node, then 40% for each after that. The Iron Mine's production efficiency can then be increased up to 75% by an adjacent Foundry, and up to 30% by each adjacent Cottage.";
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