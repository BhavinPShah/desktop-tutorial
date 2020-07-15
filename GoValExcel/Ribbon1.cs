using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace GoValExcel
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Range currentSelectedCell = Globals.ThisWorkbook.Application.ActiveCell;
            // Globals.Sheet1.Range["A1"].Style.Locked = true;
            //Globals.Sheet1.Protect();
            //currentSelectedCell.Value = "Hello world";
            frmLogin userform = new frmLogin();
            userform.Show();
        }
    }
}
