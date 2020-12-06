using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Music_Player.Setup;
using System.IO;

namespace Music_Player.Forms
{
    public partial class SetupManager : Form
    {
        private Setupc setup;
        public SetupManager()
        {
            InitializeComponent();
            var setup = new Setupc();
            this.setup = setup;
            setup.complete_setup(Path.GetDirectoryName(Application.ExecutablePath), this);
            this.FormClosed += this.cancel;
        }
        public void updateProgress(int i) {
            progressBar.Value = i;
        }
        public void updateSetupLabel(String x) {
            label2.Text = x;
        }
        public void onComplete()
        {
            MessageBox.Show("Setup Completed lets restart!");
            Application.Exit();
        }

        private void SetupManager_Load(object sender, EventArgs e)
        {

        }

        private void cancel(object sender, EventArgs e)
        {
            this.setup.clear(Path.GetDirectoryName(Application.ExecutablePath));
            Application.Exit();
        }
        public void throwe(String m){
            MessageBox.Show(m);
        }
    }
}
