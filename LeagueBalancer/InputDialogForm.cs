using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeagueBalancer
{
    public partial class InputDialogForm : Form
    {
        public string InputValue { get; private set; }

        public InputDialogForm()
        {
            InitializeComponent();
            LoadRanks();
        }

        private void InputDialogForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadRanks()
        {
            // IRON
            leagueRank.Items.Add("IRON I");
            leagueRank.Items.Add("IRON II");
            leagueRank.Items.Add("IRON III");
            leagueRank.Items.Add("IRON IV");

            // BRONZE
            leagueRank.Items.Add("BRONZE I");
            leagueRank.Items.Add("BRONZE II");
            leagueRank.Items.Add("BRONZE III");
            leagueRank.Items.Add("BRONZE IV");

            // SILVER
            leagueRank.Items.Add("SILVER I");
            leagueRank.Items.Add("SILVER II");
            leagueRank.Items.Add("SILVER III");
            leagueRank.Items.Add("SILVER IV");

            // GOLD
            leagueRank.Items.Add("GOLD I");
            leagueRank.Items.Add("GOLD II");
            leagueRank.Items.Add("GOLD III");
            leagueRank.Items.Add("GOLD IV");

            // PLATINUM
            leagueRank.Items.Add("PLATINUM I");
            leagueRank.Items.Add("PLATINUM II");
            leagueRank.Items.Add("PLATINUM III");
            leagueRank.Items.Add("PLATINUM IV");

            // EMERALD
            leagueRank.Items.Add("EMERALD I");
            leagueRank.Items.Add("EMERALD II");
            leagueRank.Items.Add("EMERALD III");
            leagueRank.Items.Add("EMERALD IV");

            // DIAMOND
            leagueRank.Items.Add("DIAMOND I");
            leagueRank.Items.Add("DIAMOND II");
            leagueRank.Items.Add("DIAMOND III");
            leagueRank.Items.Add("DIAMOND IV");

            // MASTER
            leagueRank.Items.Add("MASTER");
            leagueRank.Items.Add("GRANDMASTER");
            leagueRank.Items.Add("CHALLENGER");

            leagueRank.SelectedIndex = 0;
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            InputValue = leagueRank.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
