﻿using System;
using System.Collections.Generic;
using System.Windows.Controls;
using LordOfUltima.MGameboard;
using Label = System.Windows.Controls.Label;
using System.Windows.Shapes;

namespace LordOfUltima.Research.Element
{
    class StoneResearch : IResearchType
    {
        private readonly Dictionary<int, string> _imagePathDictionary = new Dictionary<int, string>();
        private readonly Dictionary<int, ResearchCost> _researchCosts = new Dictionary<int, ResearchCost>();
        private readonly Dictionary<int, ResearchBonus> _researchBonuses = new Dictionary<int, ResearchBonus>();

        private int _level;

        public StoneResearch()
        {
            // Image Path
            _imagePathDictionary.Add(1, "pack://application:,,,/Resources/Images/Research/Lou_artifact_copper_pick.png");
            _imagePathDictionary.Add(2, "pack://application:,,,/Resources/Images/Research/Lou_artifact_bronze_pick.png");
            _imagePathDictionary.Add(3, "pack://application:,,,/Resources/Images/Research/Lou_artifact_steel_pick.png");
            _imagePathDictionary.Add(4, "pack://application:,,,/Resources/Images/Research/Lou_artifact_silver_pick.png");
            _imagePathDictionary.Add(5, "pack://application:,,,/Resources/Images/Research/Lou_artifact_gold_pick.png");
            _imagePathDictionary.Add(6, "pack://application:,,,/Resources/Images/Research/Lou_artifact_platinum_pick.png");
            _imagePathDictionary.Add(7, "pack://application:,,,/Resources/Images/Research/Lou_artifact_verite_pick.png");
            _imagePathDictionary.Add(8, "pack://application:,,,/Resources/Images/Research/Lou_artifact_valorite_pick.png");

            // Research Cost
            _researchCosts.Add(1, new ResearchCost(100, 100, new ElementCost(0, 1000, 0)));
            _researchCosts.Add(2, new ResearchCost(500, 200, new ElementCost(0, 3000, 0)));
            _researchCosts.Add(3, new ResearchCost(2000, 500, new ElementCost(0, 5000, 0)));
            _researchCosts.Add(4, new ResearchCost(5000, 1000, new ElementCost(0, 10000, 0)));
            _researchCosts.Add(5, new ResearchCost(10000, 2000, new ElementCost(0, 20000, 0)));
            _researchCosts.Add(6, new ResearchCost(20000, 5000, new ElementCost(0, 35000, 0)));
            _researchCosts.Add(7, new ResearchCost(35000, 10000, new ElementCost(0, 50000, 0)));
            _researchCosts.Add(8, new ResearchCost(50000, 15000, new ElementCost(0, 65000, 0)));

            // Research bonus
            _researchBonuses.Add(1, new ResearchBonus(0, 10, 0, 0));
            _researchBonuses.Add(2, new ResearchBonus(0, 20, 0, 0));
            _researchBonuses.Add(3, new ResearchBonus(0, 35, 0, 0));
            _researchBonuses.Add(4, new ResearchBonus(0, 50, 0, 0));
            _researchBonuses.Add(5, new ResearchBonus(0, 70, 0, 0));
            _researchBonuses.Add(6, new ResearchBonus(0, 90, 0, 0));
            _researchBonuses.Add(7, new ResearchBonus(0, 120, 0, 0));
            _researchBonuses.Add(8, new ResearchBonus(0, 150, 0, 0));
        }

        public string GetElementPath(int level)
        {
            if (level > 0 && level <= 8)
            {
                return _imagePathDictionary[level];
            }
            return null;
        }

        public ResearchCost GetResearchCost(int level)
        {
            if (level > 0 && level <= 8)
            {
                return _researchCosts[level];
            }
            return null;
        }

        public ResearchBonus GetResearchBonus(int level)
        {
            if (level > 0 && level <= 8)
            {
                return _researchBonuses[level];
            }
            return null;
        }

        public int GetLevel()
        {
            return _level;
        }

        public int SetLevel(int level)
        {
            if (level > 0 && level <= GetMaxLevel())
            {
                _level = level;
            }
            return _level;
        }

        public int GetMaxLevel()
        {
            return _researchBonuses.Count;
        }

        public Label GetCurrentBonusLabel()
        {
            var mainWindow = MainWindow.MIns;
            if (mainWindow == null)
                throw new Exception("Invalid Main Window");

            return mainWindow.research_stone_current_bonus;
        }

        public Label GetNextBonusLabel()
        {
            var mainWindow = MainWindow.MIns;
            if (mainWindow == null)
                throw new Exception("Invalid Main Window");

            return mainWindow.research_stone_next_bonus;
        }

        public Rectangle GetImageRectangle()
        {
            var mainWindow = MainWindow.MIns;
            if (mainWindow == null)
                throw new Exception("Invalid Main Window");

            return mainWindow.research_stone_image;
        }

        public Button GetResearchButton()
        {
            var mainWindow = MainWindow.MIns;
            if (mainWindow == null)
                throw new Exception("Invalid Main Window");

            return mainWindow.research_stone_button;
        }

        public Canvas GetCostCanvas()
        {
            var mainWindow = MainWindow.MIns;
            if (mainWindow == null)
                throw new Exception("Invalid Main Window");

            return mainWindow.research_stone_cost;
        }

        public Label GetResearchCostLabel()
        {
            var mainWindow = MainWindow.MIns;
            if (mainWindow == null)
                throw new Exception("Invalid Main Window");

            return mainWindow.research_stone_research_cost;
        }

        public Label GetGoldCostLabel()
        {
            var mainWindow = MainWindow.MIns;
            if (mainWindow == null)
                throw new Exception("Invalid Main Window");

            return mainWindow.research_stone_gold_cost;
        }

        public Label GetRessourceCostLabel()
        {
            var mainWindow = MainWindow.MIns;
            if (mainWindow == null)
                throw new Exception("Invalid Main Window");

            return mainWindow.research_stone_stone_cost;
        }
    }
}