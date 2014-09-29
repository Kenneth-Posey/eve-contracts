﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panhandler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label1.Text = "Ore";
            label2.Text = "Compressed Ore";
            label3.Text = "Ice";
            label4.Text = "Compressed Ice";
            label5.Text = "Minerals";
            label6.Text = "Ice Products";

            label7.Text = "+0%";
            label8.Text = "+5%";
            label9.Text = "+10%";

            List<ComboBox> comboBoxes = new List<ComboBox>() {
                  comboBox1
                , comboBox2
                , comboBox3
                , comboBox4
                , comboBox5
                , comboBox6
            };

            foreach (var box in comboBoxes)
            {
                box.Items.Insert(0, "Select One");
                box.SelectedIndex = 0;
                box.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                box.SelectedIndexChanged += combox_SelectedIndexChanged;
            }
            
            button1.Text = "Add";
            button2.Text = "Remove";
            button3.Text = "Calculate";

            List<string> rawOre = new List<string>() {
                  "Arkonor"
                , "Bistot"
                , "Crokite"
                , "Dark Ochre"
                , "Gneiss"
                , "Hedbergite"
                , "Hemorphite"
                , "Jaspet"
                , "Kernite"
                , "Mercoxit"
                , "Omber"
                , "Spodumain"
                , "Veldspar"
            };

            List<string> rawIce = new List<string>() {
                  "Blue Ice"
                , "Clear Icicle"
                , "Dark Glitter"
                , "Enriched Clear Icicle"
                , "Gelidus"
                , "Glacial Mass"
                , "Glare Crust"
                , "Krystallos"
                , "Pristine White Glaze"
                , "Smooth Glacial Mass"
                , "Thick Blue Ice"
                , "White Glaze"
            };

            List<string> iceProducts = new List<string>() {
                  "Heavy Water"
                , "Helium Isotopes"
                , "Hydrogen Isotopes"
                , "Liquid Ozone"
                , "Nitrogen Isotopes"
                , "Oxygen Isotopes"
                , "Strontium Clathrates"
            };

            List<string> minerals = new List<string>() {
                  "Isogen"
                , "Megacyte"
                , "Mexallon"
                , "Morphite"
                , "Nocxium"
                , "Pyerite"
                , "Tritanium"
                , "Zydrine"
            };
            
            comboBox1.Items.AddRange(rawOre.ToArray<object>());
            comboBox2.Items.AddRange(rawOre.ToArray<object>());
            comboBox3.Items.AddRange(rawIce.ToArray<object>());
            comboBox4.Items.AddRange(rawIce.ToArray<object>());
            comboBox5.Items.AddRange(minerals.ToArray<object>());
            comboBox6.Items.AddRange(iceProducts.ToArray<object>());


        }

        protected void combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
