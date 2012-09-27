using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Crm.Sdk.RibbonExporter.Views
{
    public partial class ServerConfigurationForm : Form
    {
        private ServerConnection _serverConn;
        public ServerConnection ServerConnection { get; set; }
        public ServerConfigurationForm()
        {
            InitializeComponent();
        }

        public void PopulateSavedConfigurations()
        {
            ServerConnection serverConn = new ServerConnection();
            Boolean isConfigExist = serverConn.ReadConfigurations();
            if (isConfigExist)
            {
                for (int i = 0; i < serverConn.configurations.Count; i++)
                {
                    cmb_configurations.Items.Add(serverConn.configurations[i].ServerAddress + " : " + serverConn.configurations[i].OrganizationName);
                }
            }
        }

        private void ServerConfiguration_Load(object sender, EventArgs e)
        {
            PopulateSavedConfigurations();
        }
    }
}
