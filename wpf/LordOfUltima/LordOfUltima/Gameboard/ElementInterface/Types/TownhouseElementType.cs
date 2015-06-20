﻿using System.Collections.Generic;

namespace LordOfUltima.MGameboard
{
    public class TownhouseElementType : IElementType
    {
        private readonly string _name;
        private readonly string _imagePath;
        private readonly string _detailImagePath;
        private readonly string _elementInfo;
        private readonly bool _hasLevelEnable;
        private readonly bool _isRessources;
        private readonly ElementType.Type _elementType;
        private readonly Dictionary<int, ElementCost> _elementCostsList = new Dictionary<int, ElementCost>();
        private readonly Dictionary<int, ElementProduction> _elementProductionList = new Dictionary<int, ElementProduction>();


        public TownhouseElementType()
        {
            _elementType = ElementType.Type.BUILDING_TOWNHOUSE;
            _name = ElementType.GetTypeName(_elementType);
            _isRessources = false;
            _hasLevelEnable = true;
            _imagePath = "pack://application:,,,/Resources/Images/building_townhouse.png";
            _detailImagePath = "pack://application:,,,/Resources/Images/menu_townhouse.png";
            _elementInfo = "It enables taxation (gold). Income from tax can be increased by connecting Marketplaces and Harbors.";

            // Element cost for each level
            _elementCostsList.Add(1, new ElementCost(0, 100, 0));
            _elementCostsList.Add(2, new ElementCost(0, 300, 0));
            _elementCostsList.Add(3, new ElementCost(0, 600, 0));
            _elementCostsList.Add(4, new ElementCost(0, 2000, 0));
            _elementCostsList.Add(5, new ElementCost(1000, 4000, 0));
            _elementCostsList.Add(6, new ElementCost(2000, 7000, 0));
            _elementCostsList.Add(7, new ElementCost(3500, 11500, 0));
            _elementCostsList.Add(8, new ElementCost(7000, 17000, 0));
            _elementCostsList.Add(9, new ElementCost(14000, 20000, 0));
            _elementCostsList.Add(10, new ElementCost(29000, 29000, 0));

            // Element production for each level
            _elementProductionList.Add(1, new ElementProduction(0, 0, 0, 0, 25));
            _elementProductionList.Add(2, new ElementProduction(0, 0, 0, 0, 50));
            _elementProductionList.Add(3, new ElementProduction(0, 0, 0, 0, 75));
            _elementProductionList.Add(4, new ElementProduction(0, 0, 0, 0, 100));
            _elementProductionList.Add(5, new ElementProduction(0, 0, 0, 0, 130));
            _elementProductionList.Add(6, new ElementProduction(0, 0, 0, 0, 170));
            _elementProductionList.Add(7, new ElementProduction(0, 0, 0, 0, 210));
            _elementProductionList.Add(8, new ElementProduction(0, 0, 0, 0, 260));
            _elementProductionList.Add(9, new ElementProduction(0, 0, 0, 0, 320));
            _elementProductionList.Add(10, new ElementProduction(0, 0, 0, 0, 400));
        }

        public string Name() { return _name; }
        public bool HasLevelEnable() { return _hasLevelEnable; }
        public bool IsRessources() { return _isRessources; }
        public string GetImagePath() { return _imagePath; }
        public string GetDetailImagePath() { return _detailImagePath; }
        public string GetElementInfo() { return _elementInfo; }
        public ElementType.Type GetElementType() { return _elementType; }
        public ElementProductionBonus GetElementProductionBonus(int level) { return null; }

        public ElementCost GetElementCost(int level)
        {
            if (level > 0 && level <= 10)
            {
                return _elementCostsList[level];
            }
            return null;
        }

        public ElementProduction GetElementProduction(int level)
        {
            if (level > 0 && level <= 10)
            {
                return _elementProductionList[level];
            }
            return null;
        }
    }
}