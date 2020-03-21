﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem2IntroProjectWaterfall0._1
{
    public partial class StockUC : UserControl
    {
        StockItem selectedItem;
        public StockUC(StockItem item)
        {
            InitializeComponent();
            selectedItem = item;
            this.lblStockName.Text = item.Name;
            this.lblCurrentAmount.Text = item.CurrentAmmount.ToString();
            this.lblThreshold.Text = item.Threshold.ToString();
            if (selectedItem.CurrentAmmount < selectedItem.Threshold) lblCurrentAmount.ForeColor = Color.Red;
            else lblCurrentAmount.ForeColor = Color.Black;
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            selectedItem.CurrentAmmount--;
            if (lblCurrentAmount.Visible) this.lblCurrentAmount.Text = selectedItem.CurrentAmmount.ToString();
            else tbCurrentAmount.Text = selectedItem.CurrentAmmount.ToString();
            if (selectedItem.CurrentAmmount < selectedItem.Threshold) lblCurrentAmount.ForeColor = Color.Red;
            else lblCurrentAmount.ForeColor = Color.Black;
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            selectedItem.CurrentAmmount++;
            if (lblCurrentAmount.Visible) this.lblCurrentAmount.Text = selectedItem.CurrentAmmount.ToString();
            else tbCurrentAmount.Text = selectedItem.CurrentAmmount.ToString();
            if (selectedItem.CurrentAmmount < selectedItem.Threshold) lblCurrentAmount.ForeColor = Color.Red;
            else lblCurrentAmount.ForeColor = Color.Black;
        }

        private void lblCurrentAmount_DoubleClick(object sender, EventArgs e)
        {
            this.lblCurrentAmount.Visible = false;
            this.tbCurrentAmount.Visible = true;
            this.tbCurrentAmount.Text = selectedItem.CurrentAmmount.ToString();
        }

        private void lblThreshold_DoubleClick(object sender, EventArgs e)
        {
            this.lblThreshold.Visible = false;
            this.tbThreshold.Visible = true;
            this.tbThreshold.Text = selectedItem.Threshold.ToString();
        }

        private void tbCurrentAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.selectedItem.CurrentAmmount = Convert.ToInt32(tbCurrentAmount.Text);
                this.lblCurrentAmount.Visible = true;
                this.tbCurrentAmount.Visible = false;
                this.lblCurrentAmount.Text = selectedItem.CurrentAmmount.ToString();
                if (selectedItem.CurrentAmmount < selectedItem.Threshold) lblCurrentAmount.ForeColor = Color.Red;
                else lblCurrentAmount.ForeColor = Color.Black;
            }
        }

        private void tbThreshold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.selectedItem.Threshold = Convert.ToInt32(tbThreshold.Text);
                this.lblThreshold.Visible = true;
                this.tbThreshold.Visible = false;
                this.lblThreshold.Text = selectedItem.Threshold.ToString();
                if (selectedItem.CurrentAmmount < selectedItem.Threshold) lblCurrentAmount.ForeColor = Color.Red;
                else lblCurrentAmount.ForeColor = Color.Black;
            }
        }
    }
}
