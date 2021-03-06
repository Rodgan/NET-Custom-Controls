﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NET__Custom_Controls.BasicElements;

namespace NET__Custom_Controls.Barcode
{
    [ToolboxItem(true)]
    public partial class EAN8 : BarcodeElement
    {
        public EAN8()
        {
            InitializeComponent();
            CurrentBarcodeType = BarcodeType.EAN8;
            SetMargin(7, 1, 7, 1);
        }
    }
}
