using DataAccessLayer.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoValExcel
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != null && txtPassword.Text != null)
            {
                var student = new { Name = txtUsername.Text, Password = txtPassword.Text };
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://demo.govalidation.net:8081/goval/user/newUserLogin");

                    httpWebRequest.Method = "POST";

                    httpWebRequest.Headers.Add("aftership-api-key:********fdbfd93980b8c5***");
                    httpWebRequest.ContentType = "application/json";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = "{\n\t\"emailOrUsername\":\"" + txtUsername.Text + "\",\n\t\"password\":\"" + txtPassword.Text + "\"\n}";

                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();

                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                            var succeval = JsonConvert.DeserializeObject<dynamic>(result);
                            if (succeval.result == "success")
                            {
                                CommonCS.Token = succeval.token;

                            }
                            else
                            {
                                MessageBox.Show("Invalid Login");
                            }
                        }
                    }
                }
            }
            if (true)
            {
              //  Globals.ThisWorkbook.ActionsPane.Controls.Add(new ActionsPaneControl1());
              //  this.Close();
            }
            else
            {

            }
        }
    }
}
